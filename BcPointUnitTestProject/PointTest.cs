using AzFuncMock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BcPointUnitTestProject
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public async System.Threading.Tasks.Task PutPointTests()
        {
            try
            {
                var mockedHttpRequest = new Mock<HttpRequest>();
                //mockedHttpRequest.Setup(x => x.Query["name"]).Returns("abc");
                //mockedHttpRequest.Setup(x => x.Body).Returns(() => new MemoryStream());
                var ret = await Point.Put(req: mockedHttpRequest.Object, log: new Mock<ILogger>().Object, id: "NotFound", operation: "add");
                Assert.AreEqual(((ObjectResult)ret).StatusCode, 404);
                ret = await Point.Put(mockedHttpRequest.Object, new Mock<ILogger>().Object, id: "BadParam", operation: "add");
                Assert.AreEqual(((ObjectResult)ret).StatusCode, 400);
                ret = await Point.Put(mockedHttpRequest.Object, new Mock<ILogger>().Object, id: "Added", operation: "add");
                Assert.AreEqual(((ObjectResult)ret).StatusCode, 202);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}