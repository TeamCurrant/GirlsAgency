using System;
using System.Collections.Generic;
using System.Xml;
using GirlsAgency.Model;
using GirlsAgency.Model.Enums;

namespace GirlsAgency.Data.FileManipulations
{
    public static class XML
    {
        public static IEnumerable<Girl> ReadXML(string xmlPath, string xmlFile)
        {
            var reader = new XmlTextReader(xmlPath + xmlFile);

            var xml = new XmlDocument();
            xml.Load(xmlPath + xmlFile);
            var nodeList = xml.SelectNodes("//Girl");
            var count = nodeList.Count;

            var index = 0;
            var girlIndex = 0;
            var array = new object[count, 8];
            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Text) continue;

                array[girlIndex, index] = reader.Value;
                index = (index + 1) % 8;

                if (index == 0)
                {
                    girlIndex++;
                }
            }

            var kor = ConvertToCollection(array);

            return kor;
        }

        private static ICollection<Girl> ConvertToCollection(object[,] valueArray)
        {
            var girlsArray = new List<Girl>();

            for (var row = 0; row < valueArray.GetLength(0); row++)
            {
                var girl = new Girl
                {
                    FirstName = valueArray[row, 0].ToString(),
                    LastName = valueArray[row, 1].ToString(),
                    Age = Convert.ToInt32(valueArray[row, 2]),
                    BreastSizeId = GetBreastSizeType(valueArray[row, 3].ToString()),
                    HairColorId = GetHairColorType(valueArray[row, 4].ToString()),
                    PricePerHour = Convert.ToInt32(valueArray[row, 7])
                };

                girlsArray.Add(girl);
            }

            return girlsArray;
        }

        private static int GetBreastSizeType(string brestType)
        {
            var result = Enum.Parse(typeof(BreastSizeEnum), brestType);
            if (result != null)
            {
                return (int)result;
            }

            return 0;
        }

        private static int GetHairColorType(string colorType)
        {
            var result = Enum.Parse(typeof(HairColorEnum), colorType);
            if (result != null)
            {
                return (int)result;
            }

            return 0;
        }
    }
}
