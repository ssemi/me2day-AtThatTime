using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using me2dayATT;
using me2dayATT.Controllers;

namespace me2dayATT.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // 정렬
            TimeController controller = new TimeController();

            // 동작
            ViewResult result = controller.Index() as ViewResult;

            // 어설션
            Assert.AreEqual("ASP.NET MVC 시작", result.ViewBag.Message);
        }

    }
}
