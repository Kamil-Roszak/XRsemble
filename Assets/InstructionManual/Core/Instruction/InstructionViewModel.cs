using XRsemble.MVVM.Disposables;
using XRsemble.MVVM.ViewModel;
using XRsemble.MVVM.Bindings.TextMeshPro;
using System.Collections.Generic;

namespace XRsemble.Core
{
    public class InstructionViewModel : ViewModel<InstructionView, InstructionModel>
    {
        public List<InstructionStepViewModel> instructionStepViewModels;

        protected override void SetupBindings(InstructionModel model)
        {
            View.NameText.Bind(model.Name).AddTo(Disposables);

            instructionStepViewModels = new List<InstructionStepViewModel>();
            for(int i =0; i < model.Steps.Value.Count; i++)
            {
                instructionStepViewModels.Add(new InstructionStepViewModel());
                instructionStepViewModels[i].Initialize(View.InstructionStepsViews[i], model.Steps.Value[i], new System.Threading.CancellationToken());
            }
        }

        private void UpdateModel(InstructionModel model)
        {
            
        }
    }
}