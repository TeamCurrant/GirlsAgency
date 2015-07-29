using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GirlsAgency.Data;
using GirlsAgency.Model;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace GirlsAgencyConsoleClient.Exporters
{
    class XMLExporter
    {
        public static void ExportCitiesReport(string start, string end)
        {
            var startDate = DateTime.Parse(start);
            var endDate = DateTime.Parse(end);
            string fileName = "../../../citiesReport.xml";
            Encoding encoding = Encoding.GetEncoding("utf-8");

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("cities");

                WriteReportByCities(writer, startDate, endDate);
                writer.WriteEndDocument();
            }
        }

        private static void WriteReportByCities(XmlTextWriter writer, DateTime startDate, DateTime endDate)
        {
            using (var context = new GirlsAgencyContext())
            {
                foreach (var city in context.Cities.ToList())
                {
                    var TotalOrdersByDate = context.Orders
                        .Where(order => order.Girl.CityId == city.CityId &&
                        order.Date >= startDate && order.Date <= endDate)
                        .OrderBy(order => order.Date)
                        .GroupBy(order => order.Date)
                        .Select(orderAndIncome => new
                        {
                            Date = orderAndIncome.Key,
                            Income = orderAndIncome.Sum(order => order.Duration * order.Girl.PricePerHour)
                        })
                        .ToList();

                    if (TotalOrdersByDate.Any())
                    {
                        writer.WriteStartElement("city");
                        writer.WriteAttributeString("name", city.Name);

                        foreach (var order in TotalOrdersByDate)
                        {
                            DisplayIncomes(writer, order.Date, order.Income);
                        }

                        writer.WriteEndElement();
                    }
                }
            }
        }

        private static void DisplayIncomes(XmlTextWriter writer, DateTime date, decimal totalIncome)
        {
            writer.WriteStartElement("summary");
            writer.WriteAttributeString("date", date.ToString("d-MMM-yyyy"));
            writer.WriteAttributeString("total-sum", totalIncome.ToString("F2"));
            writer.WriteEndElement();
        }


    }
}
