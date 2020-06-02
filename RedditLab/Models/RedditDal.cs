using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RedditLab.Models
{
    public class RedditDal
    {
        public string GetAPIString(string subreddit)
        {
            string url = $"https://www.reddit.com/r/{subreddit}/.json";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string output = rd.ReadToEnd();

            return output;


        }

        public Post GetPost()
        {
            string output = GetAPIString("aww");

            JObject json = JObject.Parse(output);
            List<JToken> modelData = json["data"]["children"].ToList();

            Post rp = JsonConvert.DeserializeObject<Post>(modelData[0]["data"].ToString());
            return rp;
        }
    }
}
