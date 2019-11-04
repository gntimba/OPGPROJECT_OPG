using OPGPROJECT_OPG.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace OPGPROJECT_OPG.Controllers
{
    public class MobileController : ApiController
    {

        private Context db = new Context();
        // GET api/<controller>
        public IEnumerable<Child> Get()
        {
            return db.Children.ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [Route("api/child")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostUserImage()
        {
            String baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                var httpRequest = HttpContext.Current.Request;

                //foreach (var key in httpRequest.Form.AllKeys)
                //{
                //    foreach (var val in httpRequest.Form.GetValues(key))
                //    {
                //        Trace.WriteLine(string.Format("{0}: {1}", key, val));
                //    }
                //}

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {

                            //  YourModelProperty.imageurl = userInfo.email_id + extension;
                            //  where you want to attach your imageurl

                            //if needed write the code to update the table

                            var filePath = HttpContext.Current.Server.MapPath("~/images/" + postedFile.FileName);
                            //Userimage myfolder name where i want to save my image
                            postedFile.SaveAs(filePath);

                        }
                    }
                    //  httpRequest.Form.GetValues(key)
                    Gender gender = (Gender)Enum.Parse(typeof(Gender), httpRequest.Form[3], true);
                    var ch = new Child
                    {
                        Name = httpRequest.Form[0],
                        Surname = httpRequest.Form[1],
                        userID = Int32.Parse(httpRequest.Form[4]),
                        DateOfBirth = DateTime.Parse(httpRequest.Form[2]),
                        Gender = gender,
                        imageUrl = baseUrl + "/images/" + postedFile.FileName
                    };
                    db.Children.Add(ch);
                    db.SaveChangesAsync();

                    var message1 = string.Format("Image Updated Successfully.");
                    return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
                }
                var res = string.Format("Please Upload a image.");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format(ex.ToString());
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
        }


        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}