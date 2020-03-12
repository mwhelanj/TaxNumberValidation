using NUnit.Framework;
using TaxFileNumberValidationApp;
using NSubstitute;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace TaxFileNumberValidationAppUnitTests
{
    public class ValidateTFNControllerTest
    {

        private IValidationService _validationService;
        private ILogger<ValidateTFNController> _Logging;
        private ValidateTFNController _controller;

        [SetUp]
        public void Setup()
        {
            // to allow mocking of the service
            _validationService = Substitute.For<IValidationService>();
            _Logging = Substitute.For<ILogger<ValidateTFNController>>();
            _controller = new ValidateTFNController(_Logging, _validationService);
        }


        [TestCase("85655805")] // 8 numbers in length
        [TestCase("648188480")] // 9 numbers in length
        public void ValidateTFN_Valid(string tfn)
        {
            // Arrange
            _validationService.ValidateTFN(Arg.Any<string>()).Returns(true);

            // Act
            var okResult = _controller.Get(tfn);


            // Assert
            var okObjectResult = okResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);

            Assert.AreEqual(okObjectResult.StatusCode, 200);

            Assert.AreEqual(okObjectResult.Value, true);
        }

        [TestCase("123")] // too short
        [TestCase("12345678")] // not valid tfn
        [TestCase("12345678999")] // too long
        [TestCase("123asd'[-")] // contains characters
        public void ValidateTFN_Invalid(string tfn)
        {
            // Arrange
            _validationService.ValidateTFN(Arg.Any<string>()).Returns(false);

            // Act
            var okResult = _controller.Get(tfn);


            // Assert
            // Assert
            var okObjectResult = okResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);

            Assert.AreEqual(okObjectResult.StatusCode, 200);

            Assert.AreEqual(okObjectResult.Value,false);
        }
    }
}
