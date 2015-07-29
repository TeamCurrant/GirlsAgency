using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using GirlsAgency.Data;
using GirlsAgency.Model;
using GirlsAgency.Repository.Repositories;

namespace GirlsAgency.Repository.FileManipulations
{
    public static class XML
    {
        public static void Read(string xmlPath)
        {
            var reader = new XmlTextReader(xmlPath);

            var xml = new XmlDocument();
            xml.Load(xmlPath);
            var nodeList = xml.SelectNodes("//Order");
            var count = nodeList.Count;

            var index = 0;
            var girlIndex = 0;
            var array = new object[count, 6];
            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Text) continue;

                array[girlIndex, index] = reader.Value;
                index = (index + 1) % 6;

                if (index == 0)
                {
                    girlIndex++;
                }
            }

            var kor = ConvertToCollection(array);
            ImportOrdersToDatabase(kor);
        }

        private static void ImportOrdersToDatabase(IEnumerable<Order> orders)
        {
            var sqlRepo = new GenericRepository<Order>(new GirlsAgencyContext());
            var girlRepo = new GenericRepository<Girl>(new GirlsAgencyContext());
            var ctx = new GirlsAgencyContext();
            foreach (var order in orders)
            {
                sqlRepo.Add(order);
                //ctx.Customers.
            }

            sqlRepo.SaveChanges();
        }

        private static IEnumerable<Order> ConvertToCollection(object[,] valueArray)
        {
            var orderList = new List<Order>();
            var sqlGirlRepo = new GenericRepository<Girl>(new GirlsAgencyContext());
            var sqlCustomerRepo = new GenericRepository<Customer>(new GirlsAgencyContext());

            for (var row = 0; row < valueArray.GetLength(0); row++)
            {
                var girlFirstName = valueArray[row, 0].ToString();
                var girlLastName = valueArray[row, 1].ToString();
                var customerFirstName = valueArray[row, 2].ToString();
                var customerLastName = valueArray[row, 3].ToString();
                var duration = Convert.ToInt32(valueArray[row, 4]);
                var dateTime = Convert.ToDateTime(valueArray[row, 5]);


                var girlId = sqlGirlRepo.Search(n => n.FirstName == girlFirstName && n.LastName == girlLastName).First().Id;
                var girlOBJ =
                    sqlGirlRepo.Search(n => n.FirstName == girlFirstName && n.LastName == girlLastName).First();
                

                var customerId = sqlCustomerRepo.Search(n => n.FirstName == customerFirstName && n.LastName == customerLastName).First().Id;
                var order = new Order
                {
                    GirlId = girlId,
                    CustomerId = customerId,
                    Duration = duration,
                    Date = dateTime
                };
                var baihoi = sqlGirlRepo.GetCustomer(customerId);
                girlOBJ.Customers.Add(baihoi);
                sqlGirlRepo.SaveChanges();
               
                //order.Girl.Customers.Add(sqlCustomerRepo.GetCustomer(customerId));
                orderList.Add(order);
            }
           
            return orderList;
        }

        public static void ExportCitiesReport(string start, string end)
        {
            var startDate = DateTime.Parse(start);
            var endDate = DateTime.Parse(end);
            string fileName = "D:\\citiesReport.xml";
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
