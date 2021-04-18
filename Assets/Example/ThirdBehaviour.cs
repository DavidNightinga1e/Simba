using Simba;
using Simba.OrderedBehaviour;
using UnityEngine;

namespace Example
{
    public class ThirdBehaviour : IUpdateOrderedBehaviour, IStartOrderedBehaviour
    {
        private TextController _textController;

        public void Start()
        {
            _textController = SingleInstanceMonoBehaviour.Find<TextController>();

            if (!ProcessEnvironment.IsInitialized)
            {
                Debug.LogError($"ThirdBehaviour encountered IsInitialized == false");
            }

            Debug.Log("ThirdBehaviour: Initialized confirmed");
        }
        
        public void Update()
        {
            if (ProcessEnvironment.Stop)
                return;

            Debug.Log($"ThirdBehaviour: iteration {ProcessEnvironment.Iteration}");
            
            if (ProcessEnvironment.Iteration != 3) 
                return;
            
            Debug.Log("ThirdBehaviour: STOP");
            ProcessEnvironment.Stop = true;
        }

        private void Print(string str)
        {
            Debug.Log(str);
            _textController.Text += str;
        }
    }
}