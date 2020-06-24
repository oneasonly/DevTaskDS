using Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    public class BaseTypeTransformsServiceTests
    {
        #region ReverseString
        [TestCase("korova", ExpectedResult = "avorok")]
        [TestCase("salas", ExpectedResult = "salas")]
        [TestCase("", ExpectedResult = "")]
        [TestCase(" ", ExpectedResult = " ")]
        [TestCase("r", ExpectedResult = "r")]
        [TestCase("ss", ExpectedResult = "ss")]
        [TestCase("salaa", ExpectedResult = "aalas")]
        [TestCase("aalas", ExpectedResult = "salaa")]
        [TestCase("tt ", ExpectedResult = " tt")]
        [TestCase(" tt", ExpectedResult = "tt ")]
        [TestCase(" tt ", ExpectedResult = " tt ")]
        public string ReverseStringTest(string input)
        {
            return new BaseTypeTransformsService().ReverseString(input);
        }

        [TestCase(null, typeof(ArgumentNullException))]
        public void ReverseStringThrowTest(string input, Type expectedException)
        {
            var sut = new BaseTypeTransformsService();
            Assert.Throws(expectedException, () => sut.ReverseString(input));
        }
        #endregion

        #region IsPalindrome
        [TestCase("korova", ExpectedResult = false)]
        [TestCase("salas", ExpectedResult = true)]
        [TestCase(" ", ExpectedResult = true)]
        [TestCase("r", ExpectedResult = true)]
        [TestCase("ss", ExpectedResult = true)]
        [TestCase("salaa", ExpectedResult = false)]
        [TestCase("aalas", ExpectedResult = false)]
        public bool IsPalindromeTest(string input)
        {
            return new BaseTypeTransformsService().IsPalindrome(input);
        }

        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        public void IsPalindromeThrowTest(string input, Type expectedException)
        {
            var sut = new BaseTypeTransformsService();
            Assert.Throws(expectedException, () => sut.IsPalindrome(input));
        }
        #endregion

        #region MissingElements
        [TestCase(4, 6, 9, ExpectedResult = new int[] { 5, 7, 8 } )]
        [TestCase(2, 3, 4, ExpectedResult = new int[] {} )]
        [TestCase(1, 3, 4, ExpectedResult = new int[] { 2 })]
        [TestCase(int.MinValue, int.MinValue+2
            , ExpectedResult = new int[] { int.MinValue + 1 })]
        public IEnumerable<int> MissingElementsTest(params int[] arr)
        {
            return new BaseTypeTransformsService().MissingElements(arr);
        }

        [TestCase(null, typeof(ArgumentNullException) )]
        [TestCase(new int[] { 6, 4 }, typeof(ArgumentException) )]
        [TestCase(new int[] { 6, 5 }, typeof(ArgumentException) )]
        [TestCase(new int[] { 6, 6 }, typeof(ArgumentException) )]
        public void MissingElementsThrowTest(int[] arr, Type expectedException)
        {
            var sut = new BaseTypeTransformsService();
            Assert.Throws(expectedException, () => sut.MissingElements(arr));
        }
        #endregion
    }
}