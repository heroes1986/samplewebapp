using System.Web.Mvc;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using NUnit.Framework;
using SampleWebApp.Controllers;
using SampleWebApp.Services;

namespace SampleWebAppTest
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController contoller;
        private IHomeService _service;

        [SetUp]
        public void SetUp()
        {
            _service = A.Fake<IHomeService>(x => x.Strict());
            contoller = new HomeController(_service);
        }

        [Test]
        public void Index_Calls_To_GetIndexName_Returns_Ok()
        {
            // Arrange
            var expected = "Index";
            var whenGetIndexCalled = _service.CallsTo(x => x.GetIndexName());
            whenGetIndexCalled.Returns(expected);

            // Act
            var result = contoller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ViewName);
            whenGetIndexCalled.MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void About_Calls_GetAboutMessage_Returns_Ok()
        {
            // Arrange
            var expected = "About Message";
            var whenGetAboutDescription = _service.CallsTo(x => x.GetAboutDescription());
            whenGetAboutDescription.Returns(expected);

            // Act
            var actual = contoller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.ViewBag);
            Assert.AreEqual(expected, actual.ViewBag.Message);
            whenGetAboutDescription.MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Contact_Calls_GetContactMessage_Returns_Ok()
        {
            // Arrange
            var expected = "Contract Page";
            var whenGetContactCalled = _service.CallsTo(x => x.GetContractMessage());
            whenGetContactCalled.Returns(expected);

            // Act
            var actual = contoller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.ViewBag);
            Assert.AreEqual(expected, actual.ViewBag.Message);
            whenGetContactCalled.MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
