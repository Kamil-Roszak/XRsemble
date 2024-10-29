using XRsemble.MVVM.Disposables;
using XRsemble.MVVM.ViewModel;
using XRsemble.MVVM.Bindings.TextMeshPro;
using System.Collections.Generic;
using XRsemble.MVVM.Bindings;

namespace XRsemble.Core
{
    public class InstructionStepViewModel : ViewModel<InstructionStepView, InstructionStepModel>
    {
        public List<VisualizationElementViewModel<VisualizationElementView, VisualizationElementModel>> visualizationElementViewModels;
        public List<TextVisualizationElementViewModel> textVisualizationViewModels;
        protected override void SetupBindings(InstructionStepModel model)
        {
            View.NameText.Bind(model.Name).AddTo(Disposables);
            View.Root.Bind(model.IsVisible).AddTo(Disposables);

            visualizationElementViewModels = new List<VisualizationElementViewModel<VisualizationElementView, VisualizationElementModel>>();
            textVisualizationViewModels = new List<TextVisualizationElementViewModel>();
            for (int i = 0; i < model.VisualizationElements.Value.Count; i++)
            {
                VisualizationElementModel elementModel = model.VisualizationElements.Value[i];
                VisualizationElementView elementView = View.VisualizationElementsViews[i];

                // Check the type of the model to determine which ViewModel to create
                // Change this later - because this will make making new visual elements harder
                if (elementModel is TextVisualizationElementModel textModel)
                {
                    var viewModel = new TextVisualizationElementViewModel();
                    viewModel.Initialize((TextVisualizationElementView)elementView, textModel, new System.Threading.CancellationToken());
                    textVisualizationViewModels.Add(viewModel);
                }
                else
                {
                    var viewModel = new VisualizationElementViewModel<VisualizationElementView, VisualizationElementModel>();
                    viewModel.Initialize(elementView, elementModel, new System.Threading.CancellationToken());
                    visualizationElementViewModels.Add(viewModel);
                }
            }
        }

        private void UpdateModel(InstructionStepModel model)
        {

        }
    }
}