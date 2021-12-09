namespace BradyCodeTest
{
    using System.IO;
    using System.Xml.Serialization;
    public static class XMLHelper
    {
        public static GenerationReportInputModel ParsingXML()
        {
            GenerationReportInputModel GenerationReport;

            XmlSerializer serializer = new XmlSerializer(typeof(GenerationReportInputModel));

            using (var reader = new StreamReader(ConfigHelper.GenerationReportInputFilePath))
            {
                GenerationReport = (GenerationReportInputModel)serializer.Deserialize(reader);               
            }
            return GenerationReport;
        }

        public static void CreateXML(GenerationOutputModel generationOutput)
        {         
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add("", "");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GenerationOutputModel));

            using (var writer = new StreamWriter(ConfigHelper.GenerationOutputFilePath))
            {
                xmlSerializer.Serialize(writer, generationOutput, xmlNamespaces);
            }
        }
    }
}
