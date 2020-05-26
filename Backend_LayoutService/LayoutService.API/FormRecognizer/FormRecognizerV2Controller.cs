using System.Collections.Generic;
using System.Threading.Tasks;
using LayoutService.API.Configuration;
using LayoutTemplate.Application.FormRecognizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Azure.AI.FormRecognizer.Training;

namespace LayoutService.Controllers
{
    [Route("api/formrecognizer/v2/")]
    [ApiController]
    public class FormRecognizerV2 : ControllerBase
    {
        private readonly ILogger<FormRecognizer> _log;
        private readonly IFormRecognizerV2Service _formRecognizerServiceV2;
        private readonly AppConfig _settings;

        public FormRecognizerV2(ILogger<FormRecognizer> log, IFormRecognizerV2Service formRecognizerServiceV2, IOptions<AppConfig> applilcationSettings)
        {
            _log = log;
            _formRecognizerServiceV2 = formRecognizerServiceV2;
            _settings = applilcationSettings.Value;
        }

        /// <summary>
        ///     Trains Custom Model async.
        /// </summary>
        /// <param name="trainingDataUrl"></param>
        [HttpPost("custom/models")]
        public async Task<CustomFormModel> TrainCustomModelAsync([FromQuery, BindRequired]string trainingDataUrl)
        {
            return await _formRecognizerServiceV2.TrainCustomModelAsync(trainingDataUrl);
        }

        /// <summary>
        ///     Get all Custom Models.
        /// </summary>
        [HttpGet("custom/models")]
        public async Task<List<CustomFormModelInfo>> GetListOfModels()
        {
            return await _formRecognizerServiceV2.GetListOfModels();
        }

        /// <summary>
        ///     Get a Custom Models.
        /// </summary>
        [HttpGet("custom/models/{modelId}")]
        public async Task<CustomFormModel> GetModel([FromRoute] string modelId)
        {
            return await _formRecognizerServiceV2.GetCustomModel(modelId);
        }
    }
}
