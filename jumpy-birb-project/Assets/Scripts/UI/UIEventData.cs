using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "UIEventData", menuName = "jumpy-birb/UI/UI Event Data", order = 1)]
    public class UIEventData : ScriptableObject
    {
        /* ------------------------------- Properties ------------------------------- */

        public ScriptableEvent OnRequestStartGame
        {
            get => _onRequestStartGame;
        }

        public ScriptableEvent OnRequestExitGame
        {
            get => _onRequestExitGame;
        }

        public ScriptableEvent OnRequestTogglePause
        {
            get => _onRequestTogglePause;
        }

        public ScriptableEvent OnRequestRestart
        {
            get => _onRequestRestart;
        }

        public ScriptableEvent OnRequestMainMenu
        {
            get => _onRequestMainMenu;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private ScriptableEvent _onRequestStartGame;
        [SerializeField] private ScriptableEvent _onRequestExitGame;
        [SerializeField] private ScriptableEvent _onRequestTogglePause;
        [SerializeField] private ScriptableEvent _onRequestRestart;
        [SerializeField] private ScriptableEvent _onRequestMainMenu;

        /* -------------------------------------------------------------------------- */
    }
}