using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace BcPointUnitTestProject
{
    [TestClass]
    public class PostAccountTest
    {
        [TestMethod]
        public async System.Threading.Tasks.Task PostAccountTests()
        {
            try
            {
                var mockedHttpRequest = new Mock<HttpRequest>();
                //mockedHttpRequest.Setup(x => x.Query["name"]).Returns("abc");
                //mockedHttpRequest.Setup(x => x.Body).Returns(() => new MemoryStream());
                var ret = await Account.Post(mockedHttpRequest.Object, new Mock<ILogger>().Object, id: "Conflict");
                Assert.AreEqual(((ObjectResult)ret).StatusCode, 409);
                ret = await Account.Post(mockedHttpRequest.Object, new Mock<ILogger>().Object, id: "BadParam");
                Assert.AreEqual(((ObjectResult)ret).StatusCode, 400);
                ret = await Account.Post(mockedHttpRequest.Object, new Mock<ILogger>().Object, id: "Created");
                Assert.AreEqual(((ObjectResult)ret).StatusCode, 201);
            }catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task DeleteAccountTests()
        {
            try
            {
                var mockedHttpRequest = new Mock<HttpRequest>();
                //mockedHttpRequest.Setup(x => x.Query["name"]).Returns("abc");
                //mockedHttpRequest.Setup(x => x.Body).Returns(() => new MemoryStream());
                var ret = await Account.Delete(mockedHttpRequest.Object, new Mock<ILogger>().Object, id: "NotFound");
                Assert.AreEqual(((ObjectResult)ret).StatusCode, 409);
                ret = await Account.Delete(mockedHttpRequest.Object, new Mock<ILogger>().Object, id: "BadParam");
                Assert.AreEqual(((ObjectResult)ret).StatusCode, 400);
                ret = await Account.Delete(mockedHttpRequest.Object, new Mock<ILogger>().Object, id: "Deleted");
                Assert.AreEqual(((ObjectResult)ret).StatusCode, 201);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
