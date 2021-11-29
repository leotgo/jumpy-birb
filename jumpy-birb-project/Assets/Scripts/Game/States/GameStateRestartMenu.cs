namespace JumpBirdGame
{
    public class GameStateRestartMenu : IState
    {
        /* ----------------------------- Runtime Fields ----------------------------- */

        private GameManager _manager;

        /* ------------------------------ Constructors ------------------------------ */

        public GameStateRestartMenu(GameManager manager)
        {
            _manager = manager;
        }

        /* ------------------------------ State Events ------------------------------ */

        public void OnStateEnter()
        {
            _manager.Raise(_manager.Events.OnRestartMenu);
        }

        public void OnStateUpdate()
        {
            // Do Nothing
        }

        public void OnStateExit()
        {
            // Do Nothing
        }

        /* -------------------------------------------------------------------------- */
    }
}