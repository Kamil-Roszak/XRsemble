using System;
using System.Collections.Generic;
using UnityEngine;

namespace XRsemble.Core
{
    // Later remove this dependency - gizmos should be required 
    [RequireComponent(typeof(MeshGameObjectGizmoPreview))]
    public class TransformTranslateVisualizer : MonoBehaviour, IStepVisualizationComponent
    {
        [Header("Transforms")]
        // Target transform that will be translated
        public Transform targetTransform;
        // Target transform that will be translated to
        public Transform translateTarget;
        // Target transform that will be translated from
        [Header("Start Transform")]
        public Transform translateStart;
        public bool currentTransformIsStartTransform = false;

        public bool translateScale, translateRotation;

        [Header("For Gizmo Preview")]
        public MeshGameObjectGizmoPreview _targetTransformGizmoPreview;

        [Header("Translation Settings")]
        public float translationTime = 5f;
        //TODO: Add easing
        private float _timer = 0;
        private bool _isPlaying = false;

        private void OnDrawGizmos()
        {
            if (targetTransform != null && translateTarget != null && (translateStart != null || currentTransformIsStartTransform))
            {
                if (_targetTransformGizmoPreview == null) _targetTransformGizmoPreview = GetComponent<MeshGameObjectGizmoPreview>();
                _targetTransformGizmoPreview.targetTransforms = new List<System.Tuple<Transform, Color>>
                {
                    new Tuple<Transform, Color>(translateTarget, Color.green),
                };
                if (!currentTransformIsStartTransform)
                {
                    _targetTransformGizmoPreview.targetTransforms.Add(new Tuple<Transform, Color>(translateStart, Color.blue));
                }
                _targetTransformGizmoPreview.targetObject = targetTransform.gameObject;
            }

        }

        public void Hide()
        {
            targetTransform.transform.position = translateStart.position;
            _isPlaying = false;
        }

        public void Init()
        {
            if(currentTransformIsStartTransform)
            {
                translateStart = targetTransform;
            }
        }

        public void Show()
        {
            _isPlaying = true;
        }

        private void Update()
        {
            if (_timer <= translationTime && _isPlaying)
            {
                targetTransform.position = Vector3.Lerp(translateStart.position, translateTarget.position, _timer / translationTime);
                if (translateRotation)
                    targetTransform.rotation = Quaternion.Lerp(translateStart.rotation, translateTarget.rotation, _timer / translationTime);
                if (translateScale)
                    targetTransform.localScale = Vector3.Lerp(translateStart.localScale, translateTarget.localScale, _timer / translationTime);
                _timer += Time.deltaTime;
            }
        }
    }
}