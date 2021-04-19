using Simba;
using UnityEngine;

namespace Example
{
    public class ThirdBehaviour : IUpdateSystem, IStartSystem
    {
        private TextComponent _textComponent;

        private const string InitializationMessage = "<color=#cc0000>ThirdBehaviour</color>: Initialization confirmed\n";
        private const string StopMessage = "<color=#cc0000>ThirdBehaviour</color>: STOP\n";
        private static string GetIterationMessage(int iteration) =>
            $"<color=#cc0000>ThirdBehaviour</color>: Iteration {iteration}\n";
        
        private const string InitializationErrorMessage = "<color=#cc0000>ThirdBehaviour encountered IsInitialized == false</color>\n";
        
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

            Print(GetIterationMessage(ProcessEnvironment.Iteration));
            
            if (ProcessEnvironment.Iteration != 3) 
                return;
            
            Print(StopMessage);
            ProcessEnvironment.Stop = true;
        }

        private void Print(string str)
        {
            Debug.Log(str);
            _textComponent.Text += str;
        }
    }
}