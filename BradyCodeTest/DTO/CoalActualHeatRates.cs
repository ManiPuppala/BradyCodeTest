namespace BradyCodeTest.DTO
{
    using System.Xml.Serialization;
    public class CoalActualHeatRates
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("HeatRate")]
        public decimal HeatRate { get; set; }
    }
}
