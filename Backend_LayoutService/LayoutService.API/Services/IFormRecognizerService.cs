using LayoutService.API.Model;
using Microsoft.Azure.CognitiveServices.FormRecognizer;
using Microsoft.Azure.CognitiveServices.FormRecognizer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LayoutTemplate.API.Services
{
    public interface IFormRecognizerService
    {
        IFormRecognizerClient createFormRecognizerClient();

        Task<Guid> TrainModelAsync(IFormRecognizerClient formClient, string trainingDataUrl);

        Task<KeysResult> GetListOfExtractedKeys(IFormRecognizerClient formClient, Guid modelId);

        Task<AnalyzeResult> AnalyzePdfForm(IFormRecognizerClient formClient, Guid modelId, string pdfFormFile);

        Task<ModelsResult> GetListOfModels(IFormRecognizerClient formClient);

        Task DeleteModel(IFormRecognizerClient formClient, Guid modelId);

    }
}
