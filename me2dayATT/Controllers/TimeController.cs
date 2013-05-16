using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using R.Common.Util;
using me2dayATT.Models;
using System.Configuration;
using System.Text.RegularExpressions;

namespace me2dayATT.Controllers
{
    public class TimeController : BaseController
    {
        #region Index() : main login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            try
            {
                api.GetAuth();
            }
            catch (Me2Exception ex)
            {
                ViewData["exceptionData"] = ex;
            }
            return View();
        }
        #endregion

        #region Post() : post me2day
        public ActionResult Post()
        {
            int year = Request["year"].ToInt32(DateTime.Now.AddYears(-1).Year);
            ViewData["year"] = year;
            api.UserID = Session["user_id"].FixNull();

            string outputString = PastString(api.UserID, year);
            ViewData["outputString"] = outputString;

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Post(FormCollection frm)
        {
            int year = Request["year"].ToInt32(DateTime.Now.AddYears(-1).Year);
            string reqTag = Request["tag"].FixNull();

            ViewData["year"] = year;
            api.UserID = Session["user_id"].FixNull();
            api.ApiKey = Session["user_key"].FixNull();
            try
            {
                string outputString = PastString(api.UserID, year);
                ViewData["text"] = outputString;
                string tag = string.Format("me2ATT {0} {1}", year, reqTag.HtmlSpecialChars());
                ViewData["tag"] = tag;
                if (!string.IsNullOrEmpty(outputString))
                {
                    
                    //string pattern = "\"([^\"]*)\":(https?://[^\\s]*)";
                    //if (Regex.Match(outputString, pattern, RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace).Success)
                    //{
                        
                    //}


                    var posts = api.createPost(api.UserID, outputString, new List<string>(tag.Split(new char[] { ' ' })), 1);
                    if (posts != null && !string.IsNullOrEmpty(posts.plink))
                    {
                        return Redirect(posts.plink);
                    }
                }
                else
                    return RedirectToAction("Index");
            }
            catch (Me2Exception ex)
            {
                ViewData["exceptionData"] = ex;
            }
            return View();
        }
        #endregion

        #region GetPost() 
        public ActionResult GetPost(int year)
        {
            api.UserID = Session["user_id"].FixNull();
            
            string outputString = PastString(api.UserID, year);
            ViewData["text"] = outputString;
            return View();
        }
        #endregion

        #region [NonAction] PastString()
        [NonAction]
        public string PastString(string userid, int year)
        {
            List<Post> list = api.getPosts(userid, year);
            string outputString = string.Empty;

            if (list != null && list.Count > 0)
            {
                int num = 1;
                foreach (Post post in list)
                {
                    string strText = string.Empty;
                    string text = post.textBody.FixNull();
                    if (text.Length > 0 && num <= 15)
                    {
                        int iCut = list.Count > 12 ? 4 : list.Count > 6 ? 8 :16;
                        if (text.GetByteLen() > iCut)
                            strText = text.GetCuttedString(iCut, "..");
                        else if (text.Contains(' '))
                            strText = text.Split(' ')[0] + "..";
                        else
                            strText = text;

                        outputString += string.Format(@" ""#{0}"":{2}{3}{1} ", num, strText, post.permalink, "  ");
                        num++;
                    }
                    if (num > 15) break;
                }
                return string.Format("[그때 그 미투] \"▲\":{0}  ", ConfigurationManager.AppSettings["ServiceDomain"].FixNull()) + outputString;
            }
            return string.Empty;
            
        }
        #endregion

        #region Auth() : me2api return page
        public ActionResult Auth()
        {
            bool result = Request["result"].ToBoolean();
            string user_id = Request["user_id"].FixNull();
            string user_key = Request["user_key"].FixNull();
            if (result)
            {
                Session["user_key"] = user_key;
                Session["user_id"] = user_id;
                return RedirectToAction("Post");
            }
            else
                return RedirectToAction("Index");
            //?token=97284bfeef3bb3fb1ca3c27b725c2426&result=true&user_id=ssemi&user_key=65353843

            // db save???

            
        }
        #endregion
    }
}
