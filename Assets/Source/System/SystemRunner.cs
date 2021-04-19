using System;
using System.Collections.Generic;

namespace Simba
{
    public abstract class SystemRunner : SimbaComponent
    {
        protected abstract List<ISystem> Systems { get; }

        private readonly List<IAwakeSystem> _awakeSystems = new List<IAwakeSystem>();
        private readonly List<IStartSystem> _startSystems = new List<IStartSystem>();
        private readonly List<IUpdateSystem> _updateSystems = new List<IUpdateSystem>();
        private readonly List<ILateUpdateSystem> _lateUpdateSystems = new List<ILateUpdateSystem>();
        private readonly List<IOnDestroySystem> _onDestroySystems = new List<IOnDestroySystem>();

        private void InjectSystems()
        {
            if (Systems is null)
                throw new NullReferenceException($"SystemRunner type {GetType().Name} systems list is null");
            
            foreach (var system in Systems)
            {
                if (system is IAwakeSystem awakeSystem)
                    _awakeSystems.Add(awakeSystem);
                if (system is IStartSystem startSystem)
                    _startSystems.Add(startSystem);
                if (system is IUpdateSystem updateSystem)
                    _updateSystems.Add(updateSystem);
                if (system is ILateUpdateSystem lateUpdateSystem)
                    _lateUpdateSystems.Add(lateUpdateSystem);
                if (system is IOnDestroySystem onDestroySystem)
                    _onDestroySystems.Add(onDestroySystem);
            }
        }
        
        public override void OnAwake()
        {
            InjectSystems();
            
            if (_awakeSystems is null)
                return;

            foreach (var awakeSystem in _awakeSystems)
                awakeSystem.Awake();
        }

        private void Start()
        {
            if (_startSystems is null)
                return;

            foreach (var startSystem in _startSystems)
                startSystem.Start();
        }

        private void Update()
        {
            if (_updateSystems is null)
                return;

            foreach (var updateSystem in _updateSystems)
                updateSystem.Update();
        }

        private void LateUpdate()
        {
            if (_lateUpdateSystems is null)
                return;

            foreach (var lateUpdateSystem in _lateUpdateSystems)
                lateUpdateSystem.LateUpdate();
        }

        public override void OnOnDestroy()
        {
            if (_onDestroySystems is null)
                return;

            foreach (var onDestroySystem in _onDestroySystems)
                onDestroySystem.OnDestroy();
        }
    }
}
