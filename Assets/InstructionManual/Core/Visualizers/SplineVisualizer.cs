using UnityEngine;
using UnityEngine.Splines;

namespace XRsemble.Core
{
    public class SplineVisualizer : MonoBehaviour, IStepVisualizationComponent
    {
        enum SplineAnimationType { FillStartToEnd, FillEndToStart, FillBothEnds }

        [Header("Parameters")]
        public float splineFillTime = 2f;
        [SerializeField]
        private SplineAnimationType _splineAnimation = SplineAnimationType.FillStartToEnd;

        [SerializeField]
        private SplineExtrude _splineExtrude;
        [SerializeField]
        private MeshRenderer _splineMeshRenderer;

        [SerializeField]
        private float _timer = 0f;
        private bool _isAnimated = false;

        public void Hide()
        {
            _splineExtrude.enabled = false;
            _splineMeshRenderer.enabled = false;
        }

        public void Init()
        {
            _splineExtrude.RebuildOnSplineChange = true;
            _splineExtrude.enabled = false;
            _splineMeshRenderer.enabled = false;
            _timer = 0f;
            _isAnimated = false;
            _splineExtrude.Range = new Vector2(0f, 0f);
            _splineExtrude.Rebuild();
        }

        public void Show()
        {
            _splineExtrude.enabled = true;
            _splineMeshRenderer.enabled = true;
            _isAnimated = true;
        }

        private void Update()
        {
            if(_timer < splineFillTime && _isAnimated)
            {
                switch(_splineAnimation)
                {
                    case SplineAnimationType.FillStartToEnd:
                        _splineExtrude.Range = new Vector2(0, (_timer / splineFillTime));
                        break;
                    case SplineAnimationType.FillEndToStart:
                        _splineExtrude.Range = new Vector2(1f - (_timer / splineFillTime), 1);
                        break;
                    case SplineAnimationType.FillBothEnds:
                        _splineExtrude.Range = new Vector2(0.5f - (_timer / splineFillTime / 2f), 0.5f + (_timer / splineFillTime / 2f));
                        break;
                }
                _splineExtrude.Rebuild();
                _timer += Time.deltaTime;
            }
        }
    }
}

