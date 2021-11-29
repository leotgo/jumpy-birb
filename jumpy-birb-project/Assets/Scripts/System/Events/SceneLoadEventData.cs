using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "SceneLoadEventData", menuName = "jumpy-birb/System/SceneLoad Event Data", order = 1)]
    public class SceneLoadEventData : ScriptableObject
    {
        /* ------------------------------- Properties ------------------------------- */

        public ScriptableEvent OnLoadMainMenu
        {
            get => _onLoadMainMenu;
        }

        public ScriptableEvent OnLoadGameScene
        {
            get => _onLoadGameScene;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private ScriptableEvent _onLoadMainMenu;
        [SerializeField] private ScriptableEvent _onLoadGameScene;

        /* -------------------------------------------------------------------------- */
    }
}   