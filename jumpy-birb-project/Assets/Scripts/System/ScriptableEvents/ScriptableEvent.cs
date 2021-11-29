using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "ScriptableEventName", menuName = "jumpy-birb/System/Scriptable Event", order = 1)]
    public class ScriptableEvent : ScriptableObject
    {
        // ! Empty Scriptable Event, used to implement Type Object pattern
        //   * https://gameprogrammingpatterns.com/type-object.html
    }
}
