using System;
using Xunit;
using Moq;

namespace BradyCodeTest.UnitTest
{
    public class ReferenceDataHelperTest
    {
        public ReferenceDataHelperTest()
        {
            ConfigHelper.ReferenceDataFilePath = @"C:\ManiTestProjects\BradyCodeTest\Input\ReferenceData.xml";
        }
     
        [Theory]
        [InlineData("ValueFactor", "Low", 0.265)]
        [InlineData("ValueFactor", "Medium", 0.696)]
        [InlineData("ValueFactor", "High", 0.946)]
        public void GetReferenceData_ShouldGetValueFactors(string factor, string factorLevel, decimal expectedFactorValue)
        {
            //Arrange                         

            //Act 
            var actualResult = ReferenceDataHelper.GetReferenceData(factor, factorLevel);

            //Assert
            Assert.Equal(expectedFactorValue, actualResult);
        }

        [Theory]
        [InlineData("EmissionsFactor", "Low", 0.312)]
        [InlineData("EmissionsFactor", "Medium", 0.562)]
        [InlineData("EmissionsFactor", "High", 0.812)]
        public void GetReferenceData_ShouldGetEmissionsFactorLowValue(string factor, string factorLevel, decimal expectedFactorValue)
        {
            //Arrange
            
            //Act 
            var actualResult = ReferenceDataHelper.GetReferenceData(factor, factorLevel);

            Assert.Equal(expectedFactorValue, actualResult);
        }

    }
}
