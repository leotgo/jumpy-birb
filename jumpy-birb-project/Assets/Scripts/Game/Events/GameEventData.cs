using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "GameEventData", menuName = "jumpy-birb/Game/Game Event Data", order = 1)]
    public class GameEventData : ScriptableObject
    {
        /* ------------------------------- Properties ------------------------------- */

        public ScriptableEvent OnTutorialStart
        {
            get => _onTutorialStart;
        }

        public ScriptableEvent OnTutorialEnd
        {
            get => _onTutorialEnd;
        }

        public ScriptableEvent OnGameplayStart
        {
            get => _onGameplayStart;
        }

        public ScriptableEvent OnGameplayEnd
        {
            get => _onGameplayEnd;
        }

        public ScriptableEvent OnPauseStart
        {
            get => _onPauseStart;
        }

        public ScriptableEvent OnPauseEnd
        {
            get => _onPauseEnd;
        }

        public ScriptableEvent OnRestartMenu
        {
            get => _onRestartMenu;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private ScriptableEvent _onTutorialStart;
        [SerializeField] private ScriptableEvent _onTutorialEnd;
        [SerializeField] private ScriptableEvent _onGameplayStart;
        [SerializeField] private ScriptableEvent _onGameplayEnd;
        [SerializeField] private ScriptableEvent _onPauseStart;
        [SerializeField] private ScriptableEvent _onPauseEnd;
        [SerializeField] private ScriptableEvent _onRestartMenu;

        /* -------------------------------------------------------------------------- */
    }
}