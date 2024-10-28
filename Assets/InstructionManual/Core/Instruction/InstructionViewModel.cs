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
        }

        private void UpdateModel(InstructionModel model)
        {
            
        }
    }
}