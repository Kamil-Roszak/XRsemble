using XRsemble.MVVM.Disposables;
using XRsemble.MVVM.ViewModel;
using XRsemble.MVVM.Bindings.TextMeshPro;

namespace XRsemble.Core
{
    // Make VisualizationElementViewModel generic with view and model constraints
    public class VisualizationElementViewModel<TView, TModel> : ViewModel<TView, TModel>
        where TView : VisualizationElementView
        where TModel : VisualizationElementModel
    {
        protected override void SetupBindings(TModel model)
        {
            if (View.NameText != null)
                View.NameText.Bind(model.Name).AddTo(Disposables);
        }

        protected virtual void UpdateModel(TModel model)
        {
            // Implementation in base or child class
        }
    }

}