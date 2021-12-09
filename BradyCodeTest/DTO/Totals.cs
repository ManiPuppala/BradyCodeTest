namespace BradyCodeTest
{
    using System.Xml.Serialization;
    public class Totals
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Total")]
        public decimal Total { get; set; }
    }
}
