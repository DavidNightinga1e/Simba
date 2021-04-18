using Simba;
using Simba.OrderedBehaviour;
using UnityEngine;

namespace Example
{
    public class SecondBehaviour : IStartOrderedBehaviour, IUpdateOrderedBehaviour
    {
        private TextController _textController;
        
        private const string InitializingMessage = "<color=#00cc00>SecondBehaviour</color>: Initialization confirmed\n";
        private static string GetIterationMessage(int iteration) =>
            $"<color=#00cc00>SecondBehaviour</color>: iteration {iteration}, true -> false";
        
        private const string UpdateErrorMessage = "<color=#cc0000>SecondBehaviour encountered IsUpdated == false</color>\n";
        private const string InitializationErrorMessage = "<color=#cc0000>SecondBehaviour encountered IsInitialized == false</color>\n";
        
        public void Start()
        {
            _textController = SingleInstanceMonoBehaviour.Find<TextController>();

            if (!ProcessEnvironment.IsInitialized)
                Print(InitializationErrorMessage);

            Print(InitializingMessage);
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
            _textController.Text += str;
        }
    }
}