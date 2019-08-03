using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace SalesInvoiceGenerator
{
    class PDFGenerator
    {
        public static void generatePDF()
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 43, 35);
            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "//Sales_Invoice_" + System.DateTime.Now.ToString("MMddyyy_hhmmss") + "_" + dataInfo.Serial + ".pdf";
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            var serialCodeColor = new BaseColor(255, 0, 0);
            var headerName = FontFactory.GetFont("Times", 20, Font.BOLD);
            var companyName = FontFactory.GetFont("Courier", 11, Font.BOLD);
            var infoText = FontFactory.GetFont("Courier", 9);
            var serialCode = FontFactory.GetFont("Courier", 18, Font.BOLD, serialCodeColor);
            var to = FontFactory.GetFont("Courier", 13, Font.BOLD);
            var custLabel = FontFactory.GetFont("Courier", 10);
            var custInfo = FontFactory.GetFont("Courier", 10, Font.BOLD);
            var tableHeader = FontFactory.GetFont("Tahoma", 9, Font.BOLD);
            var tableValues = FontFactory.GetFont("Tahoma", 9);
            var footer = FontFactory.GetFont("Courier", 7, Font.ITALIC);

            PdfPTable table = new PdfPTable(1);

            PdfPCell cell = new PdfPCell(new Paragraph("SALES INVOICE", headerName));
            cell.HorizontalAlignment = 0;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            doc.Add(table);
            doc.Add(new Paragraph("\n"));

            table = new PdfPTable(2);


            //COMPANY NAME

            cell = new PdfPCell(new Paragraph(dataInfo.CompanyName, companyName));
            cell.HorizontalAlignment = 0;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            //SERIAL CODE

            Console.WriteLine(dataInfo.Serial.ToString());
            cell = new PdfPCell(new Paragraph("No. " + dataInfo.Serial.ToString(), serialCode));
            cell.HorizontalAlignment = 2;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            //ADDRESS
            cell = new PdfPCell(new Paragraph(dataInfo.Address1, infoText));
            cell.HorizontalAlignment = 0;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            //DATE
            cell = new PdfPCell(new Paragraph(System.DateTime.Today.ToString("MM/dd/yyyy"), infoText));
            cell.HorizontalAlignment = 2;
            cell.Border = Rectangle.NO_BORDER;
            cell.Rowspan = 3;
            table.AddCell(cell);

            //CITY, STATE, ZIP
            cell = new PdfPCell(new Paragraph(dataInfo.City + ", " + dataInfo.State + ", " + dataInfo.Zip, infoText));
            cell.HorizontalAlignment = 0;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            //PHONE
            cell = new PdfPCell(new Paragraph(dataInfo.Phone, infoText));
            cell.HorizontalAlignment = 0;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            doc.Add(table);

            doc.Add(new Paragraph("\n"));

            table = new PdfPTable(2);
            table.WidthPercentage = 50;
            //TO:
            cell = new PdfPCell(new Paragraph("To:", to));
            cell.HorizontalAlignment = 0;
            cell.Colspan = 2;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            //CUSTOMER NAME:
            cell = new PdfPCell(new Paragraph("Customer Name", custLabel));
            cell.HorizontalAlignment = 0;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            //CUSTOMER NAME VAL:
            cell = new PdfPCell(new Paragraph(CustomerInfo.CustomerName, custInfo));
            cell.HorizontalAlignment = 0;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            //ADDRESS 1:
            cell = new PdfPCell(new Paragraph("Address 1", custLabel));
            cell.HorizontalAlignment = 0;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            //ADDRESS 1 VAL:
            cell = new PdfPCell(new Paragraph(CustomerInfo.Address1, custInfo));
            cell.HorizontalAlignment = 0;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            if (String.IsNullOrEmpty(CustomerInfo.Address2))
            {
                //CITY INFO:
                cell = new PdfPCell(new Paragraph("City, State, Zip", custLabel));
                cell.HorizontalAlignment = 0;
                cell.Border = Rectangle.NO_BORDER;
                table.AddCell(cell);

                //CITY INFO VAL:
                cell = new PdfPCell(new Paragraph(CustomerInfo.CityStateZip, custInfo));
                cell.HorizontalAlignment = 0;
                cell.Border = Rectangle.NO_BORDER;
                table.AddCell(cell);
            }
            else
            {
                //ADDRESS 2:
                cell = new PdfPCell(new Paragraph("Address 2", custLabel));
                cell.HorizontalAlignment = 0;
                cell.Border = Rectangle.NO_BORDER;
                table.AddCell(cell);

                //ADDRESS 2 VAL:
                cell = new PdfPCell(new Paragraph(CustomerInfo.Address2, custInfo));
                cell.HorizontalAlignment = 0;
                cell.Border = Rectangle.NO_BORDER;
                table.AddCell(cell);

                //CITY INFO:
                cell = new PdfPCell(new Paragraph("City, State, Zip", custLabel));
                cell.HorizontalAlignment = 0;
                cell.Border = Rectangle.NO_BORDER;
                table.AddCell(cell);

                //CITY INFO VAL:
                cell = new PdfPCell(new Paragraph(CustomerInfo.CityStateZip, custInfo));
                cell.HorizontalAlignment = 0;
                cell.Border = Rectangle.NO_BORDER;
                table.AddCell(cell);
            }

            doc.Add(table);

            doc.Add(new Paragraph("\n"));

            table = new PdfPTable(5);

            //HEADERS

            cell = new PdfPCell(new Paragraph("Item", tableHeader));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Description", tableHeader));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Unit Price", tableHeader));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph("QTY", tableHeader));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Total", tableHeader));
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            for(int i=0;i < CustomerInfo.Item.Count; i++)
            {
                cell = new PdfPCell(new Paragraph(CustomerInfo.Item[i], tableValues));
                cell.HorizontalAlignment = 0;
                table.AddCell(cell);

                cell = new PdfPCell(new Paragraph(CustomerInfo.Desc[i], tableValues));
                cell.HorizontalAlignment = 0;
                table.AddCell(cell);

                cell = new PdfPCell(new Paragraph("PhP " + CustomerInfo.Unit[i], tableValues));
                cell.HorizontalAlignment = 0;
                table.AddCell(cell);

                cell = new PdfPCell(new Paragraph(CustomerInfo.Qty[i], tableValues));
                cell.HorizontalAlignment = 0;
                table.AddCell(cell);

                cell = new PdfPCell(new Paragraph(CustomerInfo.Total[i], tableValues));
                cell.HorizontalAlignment = 0;
                table.AddCell(cell);
            }

            doc.Add(table);
            doc.Add(new Paragraph("\n"));

            table = new PdfPTable(5);

            cell = new PdfPCell(new Paragraph("Notes", tableHeader));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            //cell.Border = Rectangle.NO_BORDER;
            cell.Colspan = 3;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Subtotal", tableHeader));
            cell.HorizontalAlignment = 2;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph(CustomerInfo.SubTotal, tableValues));
            cell.HorizontalAlignment = 2;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph(CustomerInfo.Notes, tableHeader));
            cell.HorizontalAlignment = 0;
            //cell.Border = Rectangle.NO_BORDER;
            cell.Colspan = 3;
            cell.Rowspan = 6;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Tax", tableHeader));
            cell.HorizontalAlignment = 2;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph(CustomerInfo.Tax, tableValues));
            cell.HorizontalAlignment = 2;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Total Due", tableHeader));
            cell.HorizontalAlignment = 2;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph(CustomerInfo.TotalDue, tableValues));
            cell.HorizontalAlignment = 2;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", tableValues));
            cell.Colspan = 2;
            cell.HorizontalAlignment = 2;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph(" ", tableValues));
            cell.Colspan = 2;
            cell.HorizontalAlignment = 2;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph(" ", tableValues));
            cell.Colspan = 2;
            cell.HorizontalAlignment = 2;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph(" ", tableValues));
            cell.Colspan = 2;
            cell.HorizontalAlignment = 2;
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);


            doc.Add(table);

            Paragraph p = new Paragraph("This is a computer generated invoice : Generated on " + System.DateTime.Now.ToString("hh:mm tt") + " of " + System.DateTime.Now.ToString("MM/dd/yyyy"), footer);
            p.Alignment = Element.ALIGN_CENTER;

            doc.Add(new Paragraph("\n\n"));
            doc.Add(p);
            doc.Close();

            System.Diagnostics.Process.Start(path);
        }
    }
}
