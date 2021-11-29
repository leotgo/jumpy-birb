using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JumpBirdGame
{
    public class GlobalEventListener : MonoBehaviour
    {
        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private GlobalEventSource _globalEventSource;
        [SerializeField] private ScriptableEventResponse[] _responses;

        /* ----------------------------- Runtime Fields ----------------------------- */

        private bool _initialized = false;
        private IScriptableEventSource _source;

        private Dictionary<ScriptableEvent, UnityEvent> _eventResponseMap;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            Cleanup();
        }

        /* ----------------------------- Initialization ----------------------------- */

        private void Initialize()
        {
            if(_initialized)
                return;

            _source = _globalEventSource as IScriptableEventSource;
#if UNITY_EDITOR
            AssertReferences();
#endif
            InitializeResponseMap();
            _source.OnRaiseEvent += OnSourceEvent;

            _initialized = true;
        }

        private void AssertReferences()
        {
            Debug.Assert(_globalEventSource != null);
            Debug.Assert(_source != null);
        }

        private void InitializeResponseMap()
        {
            _eventResponseMap = new Dictionary<ScriptableEvent, UnityEvent>();
            foreach (var response in _responses)
            {
                _eventResponseMap.Add(response.SourceEvent, response.TargetEvent);
            }
        }

        /* ----------------------------- Event Callbacks ---------------------------- */

        private void OnSourceEvent(ScriptableEvent evt)
        {
            if(_eventResponseMap.ContainsKey(evt))
            {
                _eventResponseMap[evt]?.Invoke();
            }
        }

        /* --------------------------------- Cleanup -------------------------------- */

        private void Cleanup()
        {
            _source.OnRaiseEvent -= OnSourceEvent;
        }

        /* -------------------------------------------------------------------------- */
    }
}