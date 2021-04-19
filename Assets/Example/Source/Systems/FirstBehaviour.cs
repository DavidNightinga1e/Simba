using Simba;
using UnityEngine;

namespace Example
{
    public class FirstBehaviour : IStartSystem, IUpdateSystem
    {
        private TextComponent _textComponent;

        private const string InitializingMessage = "<color=#009900>FirstBehaviour</color>: Initializing\n";
        private static string GetIterationMessage(int iteration) =>
            $"<color=#009900>FirstBehaviour</color>: Iteration {iteration}, false -> true\n";
        
        private const string UpdateErrorMessage = "<color=#cc0000>FirstBehaviour encountered IsUpdated == true</color>\n";
        private const string InitializationErrorMessage = "<color=#cc0000>FirstBehaviour encountered IsInitialized == true</color>\n";

        public void Start()
        {
            _textComponent = SimbaComponent.Get<TextComponent>();

            if (ProcessEnvironment.IsInitialized) 
                Print(InitializationErrorMessage);

            Print(InitializingMessage);
            ProcessEnvironment.IsInitialized = true;
        }

        public void Update()
        {
            if (ProcessEnvironment.Stop)
                return;

            if (ProcessEnvironment.IsUpdated) 
                Print(UpdateErrorMessage);

            ProcessEnvironment.Iteration += 1;
            Print(GetIterationMessage(ProcessEnvironment.Iteration));
            ProcessEnvironment.IsUpdated = true;
        }

        private void Print(string str)
        {
            Debug.Log(str);
            _textComponent.Text += str;
        }
    }
}