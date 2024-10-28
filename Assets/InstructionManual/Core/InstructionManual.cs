using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XRsemble.Core
{
    public class InstructionManual : MonoBehaviour
    {
        public int CurrentStep {  get; private set; }
        public List<Step> steps;

        public bool ShowStep(int index)
        {
            if (index < 0 || index >= steps.Count)
                return false;

            if (index - 1 >= 0)
                steps[index - 1].OnExit();

            steps[index].OnEnter();
            return true;
        }

        public bool ShowNextStep()
        {
            if (CurrentStep == steps.Count - 1) return false;
            return ShowStep(CurrentStep + 1);
        }

        private void Awake()
        {
            CurrentStep = -1;
        }

        //for test for now
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (ShowNextStep()) CurrentStep += 1;
            }
        }

        private void HideAllTheSteps()
        {
            foreach (Step step in steps)
            {
                step.OnExit();
            }
        }
    }
}

