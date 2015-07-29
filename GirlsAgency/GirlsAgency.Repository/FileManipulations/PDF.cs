using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using GirlsAgency.Data;
using GirlsAgency.Model;
using System.IO;


namespace GirlsAgencyConsoleClient.Exporters
{
    public class PDF
    {

        public static void Export(string start, string end)
        {

            using (Document pdfReport = new Document())
            {
                var startDate = DateTime.Parse(start);
                var endDate = DateTime.Parse(end);

                FileStream file = File.Create("D:\\GirlsReport.pdf");
                PdfWriter.GetInstance(pdfReport, file);
                pdfReport.Open();

                iTextSharp.text.Image girlsImg = iTextSharp.text.Image.GetInstance("../../../girlsIcon.png");
                girlsImg.ScaleToFit(200f, 200f);

                // girlsImg.SetAbsolutePosition(pdfReport.PageSize.Width  - 100f, pdfReport.PageSize.Height - 50f );

                pdfReport.Add(girlsImg);

                //set table
                PdfPTable table = new PdfPTable(5);
                table.TotalWidth = 550f;
                table.LockedWidth = true;
                float[] widths = new float[] { 150f, 80f, 80f, 150f, 90f };
                table.SetWidths(widths);

                PdfPCell header = new PdfPCell(new Phrase("Aggregated Girls Orders Report"))
                {
                    Colspan = 5,
                    HorizontalAlignment = 1,
                    BackgroundColor = new BaseColor(135, 196, 28),
                    PaddingTop = 10f,
                    PaddingBottom = 10f
                };

                table.AddCell(header);

                decimal grandSum = 0;

                using (var context = new GirlsAgencyContext())
                {
                    var orderDates = context.Orders
                        .Where(o => o.Date >= startDate && o.Date <= endDate)
                        .Select(o => o.Date)
                        .Distinct()
                        .ToList();

                    foreach (var date in orderDates)
                    {
                        DisplayHeaderDates(table, date);

                        var orders = context.Orders
                            .Where(o => o.Date == date)
                            .Select(o => new
                            {
                                GirlName = o.Girl.FirstName + " " + o.Girl.LastName,
                                o.Duration,
                                PricePerHour = o.Girl.PricePerHour,
                                Client = o.Customer.FirstName + " " + o.Customer.LastName,
                                Sum = o.Duration * o.Girl.PricePerHour
                            })
                            .ToList();

                        foreach (var order in orders)
                        {
                            DisplayColumn(table, order.GirlName);
                            DisplayColumn(table, order.Duration.ToString("F2"));
                            DisplayColumn(table, order.PricePerHour.ToString("F2"));
                            DisplayColumn(table, order.Client);
                            DisplayColumn(table, order.Sum.ToString("F2"));
                        }

                        var totalDateSum = orders.Sum(o => o.Sum);
                        DisplayDateFooter(table, date, totalDateSum);

                        grandSum += totalDateSum;
                    }
                }

                DisplayGrandSumFooter(table, grandSum);

                pdfReport.Add(table);
                pdfReport.Close();

            }
        }

        public static void DisplayHeaderDates(PdfPTable table, DateTime date)
        {
            PdfPCell headerDate = new PdfPCell(new Phrase("Date: " + date.ToString("d-MMM-yyyy")))
            {
                Colspan = 5,
                HorizontalAlignment = 0,
                BackgroundColor = new BaseColor(250, 196, 28),
                PaddingTop = 10f,
                PaddingBottom = 10f
            };

            table.AddCell(headerDate);

            DisplayHeaderColumn(table, "Girl");
            DisplayHeaderColumn(table, "Order Duration");
            DisplayHeaderColumn(table, "Price Per Hour");
            DisplayHeaderColumn(table, "Client");
            DisplayHeaderColumn(table, "Sum");

        }

        public static void DisplayHeaderColumn(PdfPTable table, string column)
        {
            PdfPCell headerColumn = new PdfPCell(new Phrase(column))
            {
                Colspan = 1,
                HorizontalAlignment = 0,
                BackgroundColor = new BaseColor(135, 180, 26),
                PaddingTop = 5f,
                PaddingBottom = 5f
            };

            table.AddCell(headerColumn);
        }

        public static void DisplayColumn(PdfPTable table, string column)
        {
            PdfPCell cell = new PdfPCell(new Phrase(column))
            {
                Colspan = 1,
                HorizontalAlignment = 0,
                BackgroundColor = new BaseColor(210, 210, 210),
                PaddingTop = 5f,
                PaddingBottom = 5f
            };

            table.AddCell(cell);
        }

        public static void DisplayDateFooter(PdfPTable table, DateTime date, decimal sum)
        {
            PdfPCell footerCell = new PdfPCell(new Phrase("Total sum for " + date.ToString("d-MMM-yyyy") + ":"))
            {
                Colspan = 4,
                HorizontalAlignment = 0,
                BackgroundColor = new BaseColor(135, 180, 26),
                PaddingTop = 5f,
                PaddingBottom = 5f
            };
            table.AddCell(footerCell);

            PdfPCell footerCellTotalSum = new PdfPCell(new Phrase(sum.ToString("F2")))
            {
                Colspan = 1,
                HorizontalAlignment = 0,
                BackgroundColor = new BaseColor(135, 180, 26),
                PaddingTop = 5f,
                PaddingBottom = 5f
            };
            table.AddCell(footerCellTotalSum);
        }

        public static void DisplayGrandSumFooter(PdfPTable table, decimal grandSum)
        {
            PdfPCell footerCellGrandText = new PdfPCell(new Phrase("Grand Total: "))
            {
                Colspan = 4,
                HorizontalAlignment = 2,
                BackgroundColor = new BaseColor(115, 160, 20),
                PaddingTop = 5f,
                PaddingBottom = 5f
            };
            table.AddCell(footerCellGrandText);

            PdfPCell footerCellGrandTotal = new PdfPCell(new Phrase(grandSum.ToString("F2")))
            {
                Colspan = 1,
                HorizontalAlignment = 2,
                BackgroundColor = new BaseColor(250, 196, 28),
                PaddingTop = 5f,
                PaddingBottom = 5f
            };
            table.AddCell(footerCellGrandTotal);
        }
    }
}
