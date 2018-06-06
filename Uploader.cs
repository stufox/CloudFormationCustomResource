using System.Net;
using Newtonsoft.Json;
using System.Text;
using Amazon.Lambda.Core;
using System.IO;

namespace CFN_CustomResource
{
    public class Uploader 
    {
        // Class to upload response JSON to the pre-signed URL
        public static void UploadResponse(string url, cfnResponse response)
        {
            
            string json = JsonConvert.SerializeObject(response);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            LambdaLogger.Log($"trying to upload json {json}");

            HttpWebRequest httpRequest = WebRequest.Create(url) as HttpWebRequest;
            httpRequest.Method = "PUT";
            //If ContentType is set to anything but "" your upload will fail
            httpRequest.ContentType = "";
            httpRequest.ContentLength = byteArray.Length;
            
            LambdaLogger.Log($"Starting upload of {byteArray.Length}");
            using (Stream datastream = httpRequest.GetRequestStream())
            {
                
                datastream.Write(byteArray,0,byteArray.Length);

            }
            HttpWebResponse result = httpRequest.GetResponse() as HttpWebResponse;

            LambdaLogger.Log($"Result of upload is {result.StatusCode}");

        }
}
}
