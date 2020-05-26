using System;
using System.Threading.Tasks;
using LayoutService.API.Configuration;
using LayoutTemplate.Application.FormRecognizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Azure.CognitiveServices.FormRecognizer;
using Microsoft.Azure.CognitiveServices.FormRecognizer.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LayoutService.Controllers
{
    [Route("api/formrecognizer/v1/")]
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

        /// <summary>
        /// Trains Custom Model.
        /// </summary>
        /// <param name="trainingDataUrl"></param>
        [HttpPost("custom/models", Name = "Train Custom Model")]
        public async Task<Guid> TrainModelAsync([FromQuery, BindRequired]string trainingDataUrl)
        {
            trainingDataUrl = "https://cminhho.blob.core.windows.net/pdf?sv=2019-10-10&ss=bfqt&srt=sco&sp=rwdlacup&se=2020-05-30T02:20:39Z&st=2020-05-03T18:20:39Z&spr=https&sig=84CfSqS%2BjEju4XoJQ1R%2ByYBu7RjyMEx15yb2QhotUzM%3D";
            _log.LogDebug($"REST request to train a Form Recognizer model with trainingDataUrl: {trainingDataUrl}");
            IFormRecognizerClient formClient = _formRecognizerService.createFormRecognizerClient();
            return await _formRecognizerService.TrainModelAsync(formClient, trainingDataUrl);
        }

        /// <summary>
        /// Gets list of extracted keys for training data
        /// </summary>
        [HttpGet("custom/models/{modelId}")]
        public async Task<KeysResult> GetListOfExtractedKeys([FromRoute]Guid modelId)
        {
            _log.LogDebug($"REST request to get list of extracted keys for training data with modelId : {modelId}");
            IFormRecognizerClient formClient = this._formRecognizerService.createFormRecognizerClient();
            return await _formRecognizerService.GetListOfExtractedKeys(formClient, modelId);
        }

        /// <summary>
        /// Gets all Custom Models.
        /// </summary>
        // GET: api/Templates
        [HttpGet("custom/models")]
        public async Task<ModelsResult> GetListOfModels()
        {
            _log.LogDebug($"REST request to get list of custom models");
            IFormRecognizerClient formClient = _formRecognizerService.createFormRecognizerClient();
            return await _formRecognizerService.GetListOfModels(formClient);
        }

        /// <summary>
        /// Gets analyze form result
        /// </summary>
        [HttpGet("layout/analyzeresults/{resultId}")]
        public async Task<KeysResult> GetListOfModels([FromRoute]Guid resultId)
        {
            _log.LogDebug($"REST request to get analyze form result");
            IFormRecognizerClient formClient = _formRecognizerService.createFormRecognizerClient();
            return await _formRecognizerService.GetListOfExtractedKeys(formClient, resultId);
        }
        
        // POST: api/formrecognizer/custom/models
        // To train a Form Recognizer model with the documents in given Azure blob container, for
        // more details, see https://westus2.dev.cognitive.microsoft.com/docs/services/form-recognizer-api-v2-preview/operations/TrainCustomModelAsync.
        [HttpPost("custom/models/analyze/{modelId}")]
        public async Task<AnalyzeResult> AnalyzePdfForm([FromRoute] Guid modelId, string pdfFormFile)
        {
            _log.LogDebug($"REST request to train a Form Recognizer model with the documents in given Azure blob container");
            IFormRecognizerClient formClient = _formRecognizerService.createFormRecognizerClient();
            return await this._formRecognizerService.AnalyzePdfForm(formClient, modelId, pdfFormFile);
        }

        // delete: api/formrecognizer/custom/models/5
        [HttpDelete("custom/models/{id}")]
        public async Task<IActionResult> DeleteTemplateAsync([FromRoute] Guid modelId)
        {
            _log.LogDebug($"REST request to delete a model");
            IFormRecognizerClient formClient = _formRecognizerService.createFormRecognizerClient();
            await _formRecognizerService.DeleteModel(formClient, modelId);
            return Ok();
        }
    }
}
