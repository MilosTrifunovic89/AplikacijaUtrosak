using Domain.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public enum ElementType
    {
        Table,
        Corpus
    }
    public class Element : PropertyChangedHelpClass
    {
        #region Fields
        private ObservableCollection<FittingsClass> _fittingsInElement = new ObservableCollection<FittingsClass>();
        #endregion

        #region Properties
        public string ElementName { get; set; }
        public long ID { get; set; }
        public int Depth { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ObservableCollection<Detail> DetailList { get; set; }
        public Material Material { get; set; }
        public ObservableCollection<FittingsClass> FittingsInElement
        {
            get { return _fittingsInElement; }
            set { _fittingsInElement = value; }
        }
        public decimal MaterialPrice { get; private set; }
        public decimal TotalPrice { get; protected set; }
        public string Type { get; set; }
        #endregion

        #region Constructors
        public Element(long id, string elementName, int width, int height, int depth)
        {
            ID = id;
            ElementName = elementName;
            Width = width;
            Height = height;
            Depth = depth;
        }

        public Element()
        {

        }
        #endregion

        #region Methods
        #region EdgeTapsMethods
        public void RemoveAllEdgeTapesFromDetail(Detail selectedDetail)
        {
            for (int i = 0; i < selectedDetail.EdgeTapeList.Length; i++)
                if (selectedDetail.EdgeTapeList[i] != null)
                    selectedDetail.EdgeTapeList[i] = null;
        }

        public void RemoveAllEdgeTapes()
        {
            foreach (var detail in DetailList)
            {
                for (int i = 0; i < detail.EdgeTapeList.Length; i++)
                {
                    detail.EdgeTapeList[i] = null;
                }
            }
        }

        public void AddEdgeTapes(Detail detail, EdgeTape edgeOne, EdgeTape edgeTwo, EdgeTape edgeThree, EdgeTape edgeFour)
        {
            if (edgeOne != null)
                detail.EdgeTapeList[0] = CreatEdgeTapeLendth(edgeOne, detail);

            if (edgeTwo != null)
                detail.EdgeTapeList[1] = CreatEdgeTapeLendth(edgeTwo, detail);

            if (edgeThree != null)
                detail.EdgeTapeList[2] = CreatEdgeTapeWidth(edgeThree, detail);

            if (edgeFour != null)
                detail.EdgeTapeList[3] = CreatEdgeTapeWidth(edgeFour, detail);
        }

        private EdgeTape CreatEdgeTapeLendth(EdgeTape selectedEdgeTape, Detail detail)
        {
            EdgeTape edgeTape = new EdgeTape()
            {
                ID = selectedEdgeTape.ID,
                EdgeTapeName = selectedEdgeTape.EdgeTapeName,
                Width = selectedEdgeTape.Width,
                Thickness = selectedEdgeTape.Thickness,
                Type = selectedEdgeTape.Type,
                Price = selectedEdgeTape.Price,
                Length = detail.Length * detail.Quantity
            };

            return edgeTape;
        }

        private EdgeTape CreatEdgeTapeWidth(EdgeTape selectedEdgeTape, Detail detail)
        {
            EdgeTape edgeTape = new EdgeTape()
            {
                ID = selectedEdgeTape.ID,
                EdgeTapeName = selectedEdgeTape.EdgeTapeName,
                Width = selectedEdgeTape.Width,
                Thickness = selectedEdgeTape.Thickness,
                Type = selectedEdgeTape.Type,
                Price = selectedEdgeTape.Price,
                Length = detail.Width * detail.Quantity
            };

            return edgeTape;
        }
        #endregion

        #region FittingsMethods
        public void AddFittings(FittingsClass fitting)
        {
            if (_fittingsInElement.Contains(fitting))
                foreach (var item in _fittingsInElement)
                {
                    if (item.ID == fitting.ID)
                        item.Quantity += fitting.Quantity;
                }
            else
                _fittingsInElement.Add(fitting);
        }

        public void RemoveFittings(FittingsClass fitting)
        {
            foreach (var item in _fittingsInElement)
            {
                if (item.ID == fitting.ID)
                {
                    _fittingsInElement.Remove(item);
                    break;
                }
            }
        }
        #endregion

        #region SpecificationMethods
        public Dictionary<Material, double> MaterialSurface()
        {
            Dictionary<Material, double> surfaceOfDetail = new Dictionary<Material, double>();
            List<Material> materialList = new List<Material>();

            foreach (var detail in DetailList)
            {
                if (!materialList.Contains(detail.Material))
                    materialList.Add(detail.Material);
            }

            for (int i = 0; i < materialList.Count; i++)
            {
                double result = 0;
                for (int j = 0; j < DetailList.Count; j++)
                {
                    var detail = DetailList[j];
                    if (detail.Material.MaterialID == materialList[i].MaterialID)
                        result += detail.Surface();
                }
                surfaceOfDetail.Add(materialList[i], Math.Round(result, 2));
            }

            return surfaceOfDetail;
        }

        public Dictionary<EdgeTape, double> EdgeTapeLendth()
        {
            Dictionary<EdgeTape, double> edgeTapeLength = new Dictionary<EdgeTape, double>();
            List<EdgeTape> edgeTapeList = new List<EdgeTape>();

            foreach (var detail in DetailList)
            {
                if (detail.EdgeTapeList != null)
                    foreach (var edgeTape in detail.EdgeTapeList)
                    {
                        if (!edgeTapeList.Contains(edgeTape) && edgeTape != null)
                            edgeTapeList.Add(edgeTape);
                    }
            }

            for (int i = 0; i < edgeTapeList.Count; i++)
            {
                double result = 0;//duzina trake
                for (int j = 0; j < DetailList.Count; j++)
                {
                    var detail = DetailList[j];
                    for (int k = 0; k < detail.EdgeTapeList.Length; k++)
                    {
                        var edgeTape = detail.EdgeTapeList[k];
                        if (edgeTape != null && edgeTapeList[i].ID == edgeTape.ID)
                            result += (double)edgeTape.Length / 1000;
                    }
                }
                edgeTapeLength.Add(edgeTapeList[i], Math.Round(result, 2));
            }

            return edgeTapeLength;
        }


        public string GetSpecification(decimal marza = 1)
        {
            string result = string.Empty;

            result += $"{ElementName} {Width}/{Depth}/{Height}h\n\n";

            result += "Povrsina:\n";
            foreach (var item in MaterialSurface())
            {

                if (item.Key.Texture == true)
                    result += $"{item.Key} - {Math.Round(item.Value * 1.2, 2)} m2\n";
                else if (item.Key.Texture == false)
                    result += $"{item.Key} - {Math.Round(item.Value * 1.1, 2)} m2\n";
            }

            result += "\nDuzina kant trake:\n";
            foreach (var item in EdgeTapeLendth())
            {
                result += $"{item.Key} - {item.Value} m\n";
            }

            result += "\nOkov:\n";

            foreach (var item in FittingsInElement)
            {
                result += $"{item.FittingName} - {item.Quantity} {item.UnitOfMeasure}\n";
            }

            MaterialPrice = ElementPrice();

            TotalPrice = MaterialPrice * marza;

            result += $"\nUkupna cena: {String.Format("{0:N}", TotalPrice)} din";
            result += $"\nPlanska cena: {String.Format("{0:N}", MaterialPrice)} din";

            return result;
        }
        #endregion

        public decimal ElementPrice()
        {
            decimal result = 0;
            foreach (var material in MaterialSurface())
            {
                if (material.Key.Texture == true)
                    result += material.Key.Price * (decimal)material.Value * 1.2m;
                else if (material.Key.Texture == false)
                    result += material.Key.Price * (decimal)material.Value * 1.1m;
            }

            foreach (var edgeTape in EdgeTapeLendth())
            {
                result += edgeTape.Key.Price * (decimal)edgeTape.Value;
            }

            foreach (var fitting in FittingsInElement)
            {
                result += fitting.Price * (decimal)fitting.Quantity;
            }

            return Math.Round(result, 2);
        }

        public override bool Equals(object obj)
        {
            Element element = obj as Element;
            return (element != null && element.ID == ID);
        }
        #endregion
    }
}
