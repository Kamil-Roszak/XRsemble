using XRsemble.MVVM.Disposables;
using XRsemble.MVVM.ViewModel;
using XRsemble.MVVM.Bindings.TextMeshPro;

namespace XRsemble.Core
{
    public class TextVisualizationElementViewModel : VisualizationElementViewModel<TextVisualizationElementView, TextVisualizationElementModel>
    {
        protected override void SetupBindings(TextVisualizationElementModel model)
        {
            if(View.NameText != null)
                View.NameText.Bind(model.Name).AddTo(Disposables);
            View.DisplayedText.Bind(model.DisplayedText).AddTo(Disposables);
        }

        private void UpdateModel(TextVisualizationElementModel model)
        {

        }
    }
}

