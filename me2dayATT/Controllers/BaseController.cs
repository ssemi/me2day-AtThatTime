using System;
using System.Web.Mvc;
using me2dayATT.Models;
using System.Configuration;
using R.Common.Util;

namespace me2dayATT.Controllers
{
    public class BaseController : Controller
    {
        //private static readonly ILog _webLog = LogManager.GetLogger("WebLog");
        //protected ILog webLog { get { return _webLog; } }

        public static Me2API api;

        #region ControllersBase() : Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="ControllerBase"/> class.
		/// </summary>
		public BaseController() {
            api = new Me2API();
            api.AppKey = ConfigurationManager.AppSettings["ApplicationKey"].FixNull();
		}
		#endregion

		#region IDisposable Members
		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing) {
			base.Dispose(disposing);
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="ControllerBase"/> is reclaimed by garbage collection.
		/// </summary>
        ~BaseController() {
			Dispose(false);
		}
		#endregion
        
        #region OnException() : Global controller exception handler
        /// <summary>Global controller exception handler</summary>
        /// <param name="ctx">The exception context.</param>
        protected override void OnException(ExceptionContext ctx) {
            string sLogMsg = string.Empty;
            Exception ex = Server.GetLastError();

            if (ctx == null) {
                // Bail if we can't do anything; app will crash.
                return;
            } else {
                // since we're handling this, log to elmah
                ex = ctx.Exception ?? new Exception("No further information exists.");
				
                sLogMsg += "Controller: " + ctx.Controller.GetType().ToString() + Environment.NewLine;
                //sLogMsg += "Method: " + ctx.Exception.Data + Environment.NewLine;
                sLogMsg += "--------------------------------------------------------------------------------" + Environment.NewLine;
                sLogMsg += "Route Values: " + Environment.NewLine;
                //foreach (string key in (RouteData.Values.) {
                //    sLogMsg += "\t" + key + ": " + RouteData.Values[key] + Environment.NewLine;
                //}
                foreach (object item in this.RouteData.Values) {
                    sLogMsg += "\t" + item.ToString() + Environment.NewLine;
                }
                sLogMsg += "--------------------------------------------------------------------------------" + Environment.NewLine;
                sLogMsg += "Exception.Data: " + Environment.NewLine;
                foreach (object key in ex.Data.Keys) {
                    sLogMsg += "\t" + key.ToString() + ": " + ex.Data[key] + Environment.NewLine;

                }
                sLogMsg += "--------------------------------------------------------------------------------" + Environment.NewLine;
                sLogMsg += "Exception Contents: " + Environment.NewLine;
                sLogMsg += ex.ToString() + Environment.NewLine;
                sLogMsg += "--------------------------------------------------------------------------------" + Environment.NewLine;
                if (ex.InnerException != null) {
                    sLogMsg += "Inner Exception Contents: " + Environment.NewLine;
                    sLogMsg += ex.InnerException.ToString() + Environment.NewLine;
                    sLogMsg += "--------------------------------------------------------------------------------" + Environment.NewLine;
                }
                //sLogMsg += "--------------------------------------------------------------------------------" + Environment.NewLine;

                // DB 연결 가능 여부 확인
                //try {
                //    db = new BigMacDB();
                //    CanDBConnect = db.CanConnection;
                //} finally {
                //    db = null;
                //}
				
                // 오류내용 기록
                //try {
                //    if (CanDBConnect) {
                //        LogManager.LogWrite(sLogMsg, "GlobalException", false);
                //    } else {
                //        LogManager.LogWrite(sLogMsg, "DBConnectionException", false);
                //    }
                //} catch {
                //}

                Session["ExceptionData"] = (Request.IsLocal) ? sLogMsg : ex.Message;
				
                //ctx.ExceptionHandled = true;
                //ctx.Result = CanDBConnect ? (RedirectToAction("Error") as ActionResult) : (Redirect("~/DBConnectionError.aspx".ResolveUrl()) as ActionResult);
            }
        }
        #endregion
    }
}
