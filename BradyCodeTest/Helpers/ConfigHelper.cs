namespace BradyCodeTest
{
    using System.Configuration;
    public static class ConfigHelper
    {
        public static string GenerationReportInputFilePath;

        public static string GenerationOutputFilePath;

        public static string ReferenceDataFilePath;

        public static string ProcessedFilesPath;

        public static void GetConfigFile()
        {
            GenerationReportInputFilePath = ConfigurationManager.AppSettings["GenerationReportInputFilePath"];
            GenerationOutputFilePath = ConfigurationManager.AppSettings["GenerationOutputFilePath"];
            ReferenceDataFilePath = ConfigurationManager.AppSettings["ReferenceDataFilePath"];
            ProcessedFilesPath = ConfigurationManager.AppSettings["ProcessedFilesPath"];            

        }
    }
}
