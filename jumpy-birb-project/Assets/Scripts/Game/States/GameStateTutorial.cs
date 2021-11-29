using System.Runtime.CompilerServices;
namespace JumpBirdGame
{
    public class GameStateTutorial : IState
    {
        /* ----------------------------- Runtime Fields ----------------------------- */

        private GameManager _manager;

        /* ------------------------------ Constructors ------------------------------ */

        public GameStateTutorial(GameManager manager)
        {
            _manager = manager;
        }

        /* ------------------------------ State Events ------------------------------ */

        public void OnStateEnter()
        {
            _manager.Raise(_manager.Events.OnTutorialStart);
        }

        public void OnStateUpdate()
        {
            // Do Nothing
        }

        public void OnStateExit()
        {
            _manager.Raise(_manager.Events.OnTutorialEnd);
        }

        /* -------------------------------------------------------------------------- */
    }
}