using System.Collections.Generic;
using UnityEngine;
using XRsemble.MVVM.Observables;

namespace XRsemble.Core
{
    public class InstructionStepModel : MVVM.Model.Model
    {
        public IObservableValue<string> Name => _name;
        private readonly ObservableValue<string> _name;

        public IObservableValue<bool> IsVisible => _isVisible;
        private readonly ObservableValue<bool> _isVisible;

        public IObservableValue<List<VisualizationElementModel>> VisualizationElements => _visualizationElements;
        private readonly ObservableValue<List<VisualizationElementModel>> _visualizationElements;

        public InstructionStepModel(ObservableValue<string> name, ObservableValue<List<VisualizationElementModel>> visualizationElements, ObservableValue<bool> isVisible)
        {
            _name = name;
            _isVisible = isVisible;
            _visualizationElements = visualizationElements;
        }


    }

}
