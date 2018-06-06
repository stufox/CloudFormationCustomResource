# AWS Lambda CloudFormation C# Custom Resource Project

This starter project consists of:
* Function.cs - class file containing a class with a single function handler method
* aws-lambda-tools-defaults.json - default argument settings for use with Visual Studio and command line deployment tools for AWS
* Classes.cs - class file containing the custom objects for CloudFormation requests, responses & custom data
* Uploader.cs - class file containing the method to upload response data to the pre-signed S3 URL for custom resource responses
* CustomResource.yml - a sample CloudFormation file with the required parameters and resources to deploy your custom stack



## Deploying:


Once you have edited your function you can use the following command lines to build and deploy your function to AWS Lambda from the command line (these examples assume the project name is *EmptyFunction*):

Restore dependencies
```
    dotnet restore
```

Package function into a deployment package
```
    dotnet lambda package --name YourPackageName.zip
```

You'll need to upload the zip file to an S3 bucket, and then provide the bucket name and the file name (including .zip) as input parameters to the CloudFormation deployment.

Note to real developers: I'm not a developer, so please be kind.
