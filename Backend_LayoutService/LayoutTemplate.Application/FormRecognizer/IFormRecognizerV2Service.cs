using Azure.AI.FormRecognizer.Training;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LayoutTemplate.Application.FormRecognizer
{
    public interface IFormRecognizerV2Service
    {
        Task<CustomFormModel> TrainCustomModelAsync(string trainingFileUrl);
        Task<List<CustomFormModelInfo>> GetListOfModels();
        Task<CustomFormModel> GetCustomModel(string modelId);
    }
}
