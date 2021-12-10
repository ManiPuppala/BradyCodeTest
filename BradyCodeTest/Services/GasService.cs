﻿
namespace BradyCodeTest
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    public class GasService : GeneratorBase
    {
        [XmlElement("EmissionsRating")]
        public decimal EmissionsRating { get; set; }

        public override decimal GetTotals()
        {
            foreach (var Day in Days)
            {
                Total = Total + Day.Price * Day.Energy * ReferenceDataHelper.ValueFactorMedium;
            }
            //The below decimal can be rounded, For now i followed as per the requirement and given output file.  
            return Total;
        }

        public List<DailyEmissions> GetDailyEmissions()
        {
            List<DailyEmissions> dailyEmissions = new List<DailyEmissions>();

            foreach (var Day in Days)
            {
                dailyEmissions.Add(new DailyEmissions { Name = Name, Date = Day.Date, Emission = Day.Energy * EmissionsRating * ReferenceDataHelper.EmissionFactorMedium });
            }

            return dailyEmissions;
        }
    }
}
