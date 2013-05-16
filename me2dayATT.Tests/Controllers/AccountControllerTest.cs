using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using me2dayATT;
using me2dayATT.Controllers;
using me2dayATT.Models;
using System.Web.Script.Serialization;

namespace me2dayATT.Tests.Controllers
{

    [TestClass]
    public class AccountControllerTest
    {

       
        //[TestMethod]
        //public void ChangePassword_Get_ReturnsView()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();

        //    // 동작
        //    ActionResult result = controller.ChangePassword();

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //    Assert.AreEqual(10, ((ViewResult)result).ViewData["PasswordLength"]);
        //}

        //[TestMethod]
        //public void ChangePassword_Post_ReturnsRedirectOnSuccess()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();
        //    ChangePasswordModel model = new ChangePasswordModel()
        //    {
        //        OldPassword = "goodOldPassword",
        //        NewPassword = "goodNewPassword",
        //        ConfirmPassword = "goodNewPassword"
        //    };

        //    // 동작
        //    ActionResult result = controller.ChangePassword(model);

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        //    RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
        //    Assert.AreEqual("ChangePasswordSuccess", redirectResult.RouteValues["action"]);
        //}

        //[TestMethod]
        //public void ChangePassword_Post_ReturnsViewIfChangePasswordFails()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();
        //    ChangePasswordModel model = new ChangePasswordModel()
        //    {
        //        OldPassword = "goodOldPassword",
        //        NewPassword = "badNewPassword",
        //        ConfirmPassword = "badNewPassword"
        //    };

        //    // 동작
        //    ActionResult result = controller.ChangePassword(model);

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //    ViewResult viewResult = (ViewResult)result;
        //    Assert.AreEqual(model, viewResult.ViewData.Model);
        //    Assert.AreEqual("현재 암호가 정확하지 않거나 새 암호가 잘못되었습니다.", controller.ModelState[""].Errors[0].ErrorMessage);
        //    Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        //}

        //[TestMethod]
        //public void ChangePassword_Post_ReturnsViewIfModelStateIsInvalid()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();
        //    ChangePasswordModel model = new ChangePasswordModel()
        //    {
        //        OldPassword = "goodOldPassword",
        //        NewPassword = "goodNewPassword",
        //        ConfirmPassword = "goodNewPassword"
        //    };
        //    controller.ModelState.AddModelError("", "더미 오류 메시지입니다.");

        //    // 동작
        //    ActionResult result = controller.ChangePassword(model);

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //    ViewResult viewResult = (ViewResult)result;
        //    Assert.AreEqual(model, viewResult.ViewData.Model);
        //    Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        //}

        //[TestMethod]
        //public void ChangePasswordSuccess_ReturnsView()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();

        //    // 동작
        //    ActionResult result = controller.ChangePasswordSuccess();

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //}

        //[TestMethod]
        //public void LogOff_LogsOutAndRedirects()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();

        //    // 동작
        //    ActionResult result = controller.LogOff();

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        //    RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
        //    Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
        //    Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
        //    Assert.IsTrue(((MockFormsAuthenticationService)controller.FormsService).SignOut_WasCalled);
        //}

        //[TestMethod]
        //public void LogOn_Get_ReturnsView()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();

        //    // 동작
        //    ActionResult result = controller.LogOn();

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //}

        //[TestMethod]
        //public void LogOn_Post_ReturnsRedirectOnSuccess_WithoutReturnUrl()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();
        //    LogOnModel model = new LogOnModel()
        //    {
        //        UserName = "someUser",
        //        Password = "goodPassword",
        //        RememberMe = false
        //    };

        //    // 동작
        //    ActionResult result = controller.LogOn(model, null);

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        //    RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
        //    Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
        //    Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
        //    Assert.IsTrue(((MockFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
        //}

        //[TestMethod]
        //public void LogOn_Post_ReturnsRedirectOnSuccess_WithLocalReturnUrl()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();
        //    LogOnModel model = new LogOnModel()
        //    {
        //        UserName = "someUser",
        //        Password = "goodPassword",
        //        RememberMe = false
        //    };

        //    // 동작
        //    ActionResult result = controller.LogOn(model, "/someUrl");

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(RedirectResult));
        //    RedirectResult redirectResult = (RedirectResult)result;
        //    Assert.AreEqual("/someUrl", redirectResult.Url);
        //    Assert.IsTrue(((MockFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
        //}

        //[TestMethod]
        //public void LogOn_Post_ReturnsRedirectToHomeOnSuccess_WithExternalReturnUrl()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();
        //    LogOnModel model = new LogOnModel()
        //    {
        //        UserName = "someUser",
        //        Password = "goodPassword",
        //        RememberMe = false
        //    };

        //    // 동작
        //    ActionResult result = controller.LogOn(model, "http://malicious.example.net");

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        //    RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
        //    Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
        //    Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
        //    Assert.IsTrue(((MockFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
        //}

        //[TestMethod]
        //public void LogOn_Post_ReturnsViewIfModelStateIsInvalid()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();
        //    LogOnModel model = new LogOnModel()
        //    {
        //        UserName = "someUser",
        //        Password = "goodPassword",
        //        RememberMe = false
        //    };
        //    controller.ModelState.AddModelError("", "더미 오류 메시지입니다.");

        //    // 동작
        //    ActionResult result = controller.LogOn(model, null);

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //    ViewResult viewResult = (ViewResult)result;
        //    Assert.AreEqual(model, viewResult.ViewData.Model);
        //}

