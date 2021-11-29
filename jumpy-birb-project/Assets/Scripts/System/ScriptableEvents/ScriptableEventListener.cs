using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JumpBirdGame
{
    public class ScriptableEventListener : MonoBehaviour
    {
        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private MonoBehaviour _target;
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

        /* ----------------------------- Initialization ----------------------------- */

        private void Initialize()
        {
            if(_initialized)
                return;

            _source = _target as IScriptableEventSource;
#if UNITY_EDITOR
            AssertReferences();
#endif

            InitializeResponseMap();
            _source.OnRaiseEvent += OnSourceEvent;


            _initialized = true;
        }

#if UNITY_EDITOR
        private void AssertReferences()
        {
            Debug.Assert(_target    != null);
            Debug.Assert(_responses != null);
            Debug.Assert(_source    != null);
        }
#endif

        private void InitializeResponseMap()
        {
            _eventResponseMap = new Dictionary<ScriptableEvent, UnityEvent>();
            foreach (var response in _responses)
            {
                _eventResponseMap.Add(response.SourceEvent, response.TargetEvent);
            }
        }

        private void OnSourceEvent(ScriptableEvent evt)
        {
            if(_eventResponseMap.ContainsKey(evt))
            {
                _eventResponseMap[evt]?.Invoke();
            }
        }

        /* -------------------------------------------------------------------------- */
    }
}
