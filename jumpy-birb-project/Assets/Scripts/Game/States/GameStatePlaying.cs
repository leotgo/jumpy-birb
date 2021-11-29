namespace JumpBirdGame
{
    public class GameStatePlaying : IState
    {
        /* ----------------------------- Runtime Fields ----------------------------- */

        private GameManager _manager;

        /* ------------------------------ Constructors ------------------------------ */

        public GameStatePlaying(GameManager manager)
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