        //[TestMethod]
        //public void LogOn_Post_ReturnsViewIfValidateUserFails()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();
        //    LogOnModel model = new LogOnModel()
        //    {
        //        UserName = "someUser",
        //        Password = "badPassword",
        //        RememberMe = false
        //    };

        //    // 동작
        //    ActionResult result = controller.LogOn(model, null);

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //    ViewResult viewResult = (ViewResult)result;
        //    Assert.AreEqual(model, viewResult.ViewData.Model);
        //    Assert.AreEqual("제공한 사용자 이름 또는 암호가 잘못되었습니다.", controller.ModelState[""].Errors[0].ErrorMessage);
        //}

        //[TestMethod]
        //public void Register_Get_ReturnsView()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();

        //    // 동작
        //    ActionResult result = controller.Register();

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //    Assert.AreEqual(10, ((ViewResult)result).ViewData["PasswordLength"]);
        //}

        //[TestMethod]
        //public void Register_Post_ReturnsRedirectOnSuccess()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();
        //    RegisterModel model = new RegisterModel()
        //    {
        //        UserName = "someUser",
        //        Email = "goodEmail",
        //        Password = "goodPassword",
        //        ConfirmPassword = "goodPassword"
        //    };

        //    // 동작
        //    ActionResult result = controller.Register(model);

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        //    RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
        //    Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
        //    Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
        //}

        //[TestMethod]
        //public void Register_Post_ReturnsViewIfRegistrationFails()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();
        //    RegisterModel model = new RegisterModel()
        //    {
        //        UserName = "duplicateUser",
        //        Email = "goodEmail",
        //        Password = "goodPassword",
        //        ConfirmPassword = "goodPassword"
        //    };

        //    // 동작
        //    ActionResult result = controller.Register(model);

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //    ViewResult viewResult = (ViewResult)result;
        //    Assert.AreEqual(model, viewResult.ViewData.Model);
        //    Assert.AreEqual("사용자 이름이 이미 있습니다. 다른 사용자 이름을 입력하십시오.", controller.ModelState[""].Errors[0].ErrorMessage);
        //    Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        //}

        //[TestMethod]
        //public void Register_Post_ReturnsViewIfModelStateIsInvalid()
        //{
        //    // 정렬
        //    AccountController controller = GetAccountController();
        //    RegisterModel model = new RegisterModel()
        //    {
        //        UserName = "someUser",
        //        Email = "goodEmail",
        //        Password = "goodPassword",
        //        ConfirmPassword = "goodPassword"
        //    };
        //    controller.ModelState.AddModelError("", "더미 오류 메시지입니다.");

        //    // 동작
        //    ActionResult result = controller.Register(model);

        //    // 어설션
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //    ViewResult viewResult = (ViewResult)result;
        //    Assert.AreEqual(model, viewResult.ViewData.Model);
        //    Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        //}

        //private static AccountController GetAccountController()
        //{
        //    RequestContext requestContext = new RequestContext(new MockHttpContext(), new RouteData());
        //    AccountController controller = new AccountController()
        //    {
        //        FormsService = new MockFormsAuthenticationService(),
        //        MembershipService = new MockMembershipService(),
        //        Url = new UrlHelper(requestContext),
        //    };
        //    controller.ControllerContext = new ControllerContext()
        //    {
        //        Controller = controller,
        //        RequestContext = requestContext
        //    };
        //    return controller;
        //}

        //private class MockFormsAuthenticationService : IFormsAuthenticationService
        //{
        //    public bool SignIn_WasCalled;
        //    public bool SignOut_WasCalled;

        //    public void SignIn(string userName, bool createPersistentCookie)
        //    {
        //        // 인수가 필요한 인수인지 확인
        //        Assert.AreEqual("someUser", userName);
        //        Assert.IsFalse(createPersistentCookie);

        //        SignIn_WasCalled = true;
        //    }

        //    public void SignOut()
        //    {
        //        SignOut_WasCalled = true;
        //    }
        //}

        //private class MockHttpContext : HttpContextBase
        //{
        //    private readonly IPrincipal _user = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);
        //    private readonly HttpRequestBase _request = new MockHttpRequest();

        //    public override IPrincipal User
        //    {
        //        get
        //        {
        //            return _user;
        //        }
        //        set
        //        {
        //            base.User = value;
        //        }
        //    }

        //    public override HttpRequestBase Request
        //    {
        //        get
        //        {
        //            return _request;
        //        }
        //    }
        //}

        //private class MockHttpRequest : HttpRequestBase
        //{
        //    private readonly Uri _url = new Uri("http://mysite.example.com/");

        //    public override Uri Url
        //    {
        //        get
        //        {
        //            return _url;
        //        }
        //    }
        //}

        //private class MockMembershipService : IMembershipService
        //{
        //    public int MinPasswordLength
        //    {
        //        get { return 10; }
        //    }

        //    public bool ValidateUser(string userName, string password)
        //    {
        //        return (userName == "someUser" && password == "goodPassword");
        //    }

        //    public MembershipCreateStatus CreateUser(string userName, string password, string email)
        //    {
        //        if (userName == "duplicateUser")
        //        {
        //            return MembershipCreateStatus.DuplicateUserName;
        //        }

        //        // 값이 필요한 값인지 확인
        //        Assert.AreEqual("goodPassword", password);
        //        Assert.AreEqual("goodEmail", email);

        //        return MembershipCreateStatus.Success;
        //    }

        //    public bool ChangePassword(string userName, string oldPassword, string newPassword)
        //    {
        //        return (userName == "someUser" && oldPassword == "goodOldPassword" && newPassword == "goodNewPassword");
        //    }
        //}

    }
}
