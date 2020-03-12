using NUnit.Framework;
using TaxFileNumberValidationApp;

namespace TaxFileNumberValidationWebApiUnitTests
{
    public class ValidationServiceTests
    {
        private ValidationService _validationService;

        [SetUp]
        public void Setup()
        {
            _validationService = new ValidationService();
        }

        [TestCase("123")] // too short
        [TestCase("12345678")] // not valid tfn
        [TestCase("12345678999")] // too long
        [TestCase("123asd'[-")] // contains characters
        public void ValidateTFN_Invalid(string tfn)
        {
            // Arrange

            // Act
            var results =_validationService.ValidateTFN(tfn);

            // Assert
            Assert.AreEqual(results, false);
        }

        [TestCase("85655805")] // 8 numbers in length
        [TestCase("648188480")] // 9 numbers in length
        public void ValidateTFN_Valid(string tfn)
        {
            // Arrange

            // Act
            var results = _validationService.ValidateTFN(tfn);

            // Assert
            Assert.AreEqual(results, true);
        }
    }
}