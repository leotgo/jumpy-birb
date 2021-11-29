namespace JumpBirdGame
{
    public class GameStateSetup : IState
    {
        /* ----------------------------- Runtime Fields ----------------------------- */

        private GameManager _manager;

        /* ------------------------------ Constructors ------------------------------ */

        public GameStateSetup(GameManager manager)
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