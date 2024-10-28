using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Plastic.Newtonsoft.Json.Bson;

namespace XRsemble.Core
{
    public class TextVisualizer : MonoBehaviour, IStepVisualizationComponent
    {

        [SerializeField]
        TextMeshPro _textDisplay;

        public void Init() {
            if (_textDisplay != null)
                _textDisplay = GetComponent<TextMeshPro>();
        }

        public void Hide()
        {
            if (_textDisplay != null)
                _textDisplay.enabled = false;
        }

        public void Show()
        {
            if(_textDisplay != null)
                _textDisplay.enabled = true;
        }

        private void OnValidate()
        {
            if (_textDisplay == null)
            {
                Debug.LogWarning("Text Display is not assigned. Please assign Text Display to TextVisualizer component.");
            }
        }
    }
}

