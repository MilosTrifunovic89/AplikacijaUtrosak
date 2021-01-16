using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Domain;
using Domain.Customer;
using Domain.Offer;
using Domain.Products;
using Domain.Storage;

namespace DataBaseBroker
{
    public class Broker
    {
        #region Fields
        private static Broker _instance;

        private SqlConnection _conn;
        #endregion

        #region Properties
        public static Broker Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Broker();
                return _instance;
            }
        }
        #endregion

        #region Constructor
        private Broker()
        {
            _conn = new SqlConnection(@"Data Source=.;Initial Catalog=Wood;Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                        TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        #endregion

        #region Methods
        #region LoadMethods
        public ObservableCollection<Material> LoadAllMaterialsByType(string type)
        {
            ObservableCollection<Material> _plyWoods = new ObservableCollection<Material>();

            SqlCommand cmd = new SqlCommand($"select materijalid, nazivmaterijala, debljina, vrsta, cena, tekstura from lagerlista where Vrsta='{type}'", _conn);

            try
            {
                _conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Material materal = new Material()
                    {
                        MaterialID = reader.GetInt64(0),
                        MaterialName = reader.GetString(1),
                        Thickness = reader.GetInt32(2),
                        Type = reader.GetString(3),
                        Price = reader.GetDecimal(4),
                        Texture = reader.GetBoolean(5)
                    };

                    _plyWoods.Add(materal);
                }

                return _plyWoods;
            }
            finally
            {
                _conn.Close();
            }
        }

        public ObservableCollection<EdgeTape> LoadAllEdgeTapes()
        {
            ObservableCollection<EdgeTape> _edgeTapes = new ObservableCollection<EdgeTape>();

            SqlCommand cmd = new SqlCommand($"select kanttrakaid, nazivkanttrake, sirina, debljina, vrsta, cena from kanttraka", _conn);

            try
            {
                _conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EdgeTape materal = new EdgeTape()
                    {
                        ID = reader.GetInt64(0),
                        EdgeTapeName = reader.GetString(1),
                        Width = reader.GetInt32(2),
                        Thickness = reader.GetDouble(3),
                        Type = reader.GetString(4),
                        Price = reader.GetDecimal(5)
                    };

                    _edgeTapes.Add(materal);
                }

                return _edgeTapes;
            }
            finally
            {
                _conn.Close();
            }
        }

        public ObservableCollection<FittingsClass> LoadAllFittings()
        {
            ObservableCollection<FittingsClass> _fittings = new ObservableCollection<FittingsClass>();

            SqlCommand cmd = new SqlCommand($"select okovid, nazivokova, jedinicamere, cena from okov", _conn);

            try
            {
                _conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FittingsClass fitting = new FittingsClass()
                    {
                        ID = reader.GetInt64(0),
                        FittingName = reader.GetString(1),
                        UnitOfMeasure = reader.GetString(2),
                        Price = reader.GetDecimal(3)
                    };

                    _fittings.Add(fitting);
                }

                return _fittings;
            }
            finally
            {
                _conn.Close();
            }
        }

        public ObservableCollection<CustomerClass> LoadAllCustomers(string type)
        {
            ObservableCollection<CustomerClass> _allCustomers = new ObservableCollection<CustomerClass>();

            SqlCommand cmd;

            if (type == "Civil")
                cmd = new SqlCommand("select kupacid, ime, prezime, adresa, maticnibroj from fizickolice", _conn);
            else if (type == "Public")
                cmd = new SqlCommand("select kupacid, firma, adresa, pib, maticnibroj from pravnolice", _conn);
            else
                return null;

            try
            {
                _conn.Open();

                var reader = cmd.ExecuteReader();

                CivilCustomer civilustomer = new CivilCustomer();
                PublicCustomer publicCustomer = new PublicCustomer();
                while (reader.Read())
                {
                    if (type == "Civil")
                    {
                        civilustomer = new CivilCustomer()
                        {
                            ID = reader.GetInt64(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Address = reader.GetString(3),
                            IDnumber = reader.GetString(4)
                        };

                        _allCustomers.Add(civilustomer);
                    }
                    else if (type == "Public")
                    {
                        publicCustomer = new PublicCustomer()
                        {
                            ID = reader.GetInt64(0),
                            CompanyName = reader.GetString(1),
                            CompanyAddress = reader.GetString(2),
                            PIB = reader.GetString(3),
                            CompanyIDnumber = reader.GetString(4)
                        };

                        _allCustomers.Add(publicCustomer);
                    }
                }

                return _allCustomers;
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                    _conn.Close();
            }
        }

        public ObservableCollection<Product> LoadAllElements()
        {
            ObservableCollection<Product> products = new ObservableCollection<Product>();

            SqlCommand cmd = new SqlCommand($"select ProizvodID, Naziv, Dimenzije, UkupnaCena from GotovProizvod", _conn);

            try
            {
                _conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ID = reader.GetInt64(0),
                        Name = reader.GetString(1),
                        Dimenzion = reader.GetString(2),
                        Price = reader.GetDecimal(3)
                    };
                    products.Add(product);
                }
                return products;
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                    _conn.Close();
            }
        }
        #endregion

        #region InsertMethods
        public void InsertElementIntoBase(Element element, User user)
        {
            try
            {
                _conn.Open();

                SqlCommand cmdSpecification = new SqlCommand($"insert into Sastavnica (NazivSastavnice) values ('{element.ElementName}');select cast (scope_identity() as bigint)", _conn);
                long specificationID = (long)cmdSpecification.ExecuteScalar();

                if (element.EdgeTapeLendth() != null)
                    for (int i = 0; i < element.EdgeTapeLendth().Count; i++)
                    {
                        long edgeTapeID = element.EdgeTapeLendth().Keys.ElementAt(i).ID;
                        double quantity = element.EdgeTapeLendth().Values.ElementAt(i);
                        SqlCommand cmdEdgeTape = new SqlCommand($"insert into SastavnicaKantTraka (SastavnicaID, KantTrakaID, Kolicina) values ({specificationID}, {edgeTapeID},{quantity})", _conn);
                        cmdEdgeTape.ExecuteScalar();
                    }

                if (element.MaterialSurface() != null)
                    for (int i = 0; i < element.MaterialSurface().Count; i++)
                    {
                        long materialID = element.MaterialSurface().Keys.ElementAt(i).MaterialID;
                        double quantity = element.MaterialSurface().Values.ElementAt(i);
                        SqlCommand cmdMaterial = new SqlCommand($"insert into SastavnicaMaterijal (SastavnicaID, MaterijalID, Kolicina) values ({specificationID},{materialID},{quantity})", _conn);
                        cmdMaterial.ExecuteScalar();
                    }

                if (element.FittingsInElement != null)
                    for (int i = 0; i < element.FittingsInElement.Count; i++)
                    {
                        long fittingID = element.FittingsInElement[i].ID;
                        double quantity = element.FittingsInElement[i].Quantity;
                        SqlCommand cmdFittings = new SqlCommand($"insert into SastavnicaOkov (SastavnicaID, OkovID, Kolicina) values ({specificationID},{fittingID},{quantity})", _conn);
                        cmdFittings.ExecuteScalar();
                    }

                string type = string.Empty;
                if (element.ID < 1000000)
                    type = "OBICNA SIFRA";
                else
                    type = "TENDER";

                SqlCommand cmdElement = new SqlCommand($"insert into gotovproizvod (proizvodid, naziv, dimenzije, UkupnaCena, PlanskaCena, tip, Sastavnicaid, ProdavacID) values ({element.ID}, '{element.ElementName}'," +
                    $"'{element.Width}/{element.Depth}/{element.Height}', {element.TotalPrice}, {element.MaterialPrice}, '{type}', {specificationID}, {user.ID})", _conn);
                cmdElement.ExecuteScalar();
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                    _conn.Close();
            }
        }

        public void InsertCustomerIntoBase(CivilCustomer civilCustomer, PublicCustomer publicCustomer, User user)
        {
            try
            {
                _conn.Open();
                long customerID = 0;

                if (civilCustomer != null)
                {
                    SqlCommand cmdCustomer = new SqlCommand($"insert into kupac (tip,prodavacid) values ('{civilCustomer.Type}','{user.ID}');select cast (scope_identity() as bigint)", _conn);
                    customerID = (long)cmdCustomer.ExecuteScalar();

                    SqlCommand cmdCivilCustomer = new SqlCommand($"insert into fizickolice (kupacid, ime, prezime, adresa, maticnibroj) values ({customerID}, '{civilCustomer.FirstName}'," +
                        $"'{civilCustomer.LastName}', '{civilCustomer.Address}', '{civilCustomer.IDnumber}')", _conn);
                    cmdCivilCustomer.ExecuteScalar();
                }

                else if (publicCustomer != null)
                {
                    SqlCommand cmdCustomer = new SqlCommand($"insert into kupac (tip) values ('{publicCustomer.Type}');select cast (scope_identity() as bigint)", _conn);
                    customerID = (long)cmdCustomer.ExecuteScalar();

                    SqlCommand cmcPublicCustomer = new SqlCommand($"insert into pravnolice (kupacid, firma, adresa, pib, maticnibroj) values ({customerID},'{publicCustomer.CompanyName}', '{publicCustomer.CompanyAddress}', '{publicCustomer.PIB}', '{publicCustomer.CompanyIDnumber}')", _conn);
                    cmcPublicCustomer.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Greska\n{e.Message}");
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                    _conn.Close();
            }
        }

        public void InsertArticalIntoOffer(List<OfferProduct> offerProducts)
        {
            try
            {
                _conn.Open();

                for (int i = 0; i < offerProducts.Count; i++)
                {
                    SqlCommand cmdCustomer = new SqlCommand($"insert into SadrzajPonude (PonudaID, ProizvodID, NazivArtikla, Dimenzije, Cena, Kolicina, OpisArtikla, Slika)" +
                    $" values ({offerProducts[i].OfferID}, {offerProducts[i].ProductID}, '{offerProducts[i].ProductName}', '{offerProducts[i].Dimension}', {offerProducts[i].Price}, {offerProducts[i].Quantity}, '{offerProducts[i].Description}', '{offerProducts[i].Image}'))", _conn);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Greska\n{e.Message}");
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool InsertOffer(OfferClass offer, User user)
        {
            try
            {
                long customerID = 0;

                if (offer.CivilCustomer != null)
                    customerID = offer.CivilCustomer.ID;
                else if (offer.PublicCustomer != null)
                    customerID = offer.PublicCustomer.ID;

                _conn.Open();

                SqlCommand cmdOffer = new SqlCommand($"insert into Ponuda (PonudaID, Godina, DatumIzrade, RokIsporuke, RokZaPlacanje, VazenjePonude, StatusPonude, ProdavacID, KupacID) values " +
                    $"({offer.ID}, {offer.Year}, '{offer.Year}', {offer.DeliveryTime}, {offer.PaymentTime}, {offer.OfferValidity}, 'NA CEKANJU', {user.ID}, {customerID})", _conn);
                cmdOffer.ExecuteScalar();

                for (int i = 0; i < offer.ElementList.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand($"insert into SadrzajPonude (PonudaID, Godina, ProizvodID, NazivArtikla, Dimenzije, Cena, Kolicina, OpisArtikla) values " +
                        $"({offer.ID}, {offer.Year}, {offer.ElementList[i].ProductID}, '{offer.ElementList[i].ProductName}', " +
                        $"'{offer.ElementList[i].Dimension}', " +
                        $"{offer.ElementList[i].Price}, {offer.ElementList[i].Quantity}, '{offer.ElementList[i].Description}')", _conn);
                    cmd.ExecuteScalar();
                }

                return true;
            }
            catch (Exception e)
            {                
                MessageBox.Show($"Greska\n {e.Message}");
                return false;
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                    _conn.Close();
            }
        }
        #endregion
        public User LogInSuccessful(string userName, string password)
        {
            SqlCommand cmd = new SqlCommand($"select prodavacid,ime,prezime,sifra from prodavac where ime = '{userName}' and sifra ='{password}'", _conn);

            try
            {
                _conn.Open();

                var reader = cmd.ExecuteReader();



                while (reader.Read())
                {
                    if (userName == reader["Ime"].ToString() && password == reader["sifra"].ToString())
                    {
                        User user = new User();
                        user.ID = reader.GetInt64(0);
                        user.FirstName = reader.GetString(1);
                        user.LastName = reader.GetString(2);
                        user.Password = reader.GetString(3);
                        return user;
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Greska\n{e.Message}");
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public long GetMaxProductID(string type)
        {
            long max = 0;
            if (type == "regular")
                max = 0;
            if (type == "tender")
                max = 1000000;

            SqlCommand cmd = new SqlCommand("select proizvodid from gotovproizvod", _conn);

            try
            {
                _conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (type == "regular" && reader.GetInt64(0) >= 1000000)
                        break;
                    if (reader.GetInt64(0) > max)
                        max = reader.GetInt64(0);
                }

                _conn.Close();
                if (max == 0)
                    return 1;
                return max + 1;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                    _conn.Close();
            }
        }

        public long GetMaxCustomerID()
        {
            long max = 0;

            SqlCommand cmd = new SqlCommand("select kupacid from kupac", _conn);

            try
            {
                _conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetInt64(0) > max)
                        max = reader.GetInt64(0);
                }
                _conn.Close();
                if (max == 0)
                    return 1;
                return max + 1;
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                    _conn.Close();
            }
        }

        public long GetMaxOfferID()
        {
            long max = 0;

            SqlCommand cmd = new SqlCommand("select PonudaID from Ponuda", _conn);

            try
            {
                _conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetInt64(0) > max)
                        max = reader.GetInt64(0);
                }
                _conn.Close();

                if (max == 0)
                    return 1;
                return max + 1;
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                    _conn.Close();
            }
        }
        #endregion
    }
}
