namespace JumpBirdGame
{
    public class GameStateMainMenu : IState
    {
        /* ----------------------------- Runtime Fields ----------------------------- */

        private GameManager _manager;

        /* ------------------------------ Constructors ------------------------------ */

        public GameStateMainMenu(GameManager manager)
        {
            _manager = manager;
        }

        /* ------------------------------ State Events ------------------------------ */

        public void OnStateEnter()
        {
            // Do Nothing
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