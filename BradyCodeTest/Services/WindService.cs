namespace BradyCodeTest
{
    using System.Xml.Serialization;

    public class WindService : GeneratorBase
    {
        [XmlElement("Location")]
        public string Location { get; set; }

        public override decimal GetTotals()
        {
            if (Location == "Onshore")
            {
                foreach (var Day in Days)
                {
                    Total = Total + Day.Price * Day.Energy * ReferenceDataHelper.ValueFactorHigh;
                }

                return Total;
            }
            else
            {
                foreach (var Day in Days)
                {
                    Total = Total + Day.Price * Day.Energy * ReferenceDataHelper.ValueFactorLow;
                }

                return Total;
            }
        }
    }
}
