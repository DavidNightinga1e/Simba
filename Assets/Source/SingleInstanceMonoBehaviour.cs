using UnityEngine;

namespace Simba
{
    public abstract partial class SingleInstanceMonoBehaviour : MonoBehaviour
    {
        internal void Awake()
        {
            MonoBehaviours.Add(this);
            OnAwake();
        }
        
        internal void OnDestroy()
        {
            MonoBehaviours.Remove(this);
            OnOnDestroy();
        }
        
        public abstract void OnAwake();

        public abstract void OnOnDestroy();
    }
}