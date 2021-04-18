using Simba;
using Simba.OrderedBehaviour;
using UnityEngine;

namespace Example
{
    public class FirstBehaviour : IStartOrderedBehaviour, IUpdateOrderedBehaviour
    {
        private TextController _textController;

        private const string InitializingMessage = "<color=#996600>FirstBehaviour</color>: Initializing\n";
        private static string GetIterationMessage(int iteration) =>
            $"<color=#996600>FirstBehaviour</color>: iteration {iteration}, false -> true";
        
        private const string UpdateErrorMessage = "<color=#cc0000>FirstBehaviour encountered IsUpdated == true</color>\n";
        private const string InitializationErrorMessage = "<color=#cc0000>FirstBehaviour encountered IsInitialized == true</color>\n";

        public void Start()
        {
            _textController = SingleInstanceMonoBehaviour.Find<TextController>();

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
            _textController.Text += str;
        }
    }
}