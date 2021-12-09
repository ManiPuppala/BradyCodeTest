using System;
using System.IO;
using System.Threading;
namespace BradyCodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Brady PLC Code Challenge Application Running..");

            try
            {
                
                ConfigHelper.ParseConfigFile();            
                //If not check evey 15 seconds
                while (!File.Exists(ConfigHelper.GenerationReportInputFilePath))
                {
                    Console.WriteLine(string.Format("File Not Available in the directory : {0}", ConfigHelper.GenerationReportInputFilePath));
                    Console.WriteLine("Will check evey ten seconds");
                    Thread.Sleep(15000);
                }

                GenerationReportInputModel GenerationReport = XMLHelper.ParsingXML();

                GenerationOutputModel GenerationOutput = new GenerationOutputModel(GenerationReport);

                XMLHelper.CreateXML(GenerationOutput);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Exception occured {0}", e.Message));
            }
            finally
            {
                Console.WriteLine("Click Any Key to Exit...");
                Console.ReadLine();
            }
        }
    }
}
