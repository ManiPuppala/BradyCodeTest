using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BradyCodeTest.UnitTest
{
    public  class XMLHelperTest : IClassFixture<FixtureTest>
    {
        private readonly FixtureTest _FixtureTest;

        public XMLHelperTest(FixtureTest fixtureTest)
        {
            _FixtureTest = fixtureTest;
        }        

        [Fact]
        public void test()
        {
            var data = XMLHelper.ParsingXML();
        }
    }
}
