using TMPro;
using UnityEngine;

namespace XRsemble.Core
{
    public class TextVisualizationElementView : VisualizationElementView
    {
        [field: SerializeField] public TextMeshPro DisplayedText { get; private set; }

        public override void Dispose()
        {
            Destroy(gameObject);
        }
    }
}