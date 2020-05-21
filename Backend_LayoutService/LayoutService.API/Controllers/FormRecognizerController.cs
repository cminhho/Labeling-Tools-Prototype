using System;
using System.Threading.Tasks;
using LayoutService.API.Configuration;
using LayoutTemplate.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.FormRecognizer;
using Microsoft.Azure.CognitiveServices.FormRecognizer.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LayoutService.Controllers
{
    [Route("api")]
    [ApiController]
    public class FormRecognizer : ControllerBase
    {
        private readonly ILogger<FormRecognizer> _log;
        private readonly IFormRecognizerService _formRecognizerService;
        private readonly AppConfig _settings;

        public FormRecognizer(ILogger<FormRecognizer> log, IFormRecognizerService formRecognizerService, IOptions<AppConfig> applilcationSettings)
        {
            _log = log;
            _formRecognizerService = formRecognizerService;
            _settings = applilcationSettings.Value;
        }

        // POST: api/formrecognizer/custom/models
        // To train a Form Recognizer model with the documents in given Azure blob container, for
        // more details, see https://westus2.dev.cognitive.microsoft.com/docs/services/form-recognizer-api-v2-preview/operations/TrainCustomModelAsync.
        [HttpPost("formrecognizer/custom/models")]
        public async Task<Guid> TrainModelAsync()
        {
            string trainingDataUrl = "https://cminhho.blob.core.windows.net/pdf?sv=2019-10-10&ss=bfqt&srt=sco&sp=rwdlacup&se=2020-05-30T02:20:39Z&st=2020-05-03T18:20:39Z&spr=https&sig=84CfSqS%2BjEju4XoJQ1R%2ByYBu7RjyMEx15yb2QhotUzM%3D";
            _log.LogDebug($"REST request to train a Form Recognizer model with trainingDataUrl: {trainingDataUrl}");
            IFormRecognizerClient formClient = _formRecognizerService.createFormRecognizerClient();
            return await _formRecognizerService.TrainModelAsync(formClient, trainingDataUrl);
        }

        // POST: api/formrecognizer/custom/models
        // To get list of extracted keys for training data provided to train the model
        [HttpGet("formrecognizer/custom/models/{modelId}")]
        public async Task<KeysResult> GetListOfExtractedKeys(Guid modelId)
        {
            _log.LogDebug($"REST request to get list of extracted keys for training data with modelId : {modelId}");
            IFormRecognizerClient formClient = this._formRecognizerService.createFormRecognizerClient();
            return await this._formRecognizerService.GetListOfExtractedKeys(formClient, modelId);
        }

        // GET: api/Templates
        [HttpGet("formrecognizer/custom/models")]
        public async Task<ModelsResult> GetListOfModels()
        {
            _log.LogDebug($"REST request to get list of custom models");
            IFormRecognizerClient formClient = _formRecognizerService.createFormRecognizerClient();
            return await _formRecognizerService.GetListOfModels(formClient);
            //return await Task.FromResult<ModelsResult>(null);
        }

        // POST: api/formrecognizer/custom/models
        // To train a Form Recognizer model with the documents in given Azure blob container, for
        // more details, see https://westus2.dev.cognitive.microsoft.com/docs/services/form-recognizer-api-v2-preview/operations/TrainCustomModelAsync.
        [HttpPost("formrecognizer/custom/models/analyze/{modelId}")]
        public async Task<AnalyzeResult> AnalyzePdfForm(Guid modelId, string pdfFormFile)
        {
            _log.LogDebug($"REST request to train a Form Recognizer model with the documents in given Azure blob container");
            IFormRecognizerClient formClient = this._formRecognizerService.createFormRecognizerClient();
            return await this._formRecognizerService.AnalyzePdfForm(formClient, modelId, pdfFormFile);
        }
    }
}
