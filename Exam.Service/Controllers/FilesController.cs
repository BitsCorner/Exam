using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Exam.Service.Controllers
{
    public class FilesController : ApiController
    {
        [HttpPost] 
        public async Task<HttpResponseMessage> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
 
            var provider = GetMultipartProvider();
            var result = await Request.Content.ReadAsMultipartAsync(provider);
 
            // On upload, files are given a generic name like "BodyPart_26d6abe1-3ae1-416a-9429-b35f15e6e5d5"
            // so this is how you can get the original file name
            var originalFileName = GetDeserializedFileName(result.FileData.First());
 
            // uploadedFileInfo object will give you some additional stuff like file length,
            // creation time, directory name, a few filesystem methods etc..
            //TODO: Get the extension and set in the stored file
            var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);
 
            // Remove this line as well as GetFormData method if you're not
            // DO I NEED THIS? Sending files and Form together??
            // sending any form data with your upload request
            // var fileUploadObj = GetFormData<UploadDataModel>(result);
 
            // Through the request response you can return an object to the Angular controller
            // You will be able to access this in the .success callback through its data attribute
            // If you want to send something to the .error callback, use the HttpStatusCode.BadRequest instead
            var returnData = uploadedFileInfo.Name;
            return this.Request.CreateResponse(HttpStatusCode.OK, new { returnData });
        }
 
        //TODO: Move thses private methods to a seperate Utility class
        private MultipartFormDataStreamProvider GetMultipartProvider()
        {
            var uploadFolder = ConfigurationManager.AppSettings["FileUploadPath"]; 
            var root = HttpContext.Current.Server.MapPath(uploadFolder);
            Directory.CreateDirectory(root);
            return new MultipartFormDataStreamProvider(root);
        }
 
        private object GetFormData<T>(MultipartFormDataStreamProvider result)
        {
            if (result.FormData.HasKeys())
            {
                var unescapedFormData = Uri.UnescapeDataString(result.FormData
                    .GetValues(0).FirstOrDefault() ?? String.Empty);
                if (!String.IsNullOrEmpty(unescapedFormData))
                    return JsonConvert.DeserializeObject<T>(unescapedFormData);
            }
 
            return null;
        }
 
        private string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }
 
        public string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }
    }

}