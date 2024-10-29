using System.Collections.Generic;
using UnityEngine;
using XRsemble.MVVM.Observables;

namespace XRsemble.Core
{
    public class InstructionModel : MVVM.Model.Model
    {
        public IObservableValue<string> Name => _name;
        private readonly ObservableValue<string> _name;

        public IObservableValue<List<InstructionStepModel>> Steps => _steps;
        private readonly ObservableValue<List<InstructionStepModel>> _steps;

        public InstructionModel(ObservableValue<string> name, ObservableValue<List<InstructionStepModel>> steps)
        {
            _name = name;
            _steps = steps;
        }
    }

}
