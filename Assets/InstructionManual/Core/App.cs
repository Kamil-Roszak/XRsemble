using System.Collections.Generic;
using UnityEngine;
using XRsemble.Core;


namespace XRsemble.Core
{
    public class App : MonoBehaviour
    {

        private InstructionViewModel _instructionViewModel;
        public InstructionView _instructionView;
        private InstructionModel _instructionModel;

        private void Start()
        {
            _instructionModel = new InstructionModel(
                new MVVM.Observables.ObservableValue<string>("Sample Instruction"),
                new MVVM.Observables.ObservableValue<List<InstructionStepModel>>(new List<InstructionStepModel>
                {
                       new InstructionStepModel(new MVVM.Observables.ObservableValue<string>("Step 1"),
                                                new MVVM.Observables.ObservableValue<List<VisualizationElementModel>>(new List<VisualizationElementModel>
                                                {
                                                    new TextVisualizationElementModel(new MVVM.Observables.ObservableValue<string>("Element 1"), new MVVM.Observables.ObservableValue<bool>(true), new MVVM.Observables.ObservableValue<string>("Step 1 text")),
                                                }), new MVVM.Observables.ObservableValue<bool>(true)),
                       new InstructionStepModel(new MVVM.Observables.ObservableValue<string>("Step 2"),
                                                new MVVM.Observables.ObservableValue<List<VisualizationElementModel>>(new List<VisualizationElementModel>
                                                {
                                                    new TextVisualizationElementModel(new MVVM.Observables.ObservableValue<string>("Element 2"), new MVVM.Observables.ObservableValue<bool>(true), new MVVM.Observables.ObservableValue<string>("Step 2 text")),
                                                }), new MVVM.Observables.ObservableValue<bool>(false))
                })
            );

            _instructionViewModel = new InstructionViewModel();
            
            //_instructionViewModel.instructionStepViewModels = new List<InstructionStepViewModel>();
            
            //_instructionViewModel.instructionStepViewModels.Add(new InstructionStepViewModel());
            //_instructionViewModel.instructionStepViewModels.Add(new InstructionStepViewModel());

            //_instructionViewModel.instructionStepViewModels[0].visualizationElementViewModels = new List<VisualizationElementViewModel> { new VisualizationElementViewModel()};
            //_instructionViewModel.instructionStepViewModels[1].visualizationElementViewModels = new List<VisualizationElementViewModel> { new VisualizationElementViewModel() };

            _instructionViewModel.Initialize(_instructionView, _instructionModel, new System.Threading.CancellationToken());
        }

        private void OnDestroy()
        {
            _instructionViewModel.Close();
        }
    }

}
