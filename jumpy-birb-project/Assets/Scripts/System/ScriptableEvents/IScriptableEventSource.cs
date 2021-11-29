using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public interface IScriptableEventSource
    {
        /* --------------------------------- Events --------------------------------- */

        event System.Action<ScriptableEvent> OnRaiseEvent;

        /* -------------------------------------------------------------------------- */
    }
}
