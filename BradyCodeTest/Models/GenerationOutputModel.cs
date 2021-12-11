namespace BradyCodeTest.Models
{
    using BradyCodeTest.DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Serialization;
    public class GenerationOutputModel
    {
        [XmlArray("Totals")]
        [XmlArrayItem("Generator", typeof(Totals))]
        public List<Totals> GeneratorTotals { get; set; }

        [XmlArray("MaxEmissionGenerators")]
        [XmlArrayItem("Day", typeof(MaxEmissionGenerators))]
        public List<MaxEmissionGenerators> GeneratorMaxEmissions { get; set; }

        [XmlElement("ActualHeatRates")]
        public List<CoalActualHeatRates> GeneratorCoalActualHeatRates { get; set; }

    }
}
