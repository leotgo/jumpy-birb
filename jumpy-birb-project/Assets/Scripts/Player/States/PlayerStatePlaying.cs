using UnityEngine;

namespace JumpBirdGame
{
    public class PlayerStatePlaying : IState
    {
        /* ----------------------------- Runtime Fields ----------------------------- */

        private Player _player;

        /* ------------------------------ Constructors ------------------------------ */

        public PlayerStatePlaying(Player player)
        {
            _player = player;
        }

        /* ------------------------------ State Events ------------------------------ */

        public void OnStateEnter()
        {
            _player.Collider.enabled = true;
            _player.Body.SetRotation(true);
            _player.Input.enabled = true;
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