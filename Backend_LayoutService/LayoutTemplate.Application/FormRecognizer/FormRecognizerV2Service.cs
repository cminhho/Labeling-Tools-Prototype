
using Azure.AI.FormRecognizer;
using Azure.AI.FormRecognizer.Training;
using Azure.AI.FormRecognizer.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure;
using System.Linq;
using LayoutService.Application.Constants;

namespace LayoutTemplate.Application.FormRecognizer
{
    public class FormRecognizerV2Service : IFormRecognizerV2Service
    {
        private readonly ILogger<FormRecognizerV2Service> _log;

        public FormRecognizerV2Service(ILogger<FormRecognizerV2Service> log)
        {
            _log = log;
        }


        // Train a Model
        // Train a machine-learned model on your own form types. The resulting model will be able to recognize values from the types of forms it was trained on.
        // see more: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md
        public async Task<CustomFormModel> TrainCustomModelAsync(string trainingFileUrl)
        {
            FormTrainingClient client = createFormTrainingClient();
            CustomFormModel model = await client.StartTrainingAsync(new Uri(trainingFileUrl)).WaitForCompletionAsync();

            Console.WriteLine($"Custom Model Info:");
            Console.WriteLine($"    Model Id: {model.ModelId}");
            Console.WriteLine($"    Model Status: {model.Status}");
            Console.WriteLine($"    Created On: {model.CreatedOn}");
            Console.WriteLine($"    Last Modified: {model.LastModified}");

            foreach (CustomFormSubModel subModel in model.Models)
            {
                Console.WriteLine($"SubModel Form Type: {subModel.FormType}");
                foreach (CustomFormModelField field in subModel.Fields.Values)
                {
                    Console.Write($"    FieldName: {field.Name}");
                    if (field.Label != null)
                    {
                        Console.Write($", FieldLabel: {field.Label}");
                    }
                    Console.WriteLine("");
                }
            }
            return model;
        }


        public async Task<List<CustomFormModelInfo>> GetListOfModels()
        {
            List<CustomFormModelInfo> results = new List<CustomFormModelInfo>();
            FormTrainingClient client = createFormTrainingClient();

            // Check number of models in the FormRecognizer account, and the maximum number of models that can be stored.
            AccountProperties accountProperties = client.GetAccountProperties();
            Console.WriteLine($"Account has {accountProperties.CustomModelCount} models.");
            Console.WriteLine($"It can have at most {accountProperties.CustomModelLimit} models.");

            // List the first ten or fewer models currently stored in the account.
            Pageable<CustomFormModelInfo> models = client.GetModelInfos();

            foreach (CustomFormModelInfo modelInfo in models.Take(10))
            {
                Console.WriteLine($"Custom Model Info:");
                Console.WriteLine($"    Model Id: {modelInfo.ModelId}");
                Console.WriteLine($"    Model Status: {modelInfo.Status}");
                Console.WriteLine($"    Created On: {modelInfo.CreatedOn}");
                Console.WriteLine($"    Last Modified: {modelInfo.LastModified}");
                results.Add(modelInfo);
            }
            return results;
        }

        public async Task<CustomFormModel> GetCustomModel(string modelId)
        {
            FormTrainingClient client = createFormTrainingClient();

            // Check number of models in the FormRecognizer account, and the maximum number of models that can be stored.
            AccountProperties accountProperties = client.GetAccountProperties();
            Console.WriteLine($"Account has {accountProperties.CustomModelCount} models.");
            Console.WriteLine($"It can have at most {accountProperties.CustomModelLimit} models.");

            return await client.GetCustomModelAsync(modelId);
        }


        public async Task RecognizeContentFromFile()
        {

            FormRecognizerClient client = new FormRecognizerClient(new Uri("endpoint"), new AzureKeyCredential("apiKey"));

            string invoiceFilePath = "Invoice_1.pdf";

            using (FileStream stream = new FileStream(invoiceFilePath, FileMode.Open))
            {
                FormPage formPages = await client.StartRecognizeContent(stream).WaitForCompletionAsync();
                foreach (FormPage page in formPages)
                {
                    Console.WriteLine($"Form Page {page.PageNumber} has {page.Lines.Count} lines.");

                    for (int i = 0; i < page.Lines.Count; i++)
                    {
                        FormLine line = page.Lines[i];
                        Console.WriteLine($"    Line {i} has {line.Words.Count} word{(line.Words.Count > 1 ? "s" : "")}, and text: '{line.Text}'.");
                    }

                    for (int i = 0; i < page.Tables.Count; i++)
                    {
                        FormTable table = page.Tables[i];
                        Console.WriteLine($"Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");
                        foreach (FormTableCell cell in table.Cells)
                        {
                            Console.WriteLine($"    Cell ({cell.RowIndex}, {cell.ColumnIndex}) contains text: '{cell.Text}'.");
                        }
                    }
                }
            }
        }

        public async Task<CustomFormModel> RecognizeFormContent(string invoiceUri)
        {
            var invoiceFilePath = "";
            FormRecognizerClient client = createFormRecognizerClient();

            using (FileStream stream = new FileStream(invoiceFilePath, FileMode.Open))
            {
                FormPageCollection formPages = await client.StartRecognizeContent(stream).WaitForCompletionAsync();
                /*
                 *
                 */
            }

            Response<IReadOnlyList<FormPage>> response = await client.StartRecognizeContentFromUri(new Uri(invoiceUri)).WaitForCompletionAsync();
            Response response1 = response.GetRawResponse();
            foreach (FormPage page in formPages)
            {
                Console.WriteLine($"Form Page {page.PageNumber} has {page.Lines.Count} lines.");

                for (int i = 0; i < page.Lines.Count; i++)
                {
                    FormLine line = page.Lines[i];
                    Console.WriteLine($"    Line {i} has {line.Words.Count} word{(line.Words.Count > 1 ? "s" : "")}, and text: '{line.Text}'.");
                }

                for (int i = 0; i < page.Tables.Count; i++)
                {
                    FormTable table = page.Tables[i];
                    Console.WriteLine($"Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");
                    foreach (FormTableCell cell in table.Cells)
                    {
                        Console.WriteLine($"    Cell ({cell.RowIndex}, {cell.ColumnIndex}) contains text: '{cell.Text}'.");
                    }
                }
            }
        }


        public FormTrainingClient createFormTrainingClient()
        {
            _log.LogDebug("Create form client object with Form Recognizer subscription key");

            string endpoint = Constants.FormRecognizerEndpoint;
            string apiKey = Constants.SubscriptionKey;
            return new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
        }

        public FormRecognizerClient createFormRecognizerClient()
        {
            string endpoint = Constants.FormRecognizerEndpoint;
            string apiKey = Constants.SubscriptionKey;
            var credential = new AzureKeyCredential(apiKey);
            var client = new FormRecognizerClient(new Uri(endpoint), credential);
            return client;
        }

    }
}
