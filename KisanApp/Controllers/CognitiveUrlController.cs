using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    class det
    {
        public string url { get; set; }
    }
    
    public class CognitiveUrlController : ApiController
    {
        const string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v2.0/Prediction/f3e17865-ad01-45b1-8974-730649c79634/url?iterationId=751aee28-cb37-47d2-95a3-11d2a08dd8a9";

        private readonly RestClient _client=new RestClient(url);
        // POST api/values
        public PredictionResult Post([FromBody]string imageUrl)
        {
            PredictionResult result;
            var model = new det { url = imageUrl };
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(model);
            _client.AddDefaultHeader("Prediction-Key", "9822f33b8f5941d9acfa3a842285e6f9");
            var response = _client.Execute<PredictionResult>(request).Data;
            return response;
        }


        // POST api/values
        //public async void Post([FromBody]byte[] image)
        //{
        //    var client = new HttpClient();

        //    // Request headers - replace this example key with your valid subscription key.
        //    client.DefaultRequestHeaders.Add("Prediction-Key", "9822f33b8f5941d9acfa3a842285e6f9");

        //    // Prediction URL - replace this example URL with your valid prediction URL.
        //    string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v2.0/Prediction/f3e17865-ad01-45b1-8974-730649c79634/url?iterationId=751aee28-cb37-47d2-95a3-11d2a08dd8a9";

        //    HttpResponseMessage response;

        //    // Request body. Try this sample with a locally stored image.
            

        //    using (var content = new ByteArrayContent(image))
        //    {
        //        content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        //        response = await client.PostAsync(url, content);
        //        Console.WriteLine(await response.Content.ReadAsStringAsync());
        //    }
        //}

        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }
       
    }
}
