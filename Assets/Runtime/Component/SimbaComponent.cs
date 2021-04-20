using UnityEngine;

namespace Simba
{
    public abstract partial class SimbaComponent : MonoBehaviour
    {
        internal void Awake()
        {
            Add(this);
            OnAwake();
        }
        
        internal void OnDestroy()
        {
            Remove(this);
            OnOnDestroy();
        }
        
        public abstract void OnAwake();

        public abstract void OnOnDestroy();
    }
}