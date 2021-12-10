using BradyCodeTest.Services;
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

               
                
                ConfigHelper.GetConfigFile();

                var files = Directory.GetFiles(ConfigHelper.GenerationReportInputFilePath);
                
               
                if (files.Length > 0 )
                {
                    
                    foreach (var file in files)
                    {
                        GenerationReportInputModel GenerationReport = XMLHelper.ParsingXML(file);
                        var GenerationOutput = new OutputGenrationService(GenerationReport);

                        XMLHelper.CreateXML(GenerationOutput.generationOutput(), Path.GetFileName(file));
                    }

                }

                else
                {
                    Console.WriteLine(string.Format("File Not Available in the directory : {0}", ConfigHelper.GenerationReportInputFilePath));
                    Console.WriteLine("Will check evey 15 seconds");
                }




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
