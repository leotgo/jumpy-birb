using UnityEngine;
using UnityEngine.Events;

namespace JumpBirdGame
{
    [System.Serializable]
    public struct ScriptableEventResponse
    {
        public ScriptableEvent SourceEvent
        {
            get => _sourceEvent;
        }

        public UnityEvent TargetEvent
        {
            get => _targetEvent;
        }

        [SerializeField] private ScriptableEvent _sourceEvent;
        [SerializeField] private UnityEvent      _targetEvent;
    }
}
