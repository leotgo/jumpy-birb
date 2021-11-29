namespace JumpBirdGame
{
    public class GameStatePaused : IState
    {
        /* ----------------------------- Runtime Fields ----------------------------- */

        private GameManager _manager;

        /* ------------------------------ Constructors ------------------------------ */

        public GameStatePaused(GameManager manager)
        {
            _manager = manager;
        }

        /* ------------------------------ State Events ------------------------------ */

        public void OnStateEnter()
        {
            _manager.Raise(_manager.Events.OnPauseStart);
        }

        public void OnStateUpdate()
        {
            // Do Nothing
        }

        public void OnStateExit()
        {
            _manager.Raise(_manager.Events.OnPauseEnd);
        }

        /* -------------------------------------------------------------------------- */
    }
}