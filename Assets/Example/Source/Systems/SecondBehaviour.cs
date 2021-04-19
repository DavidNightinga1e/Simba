using Simba;
using UnityEngine;

namespace Example
{
    public class SecondBehaviour : IStartSystem, IUpdateSystem
    {
        private TextComponent _textComponent;
        
        private const string InitializationMessage = "<color=#996600>SecondBehaviour</color>: Initialization confirmed\n";
        private static string GetIterationMessage(int iteration) =>
            $"<color=#996600>SecondBehaviour</color>: Iteration {iteration}, true -> false\n";
        
        private const string UpdateErrorMessage = "<color=#cc0000>SecondBehaviour encountered IsUpdated == false</color>\n";
        private const string InitializationErrorMessage = "<color=#cc0000>SecondBehaviour encountered IsInitialized == false</color>\n";
        
        public void Start()
        {
            _textComponent = SimbaComponent.Get<TextComponent>();

            if (!ProcessEnvironment.IsInitialized)
                Print(InitializationErrorMessage);

            Print(InitializationMessage);
        }

        public void Update()
        {
            if (ProcessEnvironment.Stop)
                return;

            if (!ProcessEnvironment.IsUpdated) 
                Print(UpdateErrorMessage);

            Print(GetIterationMessage(ProcessEnvironment.Iteration));
            ProcessEnvironment.IsUpdated = false;
        }

        private void Print(string str)
        {
            Debug.Log(str);
            _textComponent.Text += str;
        }
    }
}