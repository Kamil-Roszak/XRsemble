using UnityEngine;
using System.Collections.Generic;
using TMPro;

namespace XRsemble.Core
{
    public class InstructionView : MVVM.View.View
    {
        [field: SerializeField] public TextMeshPro NameText { get; private set; }
        [field: SerializeField] public List<InstructionStepView> InstructionStepsViews { get; private set; }

        public override void Dispose()
        {
            Destroy(gameObject);
        }
    }
}