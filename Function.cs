using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace CFN_CustomResource
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void FunctionHandler(JObject input, ILambdaContext context)
        {
            LambdaLogger.Log($"Received input as {input.ToString()}");

            var request = input.ToObject<cfnRequest>();
            var response = new cfnResponse();
            //build all the common responses from the request
            response.StackId = request.stackId;
            response.RequestId = request.requestId;
            response.LogicalResourceId = request.logicalResourceId;
            response.NoEcho = false;
            response.PhysicalResourceId = "My_custom_physical_resource_id";
            response.Reason = "See CloudWatch logs for detail";

            // Sample - gather custom properties from the CloudFormation custom resource
            var resourceProperties = request.resourceProperties.ToObject<ResourceProperties>();
            var awsregion = resourceProperties.Region;
            var serviceToken = resourceProperties.ServiceToken;

            switch (request.resourceType.ToLower())
            {
                case "create":
                    LambdaLogger.Log("Received Create request");
                    // Sample: do some stuff, then set the response.Status field
                    response.Status="SUCCESS";
                    break;
                case "delete":
                    LambdaLogger.Log("Received Create request");
                    response.Status="SUCCESS";
                    break;
                case "update":
                    LambdaLogger.Log("Received Create request");
                    response.Status="SUCCESS";
                    break;
            }
            
            LambdaLogger.Log($"Uploading response to {request.responseUrl} ");
            Uploader.UploadResponse(request.responseUrl,response);
            LambdaLogger.Log("Finished");
            
            
            }
    }
}
