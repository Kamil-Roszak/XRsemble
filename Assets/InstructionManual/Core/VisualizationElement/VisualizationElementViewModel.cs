using XRsemble.MVVM.Disposables;
using XRsemble.MVVM.ViewModel;
using XRsemble.MVVM.Bindings.TextMeshPro;

namespace XRsemble.Core
{
    public class VisualizationElementViewModel : ViewModel<VisualizationElementView, VisualizationElementModel>
    {
        protected override void SetupBindings(VisualizationElementModel model)
        {
            View.NameText.Bind(model.Name).AddTo(Disposables);
        }

        private void UpdateModel(VisualizationElementModel model)
        {

        }
    }
}