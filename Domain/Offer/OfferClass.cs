using Domain.Customer;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Offer
{
    public class OfferClass
    {
        #region Fields
        private long _id;
        private int _year;
        private int _deliveryTime;
        private int _paymentTime;
        private decimal _discount;
        private CivilCustomer _civilustomer;
        private PublicCustomer _publicCustomer;
        private ObservableCollection<OfferProduct> _elementList;
        private int _offerValidity;
        #endregion
        #region Properties
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public int OfferValidity
        {
            get { return _offerValidity; }
            set { _offerValidity = value; }
        }


        public ObservableCollection<OfferProduct> ElementList
        {
            get { return _elementList; }
            set { _elementList = value; }
        }

        public CivilCustomer CivilCustomer
        {
            get { return _civilustomer; }
            set { _civilustomer = value; }
        }

        public PublicCustomer PublicCustomer
        {
            get { return _publicCustomer; }
            set { _publicCustomer = value; }
        }

        public decimal Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }

        public int PaymentTime
        {
            get { return _paymentTime; }
            set { _paymentTime = value; }
        }

        public int DeliveryTime
        {
            get { return _deliveryTime; }
            set { _deliveryTime = value; }
        }

        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        
        public Document CreateOffer(/*OfferClass offer*/)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "PDF files (*.pdf)|*.pdf";
            dialog.FilterIndex = 0;


            string fileName = string.Empty;

            string path = string.Empty;

            if (dialog.ShowDialog() == true)
            {
                fileName = dialog.FileName;

                float width = 500f;
                bool lockedWidth = true;
                PdfPCell cell = new PdfPCell();
                float[] widthsOffer = new float[6];

                Font font = new Font();
                font.SetFamily("Times New Roman");
                font.Size = 9f;

                Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create));


                doc.Open();

                doc.Add(Header(cell, ID, width, lockedWidth, CivilCustomer, PublicCustomer));

                Paragraph paragraph = new Paragraph($"datum: {DateTime.Now.ToShortDateString()}", font);
                paragraph.Alignment = 0;
                paragraph.IndentationLeft = 40f;
                doc.Add(paragraph);

                paragraph = new Paragraph($"Broj ponude: {ID.ToString().PadLeft(4, '0')}/{Year}", font);
                paragraph.Alignment = 0;
                paragraph.IndentationLeft = 40f;
                paragraph.SpacingAfter = 10f;
                doc.Add(paragraph);

                PdfPTable offerTable = OfferTable(width, lockedWidth, cell, out widthsOffer, font);

                offerTable = Elements(offerTable, cell, ID, out decimal price, ElementList);

                doc.Add(offerTable);

                doc.Add(TotalPrice(width, lockedWidth, widthsOffer, cell, price, Discount));

                doc.Add(FooterTable(cell, DeliveryTime, PaymentTime, OfferValidity));

                doc.Close();

                return doc;
            }
            else
                return null;
        }

        private static PdfPTable Header(PdfPCell cell, long brojPonude, float width, bool lockedWidth, CivilCustomer civilCustomer, PublicCustomer publicCustomer)
        {
            string url = @"D:\slika.JPG";

            PdfPTable headerTable = new PdfPTable(1);
            PdfPTable table = new PdfPTable(3);
            table.TotalWidth = width;
            table.LockedWidth = lockedWidth;

            headerTable.TotalWidth = width;
            headerTable.LockedWidth = lockedWidth;

            float[] widths = new float[] { 1f, 2f, 2f };
            table.SetWidths(widths);

            Font font = new Font();
            font.SetFamily("Times New Roman");
            font.Size = 9f;

            //ovde
            Image imm = Image.GetInstance(new Uri(url));
            imm.ScaleToFit(100f, 50f);

            cell = new PdfPCell(imm);
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = Rectangle.ALIGN_MIDDLE;
            cell.Border = 0;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Kompanija KTITOR doo\nDobanovacki put 58\n11080 Zemun\nTel: 011 30 70 700\nFax: 011 30 70 777\n" +
                "PIB: 1000019999", font));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = 0;
            cell.Border = 0;
            table.AddCell(cell);


            if (civilCustomer != null)
            {
                cell = new PdfPCell(new Paragraph($"Kupac:\n{civilCustomer.FirstName} {civilCustomer.LastName}\n{civilCustomer.Address}\n{civilCustomer.IDnumber}", font));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.HorizontalAlignment = 2;
                cell.Border = 0;
                table.AddCell(cell);
            }
            else if (publicCustomer != null)
            {
                cell = new PdfPCell(new Paragraph($"Kupac:\n{publicCustomer.CompanyName}\n{publicCustomer.CompanyAddress}\n{publicCustomer.CompanyIDnumber}\n{publicCustomer.PIB}", font));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.HorizontalAlignment = 2;
                cell.Border = 0;
                table.AddCell(cell);
            }

            cell = new PdfPCell(table);
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            headerTable.AddCell(cell);

            return headerTable;
        }

        private static PdfPTable OfferTable(float width, bool lockedWidth, PdfPCell cell, out float[] widthsOffer, Font font)
        {
            PdfPTable offerTable = new PdfPTable(6);
            offerTable.TotalWidth = width;
            offerTable.LockedWidth = lockedWidth;

            widthsOffer = new float[] { 1f, 5f, 1f, 1.5f, 1.5f, 5f };
            offerTable.SetWidths(widthsOffer);

            cell = new PdfPCell(new Paragraph(" ", font));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = 1;
            offerTable.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Artikal", font));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = 1;
            offerTable.AddCell(cell);

            cell = new PdfPCell(new Paragraph("kol", font));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = 1;
            offerTable.AddCell(cell);

            cell = new PdfPCell(new Paragraph("jed cena", font));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = 1;
            offerTable.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Ukupno", font));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = 1;
            offerTable.AddCell(cell);

            cell = new PdfPCell(new Paragraph("izgled(slika)", font));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = 1;
            offerTable.AddCell(cell);

            return offerTable;
        }

        private static PdfPTable Elements(PdfPTable offerTable, PdfPCell cell, long ID, out decimal price, ObservableCollection<OfferProduct> offerProducts)
        {
            Font font = new Font();
            font.SetFamily("Times New Roman");
            font.Size = 9f;

            int j = 0;
            price = 0;
            for (int i = 0; i < offerProducts.Count; i++)
            {
                decimal sum = 0;

                cell = new PdfPCell(new Paragraph($"{++j}", font));
                offerTable.AddCell(cell);

                cell = new PdfPCell(new Paragraph($"{offerProducts[i].ProductName} dim: {offerProducts[i].Dimension}\n{offerProducts[i].Description}", font));
                offerTable.AddCell(cell);

                cell = new PdfPCell(new Paragraph(offerProducts[i].Quantity.ToString(), font));
                offerTable.AddCell(cell);

                cell = new PdfPCell(new Paragraph(String.Format("{0:N}", offerProducts[i].Price), font));
                offerTable.AddCell(cell);

                sum = offerProducts[i].Quantity * offerProducts[i].Price;
                cell = new PdfPCell(new Paragraph(String.Format("{0:N}", sum), font));
                offerTable.AddCell(cell);

                Image imm = null;
                if (offerProducts[i].Image != null)
                {
                    imm = Image.GetInstance(new Uri(offerProducts[i].Image));

                    imm.ScaleToFit(160f, 100f);

                    cell = new PdfPCell(imm);
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    cell.Padding = 5;

                    offerTable.AddCell(cell);
                }
                else
                    offerTable.AddCell(new Paragraph(" "));

                price += sum;
            }
            return offerTable;
        }

        private static PdfPTable TotalPrice(float width, bool lockedWidth, float[] widthsOffer, PdfPCell cell, decimal price, decimal discount)
        {
            Font font = new Font();
            font.SetFamily("Times New Roman");
            font.Size = 9f;

            PdfPTable tabelaUkupno = new PdfPTable(6);
            tabelaUkupno.TotalWidth = width;
            tabelaUkupno.LockedWidth = lockedWidth;

            tabelaUkupno.SetWidths(widthsOffer);

            decimal priceWithDiscount = price * (discount / 100);
            decimal priceWithoutPDV = price - priceWithDiscount;
            decimal PDV = priceWithoutPDV * 0.2m;
            decimal totalPrice = priceWithoutPDV + PDV;


            tabelaUkupno = TabelaUkupno("UKUPNO:", tabelaUkupno, cell, font, price);

            tabelaUkupno = TabelaUkupno($"Popust {discount.ToString()}%:", tabelaUkupno, cell, font, priceWithDiscount);

            tabelaUkupno = TabelaUkupno("Ukupno bez PDV-a:", tabelaUkupno, cell, font, priceWithoutPDV);

            tabelaUkupno = TabelaUkupno("PDV 20%:", tabelaUkupno, cell, font, PDV);

            tabelaUkupno = TabelaUkupno("SVE UKUPNO:", tabelaUkupno, cell, font, totalPrice);

            return tabelaUkupno;
        }

        private static PdfPTable TabelaUkupno(string rec, PdfPTable tabelaUkupno, PdfPCell cell, Font font, decimal price)
        {
            cell = new PdfPCell(new Paragraph(" "));
            cell.Colspan = 2;
            cell.Border = 0;
            tabelaUkupno.AddCell(cell);

            cell = new PdfPCell(new Paragraph(rec, font));
            cell.HorizontalAlignment = 1;
            cell.Colspan = 2;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            tabelaUkupno.AddCell(cell);

            cell = new PdfPCell(new Paragraph(String.Format("{0:N}", price), font));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            tabelaUkupno.AddCell(cell);

            cell = new PdfPCell(new Paragraph(" "));
            cell.Border = 0;
            tabelaUkupno.AddCell(cell);

            return tabelaUkupno;
        }

        private static PdfPTable FooterTable(PdfPCell cell, int deliveryTime, int paymentTime, int offerValidity)
        {
            Font font = new Font();
            font.SetFamily("Times New Roman");
            font.Size = 9f;

            PdfPTable footerTable = new PdfPTable(2);

            cell = new PdfPCell(new Paragraph($"USLOVI PONUDE:\nRok isporuke {deliveryTime} dana\nPlacanje - {paymentTime} dana po isporuci\n" +
                $"Opcija ponude - {offerValidity} dana\nGarancija - 24 meseca, servis obezbedjen i po isteku garancije.", font));
            cell.Border = 0;

            footerTable.SpacingBefore = 100f;

            footerTable.TotalWidth = 500f;
            footerTable.LockedWidth = true;
            footerTable.AddCell(cell);

            cell = new PdfPCell(new Paragraph(" \n \n \n \n \n \n \nSaglasan kupac:_________________________________", font));
            cell.Border = 0;
            cell.HorizontalAlignment = 2;
            footerTable.AddCell(cell);

            return footerTable;
        }
    }
}
