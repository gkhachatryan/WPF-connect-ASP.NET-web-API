using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIforWPF.Controllers
{
    public class DirectoryController : ApiController
    {
        // GET api/directory
        public IEnumerable<string> GetAllFiles()
        {
             DirectoryInfo directory = new DirectoryInfo(@"E:\TestDirectory");
            var files = directory.GetFiles().Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden)).Select(f => f.Name).ToArray();
            return files;

            //Bad prictice

            //public HttpResponseMessage Get(string name)
            //{
            //    string path = Path.Combine(pathCustom, name);
            //    StreamReader sr = File.OpenText(path);
            //    string textline = sr.ReadLine();
            //    sr.Close();
            //    return textline;
            //    HttpResponseMessage res = new HttpResponseMessage();
            //    res.Content = new StringContent(textline);
            //    return res;

            //}
        }

        // GET api/directory/5
        public string Get(string name)
        {
           // DirectoryInfo directory = new DirectoryInfo(@"E:\TestDirectory");
            string path = Path.Combine(@"E:\TestDirectory", name); 
            StreamReader sr = File.OpenText(path);
            string textline = sr.ReadLine();
            sr.Close();
            return textline;
                   
        }

        // POST api/directory
        public void Post([FromBody]string value)
        {
        }

        // PUT api/directory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/directory/5
        public void Delete(string name)
        {
            string fileName = Path.Combine(@"E:\TestDirectory", name);

            string[] Files = Directory.GetFiles(@"E:\TestDirectory");

            foreach (string file in Files)
            {
                if (file.ToUpper().Contains(fileName.ToUpper()))
                {
                    File.Delete(file);
                }
            }
        }
    }
}
