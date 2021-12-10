namespace BradyCodeTest
{
    using System.IO;
    using System.Xml.Serialization;   
    public static class XMLHelper
    {
        public static GenerationReportInputModel ParsingXML(string path)
        {
            GenerationReportInputModel GenerationReport;

            XmlSerializer serializer = new XmlSerializer(typeof(GenerationReportInputModel));

            using (var reader = new StreamReader(path))
            {
                GenerationReport = (GenerationReportInputModel)serializer.Deserialize(reader);
            }
            return GenerationReport;
        }

        public static void CreateXML(GenerationOutputModel generationOutput, string fileName)
        {
            var filename = fileName.Split('.')[0]+ "-Result.xml";

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add("", "");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GenerationOutputModel));

            using (var writer = new StreamWriter(ConfigHelper.GenerationOutputFilePath + filename))
            {
                xmlSerializer.Serialize(writer, generationOutput, xmlNamespaces);
            }
            MoveFileAfterProcess(fileName);
        }


        private static void MoveFileAfterProcess(string fileName)
        {
            string sourceFile = ConfigHelper.GenerationReportInputFilePath+ fileName;
            string destinationFile = ConfigHelper.ProcessedFilesPath + fileName;

            // Move a proccessed file into processe folder to handle redundancy 
            File.Move(sourceFile, destinationFile);           
        }


    }
}
