namespace JumpBirdGame
{
    public interface IState
    {
        /* ------------------------------ State Events ------------------------------ */

        void OnStateEnter();
        void OnStateUpdate();
        void OnStateExit();

        /* -------------------------------------------------------------------------- */
    }
}