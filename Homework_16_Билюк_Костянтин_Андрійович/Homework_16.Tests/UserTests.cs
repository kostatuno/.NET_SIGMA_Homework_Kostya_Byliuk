using Homework_16.Models;
using System.Diagnostics;

namespace Homework_16.Tests
{
    [TestClass]
    public class UserTests
    {
        User user { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            user = new User();
        }

        [TestMethod]
        [DataRow("andriyparazhan201@gmail.com")]
        [DataRow("uzvid91@ukr.net")]
        [DataRow("golanggogo@gmail.com")]
        [DataRow("billyheydude00@gmail.com")]
        [DataRow("alinavasulivna41@ukr.net")]
        public void EmailValidation_InitializeUser_Success(string email)
        {
            user.Email = email;
            Assert.AreEqual(user.Email, email);
        }


        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        [DataRow("assetap@ple.com")]
        [DataRow("golang.@com")]
        [DataRow("busdfg@dotcom")]
        [DataRow("norwaynononon@pointcom")]
        [DataRow("balushya@komua")]
        public void EmailValidation_InitializeUser_NonSuccess(string email)
        {
            user.Email = email;
            Assert.Fail();
        }
    }
}