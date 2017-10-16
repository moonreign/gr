using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GRLib.Test
{
    [TestClass]
    public class ParserFixture
    {
        [DataTestMethod]

        // types of delimiters
        [DataRow("doe john male red 8/23/1982", "doe", "john", "male", "red", 8, 23, 1982)]
        [DataRow("doe|john|male|red|8/23/1982", "doe", "john", "male", "red", 8, 23, 1982)]
        [DataRow("doe,john,male,red,8/23/1982", "doe", "john", "male", "red", 8, 23, 1982)]

        //should ignore spaces accordingly
        [DataRow("doe  john   male  red  8/23/1982", "doe", "john", "male", "red", 8, 23, 1982)]
        [DataRow("doe | john  | male | red| 8/23/1982", "doe", "john", "male", "red", 8, 23, 1982)]
        [DataRow("doe  , john ,male  ,  red , 8/23/1982", "doe", "john", "male", "red", 8, 23, 1982)]

        //empty returns default Result object
        [DataRow("", null, null, null, null, 1, 1, 1)]

        public void LoadRow_WhenCalled_ParseCorrectly(string row,
            string expectedLast, string expectedFirst, string expectedGender, string expectedColor,
            int expectedMonth, int expectedDay, int expectedYear)
        {
            var parser = new Parser();

            var record = parser.LoadRow(row);

            Assert.AreEqual(record.LastName, expectedLast);
            Assert.AreEqual(record.FirstName, expectedFirst);
            Assert.AreEqual(record.Gender, expectedGender);
            Assert.AreEqual(record.FavouriteColor, expectedColor);
            Assert.AreEqual(record.DOB.Day, expectedDay);
            Assert.AreEqual(record.DOB.Month, expectedMonth);
            Assert.AreEqual(record.DOB.Year, expectedYear);
        }
    }
}
