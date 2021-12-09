namespace BradyCodeTest
{
    using System;
    using System.Xml.Serialization;
    public class GenerationDay
    {
        [XmlElement("Date")]
        public DateTime Date { get; set; }

        [XmlElement("Energy")]
        public decimal Energy { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
