using System;
using System.Collections.Generic;

namespace me2dayATT.Models
{
    public class Post
    {
        public string scope { get; set; }
        public string post_id { get; set; }
        public string permalink { get; set; }
        public string plink { get; set; }
        public string body { get; set; }
        public string textBody { get; set; }
        public string kind { get; set; }
        public string icon { get; set; }
        public string tagText { get; set; }
        public List<Tag> Tags { get; set; }
        public string me2dayPage { get; set; }
        public string pubDate { get; set; }
        public int commentsCount { get; set; }
        public int metooCount { get; set; }
        public bool commentClosed { get; set; }
        public string contentType { get; set; }
        public string iconUrl { get; set; }
        public string callbackUrl { get; set; }
        public Person author { get; set; }
        public Location location { get; set; }
        public Media Media { get; set; }
        public string fromapp { get; set; }

        public string pingback_to { get; set; }
        public string domain { get; set; }
        public string identifier { get; set; }
        public string metoo_at { get; set; }

        public Post()
        {
            Tags = new List<Tag>();
        }
    }

    public class Person
    {
        public string id { get; set; }
        public string nickname { get; set; }
        public string face { get; set; }
        public string me2dayHome { get; set; }
        public string homepage { get; set; }
        public string realname { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }

    public class Tag
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Media
    {
        public string type { get; set; }
        public string provider { get; set; }
        public string photoUrl { get; set; }
        public string photoId { get; set; }
        public string permalink { get; set; }
    }


    public class Me2Error
    {
        /// <summary>
        /// me2DAY Defined Error code
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 에러 메세지
        /// </summary>
        public String Message { get; set; }
        /// <summary>
        /// 에러 설명
        /// </summary>
        public String Description { get; set; }
    }

    public class Me2Exception : Exception
    {
        /// <summary>
        /// me2DAY Error
        /// </summary>
        public Me2Error Error { get; set; }

        public Me2Exception(Me2Error error)
        {
            Error = error;
        }
    }

    public class Comment
    {
        public string commentId { get; set; }
        public string body { get; set; }
        public DateTime pubDate { get; set; }
        public Person Author { get; set; }
    }
}