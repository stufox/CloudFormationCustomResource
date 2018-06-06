using Newtonsoft.Json.Linq;

// Holds the classes used for CloudFormation Requests, Reponses, and Custom data
namespace CFN_CustomResource
{
            public class cfnRequest
            {
            public string requestType {get;set;}
            public string responseUrl {get;set;}
            public string stackId {get;set;}
            public string requestId {get;set;}
            public string resourceType {get;set;}
            public string logicalResourceId {get;set;}
            public string physicalResourceId {get;set;}
            public JObject resourceProperties {get;set;}
            public string oldResourceProperties {get;set;}

        }
        public class ResourceProperties
        {
            //Note that ServiceToken is the only mandatory field for this, but you can pass whatever you like from the CFN template
            public string ServiceToken {get;set;}
            public string Region {get;set;}
        

        }
        public class cfnResponse
        {
            public string Status {get;set;}
            public string Reason {get;set;}
            public string PhysicalResourceId {get;set;}
            public string StackId {get;set;}
            public string RequestId {get;set;}
            public string LogicalResourceId {get;set;}
            public bool NoEcho {get;set;}
            
            // Data field is entirely optional
            // public string data {get;set;}

        }
}