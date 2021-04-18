using System;
using System.Collections.Generic;

namespace Simba.OrderedBehaviour
{
    public abstract class OrderedBehaviourRunner : SingleInstanceMonoBehaviour
    {
        protected abstract List<IOrderedBehaviour> OrderedBehaviours { get; }

        private readonly List<IAwakeOrderedBehaviour> _awakeOrderedBehaviours = new List<IAwakeOrderedBehaviour>();
        private readonly List<IStartOrderedBehaviour> _startOrderedBehaviours = new List<IStartOrderedBehaviour>();
        private readonly List<IUpdateOrderedBehaviour> _updateOrderedBehaviours = new List<IUpdateOrderedBehaviour>();
        private readonly List<ILateUpdateOrderedBehaviour> _lateUpdateOrderedBehaviours = new List<ILateUpdateOrderedBehaviour>();
        private readonly List<IOnDestroyOrderedBehaviour> _onDestroyOrderedBehaviours = new List<IOnDestroyOrderedBehaviour>();

        private void InjectBehaviours()
        {
            if (OrderedBehaviours is null)
                throw new NullReferenceException($"OrderedBehaviourRunner type {GetType().Name} has no OrderedBehaviours");
            
            foreach (var orderedBehaviour in OrderedBehaviours)
            {
                if (orderedBehaviour is IAwakeOrderedBehaviour awakeOrderedBehaviour)
                    _awakeOrderedBehaviours.Add(awakeOrderedBehaviour);
                if (orderedBehaviour is IStartOrderedBehaviour startOrderedBehaviour)
                    _startOrderedBehaviours.Add(startOrderedBehaviour);
                if (orderedBehaviour is IUpdateOrderedBehaviour updateOrderedBehaviour)
                    _updateOrderedBehaviours.Add(updateOrderedBehaviour);
                if (orderedBehaviour is ILateUpdateOrderedBehaviour lateUpdateOrderedBehaviour)
                    _lateUpdateOrderedBehaviours.Add(lateUpdateOrderedBehaviour);
                if (orderedBehaviour is IOnDestroyOrderedBehaviour onDestroyOrderedBehaviour)
                    _onDestroyOrderedBehaviours.Add(onDestroyOrderedBehaviour);
            }
        }
        
        public override void OnAwake()
        {
            InjectBehaviours();
            
            if (_awakeOrderedBehaviours is null)
                return;

            foreach (var awakeOrderedBehaviour in _awakeOrderedBehaviours)
                awakeOrderedBehaviour.Awake();
        }

        private void Start()
        {
            if (_startOrderedBehaviours is null)
                return;

            foreach (var startOrderedBehaviour in _startOrderedBehaviours)
                startOrderedBehaviour.Start();
        }

        private void Update()
        {
            if (_updateOrderedBehaviours is null)
                return;

            foreach (var updateOrderedBehaviour in _updateOrderedBehaviours)
                updateOrderedBehaviour.Update();
        }

        private void LateUpdate()
        {
            if (_lateUpdateOrderedBehaviours is null)
                return;

            foreach (var lateUpdateOrderedBehaviour in _lateUpdateOrderedBehaviours)
                lateUpdateOrderedBehaviour.LateUpdate();
        }

        public override void OnOnDestroy()
        {
            if (_onDestroyOrderedBehaviours is null)
                return;

            foreach (var onDestroyOrderedBehaviour in _onDestroyOrderedBehaviours)
                onDestroyOrderedBehaviour.OnDestroy();
        }
    }
}