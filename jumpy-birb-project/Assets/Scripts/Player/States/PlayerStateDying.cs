using UnityEngine;

namespace JumpBirdGame
{
    public class PlayerStateDying : IState
    {
        /* ----------------------------- Runtime Fields ----------------------------- */

        private Player _player;

        /* ------------------------------ Constructors ------------------------------ */

        public PlayerStateDying(Player player)
        {
            _player = player;
        }

        /* ------------------------------ State Events ------------------------------ */

        public void OnStateEnter()
        {
            // Do nothing
            _player.Input.enabled = false;
            _player.Body.enabled = true;
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