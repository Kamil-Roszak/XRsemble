using XRsemble.MVVM.Disposables;
using XRsemble.MVVM.ViewModel;
using XRsemble.MVVM.Bindings.TextMeshPro;

namespace XRsemble.Core
{
    public class InstructionStepViewModel : ViewModel<InstructionStepView, InstructionStepModel>
    {
        protected override void SetupBindings(InstructionStepModel model)
        {
            View.NameText.Bind(model.Name).AddTo(Disposables);
        }

        private void UpdateModel(InstructionStepModel model)
        {

        }
    }
}