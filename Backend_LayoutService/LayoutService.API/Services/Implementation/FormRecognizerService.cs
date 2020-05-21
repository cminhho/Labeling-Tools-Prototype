using LayoutService.API.Infrastructure;
using LayoutTemplate.API.Services;
using Microsoft.Azure.CognitiveServices.FormRecognizer;
using Microsoft.Azure.CognitiveServices.FormRecognizer.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutService.API.Services.Implementation
{
    public class FormRecognizerService : IFormRecognizerService
    {
        private readonly ILogger<FormRecognizerService> _log;

        public FormRecognizerService(ILogger<FormRecognizerService> log)
        {
            _log = log;
        }


        // Train model using training form data (pdf, jpg, png files)
        public async Task<Guid> TrainModelAsync(
            IFormRecognizerClient formClient, string trainingDataUrl)
        {
            if (!Uri.IsWellFormedUriString(trainingDataUrl, UriKind.Absolute))
            {
                _log.LogError($"Invalid trainingDataUrl: {trainingDataUrl}");
                return Guid.Empty;
            }

            try
            {
                TrainResult result = await formClient.TrainCustomModelAsync(new TrainRequest(trainingDataUrl));

                ModelResult model = await formClient.GetCustomModelAsync(result.ModelId);
                DisplayModelStatus(model);

                return result.ModelId;
            }
            catch (ErrorResponseException e)
            {
                _log.LogError($"Train Model: {e.Message}");
                return Guid.Empty;
            }
        }

        // Display model status
        public void DisplayModelStatus(ModelResult model)
        {
            _log.LogDebug("\nModel :");
            _log.LogDebug("\tModel id: " + model.ModelId);
            _log.LogDebug("\tStatus:  " + model.Status);
            _log.LogDebug("\tCreated: " + model.CreatedDateTime);
            _log.LogDebug("\tUpdated: " + model.LastUpdatedDateTime);
        }

        // Get and display list of extracted keys for training data 
        // provided to train the model
        public async Task<KeysResult> GetListOfExtractedKeys(
            IFormRecognizerClient formClient, Guid modelId)
        {
            if (modelId == Guid.Empty)
            {
                _log.LogError("\nInvalid model Id.");
                return null;
            }

            try
            {
                KeysResult kr = await formClient.GetExtractedKeysAsync(modelId);
                var clusters = kr.Clusters;
                foreach (var kvp in clusters)
                {
                    Console.WriteLine("  Cluster: " + kvp.Key + "");
                    foreach (var v in kvp.Value)
                    {
                        Console.WriteLine("\t" + v);
                    }
                }
                return await formClient.GetExtractedKeysAsync(modelId);
            }
            catch (ErrorResponseException e)
            {
                _log.LogError($"Get list of extracted keys : {e.Message}");
                return null;
            }
        }

        // Analyze PDF form data
        public async Task<AnalyzeResult> AnalyzePdfForm(
            IFormRecognizerClient formClient, Guid modelId, string pdfFormFile)
        {
            if (string.IsNullOrEmpty(pdfFormFile))
            {
                _log.LogError("\nInvalid pdfFormFile.");
                return null;
            }

            try
            {
                using (FileStream stream = new FileStream(pdfFormFile, FileMode.Open))
                {
                    AnalyzeResult result = await formClient.AnalyzeWithCustomModelAsync(modelId, stream, contentType: "application/pdf");

                    _log.LogError("\nExtracted data from:" + pdfFormFile);
                    DisplayAnalyzeResult(result);
                    return result;
                }
            }
            catch (ErrorResponseException e)
            {
                _log.LogError("Analyze PDF form : " + e.Message);
            }
            catch (Exception ex)
            {
                _log.LogError("Analyze PDF form : " + ex.Message);
            }
            return null;
        }

        // Display analyze status
        public void DisplayAnalyzeResult(AnalyzeResult result)
        {
            foreach (var page in result.Pages)
            {
                Console.WriteLine("\tPage#: " + page.Number);
                Console.WriteLine("\tCluster Id: " + page.ClusterId);
                foreach (var kv in page.KeyValuePairs)
                {
                    if (kv.Key.Count > 0)
                        Console.Write(kv.Key[0].Text);

                    if (kv.Value.Count > 0)
                        Console.Write(" - " + kv.Value[0].Text);

                    Console.WriteLine();
                }
                Console.WriteLine();

                foreach (var t in page.Tables)
                {
                    Console.WriteLine("Table id: " + t.Id);
                    foreach (var c in t.Columns)
                    {
                        foreach (var h in c.Header)
                            Console.Write(h.Text + "\t");

                        foreach (var e in c.Entries)
                        {
                            foreach (var ee in e)
                                Console.Write(ee.Text + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
        }

        // Get and display list of trained the models
        public async Task<ModelsResult> GetListOfModels(
            IFormRecognizerClient formClient)
        {
            try
            {
                ModelsResult models = await formClient.GetCustomModelsAsync();
                foreach (ModelResult m in models.ModelsProperty)
                {
                    _log.LogDebug(m.ModelId + " " + m.Status + " " + m.CreatedDateTime + " " + m.LastUpdatedDateTime);
                }
                Console.WriteLine();
                return await formClient.GetCustomModelsAsync();
            }
            catch (ErrorResponseException e)
            {
                _log.LogError("Get list of models : " + e.Message);
                return null;
            }
        }

        // Delete a model
        public async Task DeleteModel(
            IFormRecognizerClient formClient, Guid modelId)
        {
            try
            {
                _log.LogDebug("Deleting model: {0}...", modelId.ToString());
                await formClient.DeleteCustomModelAsync(modelId);
                _log.LogDebug("done.\n");
            }
            catch (ErrorResponseException e)
            {
                _log.LogError("Delete model : " + e.Message);
            }
        }

        public IFormRecognizerClient createFormRecognizerClient()
        {
            _log.LogDebug("Create form client object with Form Recognizer subscription key");
            IFormRecognizerClient formClient = new FormRecognizerClient(
                new ApiKeyServiceClientCredentials(Constants.SubscriptionKey))
            {
                Endpoint = Constants.FormRecognizerEndpoint
            };
            return formClient;
        }
    }
}
