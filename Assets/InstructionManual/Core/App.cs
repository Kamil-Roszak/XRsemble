using UnityEngine;
using XRsemble.Core;


namespace XRsemble.Core
{
    public class App : MonoBehaviour
    {
        [SerializeField] private InstructionView instructionView;

        private InstructionViewModel _instructionViewModel;
        private InstructionView _instructionView;
        private InstructionModel _instructionModel;

        private void Start()
        {
            _instructionModel = new InstructionModel();
            _instructionViewModel = new InstructionViewModel();
            _instructionViewModel.Initialize(_instructionView, _instructionModel, new System.Threading.CancellationToken());
        }

        private void OnDestroy()
        {
            _instructionViewModel.Close();
        }
    }

}
