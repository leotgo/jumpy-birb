using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "GlobalEventSource", menuName = "jumpy-birb/Game/GlobalEventSource", order = 1)]
    public class GlobalEventSource : ScriptableObject, IScriptableEventSource
    {
        /* ----------------------------- Runtime Fields ----------------------------- */

        public event System.Action<ScriptableEvent> OnRaiseEvent;

        /* --------------------------------- Methods -------------------------------- */

        public void Raise(ScriptableEvent evt)
        {
            OnRaiseEvent?.Invoke(evt);
        }

        /* -------------------------------------------------------------------------- */
    }
}