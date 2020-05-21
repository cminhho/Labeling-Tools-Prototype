
namespace LayoutService.Application.Constants
{
    public class Constants
    {
        // Azure Form Recognizer subscription key and endpoint.
        public const string SubscriptionKey = "2ab6e210d0174561a2cce28d976282ab";
        public const string FormRecognizerEndpoint = "https://tanameformrecognizer.cognitiveservices.azure.com";

        // SAS Url to Azure Blob Storage container; this used for training the custom model
        // For help using SAS see: 
        // https://docs.microsoft.com/en-us/azure/storage/common/storage-dotnet-shared-access-signature-part-1
        public const string TrainingDataUrl = "https://cminhho.blob.core.windows.net/pdf?sv=2019-10-10&ss=bfqt&srt=sco&sp=rwdlacup&se=2020-05-30T02:20:39Z&st=2020-05-03T18:20:39Z&spr=https&sig=84CfSqS%2BjEju4XoJQ1R%2ByYBu7RjyMEx15yb2QhotUzM%3D";

        public const string azureConnectionString = "UseDevelopmentStorage=true";

    }
}
