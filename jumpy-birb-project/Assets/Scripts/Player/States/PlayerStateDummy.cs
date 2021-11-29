using UnityEngine;

namespace JumpBirdGame
{
    public class PlayerStateDummy : IState
    {
        /* ----------------------------- Runtime Fields ----------------------------- */

        private Player _player;

        /* ------------------------------ Constructors ------------------------------ */

        public PlayerStateDummy(Player player)
        {
            _player = player;
        }

        /* ------------------------------ State Events ------------------------------ */

        public void OnStateEnter()
        {
            // Do nothing
        }

        public void OnStateUpdate()
        {
            // Do nothing
        }

        public void OnStateExit()
        {
            // Do nothing
        }

        /* -------------------------------------------------------------------------- */
    }
}