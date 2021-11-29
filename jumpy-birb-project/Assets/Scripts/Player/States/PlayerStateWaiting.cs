using UnityEngine;

namespace JumpBirdGame
{
    public class PlayerStateWaiting : IState
    {
        /* ----------------------------- Runtime Fields ----------------------------- */

        private Player _player;

        /* ------------------------------ Constructors ------------------------------ */

        public PlayerStateWaiting(Player player)
        {
            _player = player;
        }

        /* ------------------------------ State Events ------------------------------ */

        public void OnStateEnter()
        {
            _player.Collider.enabled = false;
            _player.RigidBody2D.Sleep();
            _player.Input.enabled = true;
            _player.Body.SetRotation(false);
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