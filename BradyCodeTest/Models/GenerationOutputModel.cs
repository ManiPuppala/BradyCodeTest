namespace BradyCodeTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Serialization;
    public class GenerationOutputModel
    {
        [XmlArray("Totals")]
        [XmlArrayItem("Generator", typeof(Totals))]
        public List<Totals> GeneratorTotals = new List<Totals>();

        [XmlArray("MaxEmissionGenerators")]
        [XmlArrayItem("Day", typeof(MaxEmissionGenerators))]
        public List<MaxEmissionGenerators> GeneratorMaxEmissions = new List<MaxEmissionGenerators>();

        [XmlElement("ActualHeatRates")]
        public List<CoalActualHeatRates> CoalActualHeatRates = new List<CoalActualHeatRates>();

        private GenerationReportInputModel generationReport;

        public GenerationOutputModel(GenerationReportInputModel generationReport)
        {
            this.generationReport = generationReport;
            GetGeneratorTotals();
            GetGeneratorMaxEmissions();
            GetActualHeatRates();
        }
        public GenerationOutputModel()
        {

        }
        private List<DailyEmissions> GetDailyEmissions()
        {
            var DailyEmissions = new List<DailyEmissions>();

            foreach (var CoalGenerator in generationReport.CoalGenerators)
            {
                DailyEmissions.AddRange(CoalGenerator.GetDailyEmissions());
            }

            foreach (var GasGenerator in generationReport.GasGenerators)
            {
                DailyEmissions.AddRange(GasGenerator.GetDailyEmissions());
            }

            return DailyEmissions;
        }

        private void GetActualHeatRates()
        {
            foreach (var CoalGenerator in generationReport.CoalGenerators)
            {
                CoalActualHeatRates.Add(new CoalActualHeatRates { Name = CoalGenerator.Name, HeatRate = CoalGenerator.GetActualHeatRate() });              
            }
        }
        private void GetGeneratorMaxEmissions()
        {
            var DailyEmissions = GetDailyEmissions().ToList();
            var generatorDays = DailyEmissions.Where(r => r.Date != null)
                        .Select(r => r.Date)
                        .Distinct();


            foreach (var generatorDay in generatorDays)
            {
                var employee = DailyEmissions.Where(x => x.Date == generatorDay);
                var maxemission = employee.Aggregate((x, y) => x.Emission > y.Emission ? x : y);
                GeneratorMaxEmissions.Add(new MaxEmissionGenerators { Name = maxemission.Name, Date = maxemission.Date, Emission = maxemission.Emission });             

            }
        }

        private void GetGeneratorTotals()
        {
            foreach (var Wind in generationReport.WindGenerators)
            {
                GeneratorTotals.Add(new Totals { Name = Wind.Name, Total = Wind.GetTotals() });                
            }

            foreach (var Gas in generationReport.GasGenerators)
            {
                GeneratorTotals.Add(new Totals { Name = Gas.Name, Total = Gas.GetTotals() });                
            }

            foreach (var Coal in generationReport.CoalGenerators)
            {
                GeneratorTotals.Add(new Totals { Name = Coal.Name, Total = Coal.GetTotals() });               
            }

        }
    }
}
