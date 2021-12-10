﻿namespace BradyCodeTest
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    public class CoalService : GeneratorBase
    {
        [XmlElement("TotalHeatInput")]
        public decimal TotalHeatInput { get; set; }

        [XmlElement("ActualNetGeneration")]
        public decimal ActualNetGeneration { get; set; }

        [XmlElement("EmissionsRating")]
        public decimal EmissionsRating { get; set; }

        public override decimal GetTotals()
        {
            foreach (var Day in Days)
            {
                Total = Total + Day.Price * Day.Energy * ReferenceDataHelper.ValueFactorMedium;
            }

            //The below decimal can be rounded, For now i followed as per the requirement.  
            return Total;
        }

        public List<DailyEmissions> GetDailyEmissions()
        {
            var dailyEmissions = new List<DailyEmissions>();

            foreach (var Day in Days)
            {
                dailyEmissions.Add(new DailyEmissions { Name = Name, Date = Day.Date, Emission = Day.Energy * EmissionsRating * ReferenceDataHelper.EmissionFactorHigh });
            }

            return dailyEmissions;
        }

        public decimal GetActualHeatRate()
        {
            return TotalHeatInput / ActualNetGeneration;
        }
    }
}
