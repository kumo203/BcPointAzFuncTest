using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System.Net;
using System.Text;

namespace BcPointUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async System.Threading.Tasks.Task TestMethod1Async()
        {
            var mockedHttpRequest = new Mock<HttpRequest>();
            mockedHttpRequest.Setup(x => x.Query["name"]).Returns("abc");
            mockedHttpRequest.Setup(x => x.Body).Returns(() =>new MemoryStream());
            var ret = await Function1.Run(mockedHttpRequest.Object, new Mock<ILogger>().Object);
            Assert.AreEqual(((OkObjectResult)ret).StatusCode, 200);
        }
    }
}
