using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForm 
{
    public class Post
    {
        private string title;
        private string body;

        public string Title { get => title; set => title = value; }
        public string Body { get => body; set => body = value; }

        public Post(JObject jObject)
        {
            this.Title = (string)jObject.GetValue("title");
            this.Body = (string)jObject.GetValue("body");
        }

        public Post(string title, string body)
        {
            this.title = title;
            this.body = body;
        }

        public static List<Post> FromJsonArray(JArray postArray)
        {
            List<Post> posts = new List<Post>();
            foreach (JObject jobject in postArray)
            {
                posts.Add(new Post(jobject));

            }

            return posts;
        }
    }
}
