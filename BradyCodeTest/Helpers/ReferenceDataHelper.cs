namespace BradyCodeTest
{
    using System;
    using System.Xml;
    public static class ReferenceDataHelper
    {
        public static readonly decimal ValueFactorLow;

        public static readonly decimal ValueFactorMedium;

        public static readonly decimal ValueFactorHigh;

        public static readonly decimal EmissionFactorLow;

        public static readonly decimal EmissionFactorMedium;

        public static readonly decimal EmissionFactorHigh;

        static ReferenceDataHelper()
        {
            ValueFactorLow = GetReferenceData("ValueFactor", "Low");
            ValueFactorMedium = GetReferenceData("ValueFactor", "Medium");
            ValueFactorHigh = GetReferenceData("ValueFactor", "High");
            EmissionFactorLow = GetReferenceData("EmissionsFactor", "Low");
            EmissionFactorMedium = GetReferenceData("EmissionsFactor", "Medium");
            EmissionFactorHigh = GetReferenceData("EmissionsFactor", "High");
        }


        public static decimal GetReferenceData(string parentnodeName, string childnodeName)
        {
            decimal result = 0.0M;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigHelper.ReferenceDataFilePath);
            XmlNode node = xmlDoc.DocumentElement.FirstChild;
            XmlNodeList chaildNode = node.ChildNodes;

            for (int i = 0; i < chaildNode.Count; i++)
            {
                if (chaildNode[i].Name == parentnodeName)
                {
                    XmlNodeList secondchaildNode = chaildNode[i].ChildNodes;
                    for (int j = 0; j < secondchaildNode.Count; j++)
                    {
                        if (secondchaildNode[j].Name == childnodeName)
                        {                           
                            result = Convert.ToDecimal(secondchaildNode[j].InnerText);
                            break;
                        }
                    }
                }
            }

            return result;

        }


    }
}
