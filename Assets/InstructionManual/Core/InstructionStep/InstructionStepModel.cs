using System.Collections.Generic;
using UnityEngine;
using XRsemble.MVVM.Observables;

namespace XRsemble.Core
{
    public class InstructionStepModel : MVVM.Model.Model
    {
        public IObservableValue<string> Name => _name;
        private readonly ObservableValue<string> _name;

        public IObservableValue<List<VisualizationElementModel>> VisualizationElements => _visualizationElements;
        private readonly ObservableValue<List<VisualizationElementModel>> _visualizationElements;
    }

}
