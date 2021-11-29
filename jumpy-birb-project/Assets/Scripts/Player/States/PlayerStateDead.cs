using UnityEngine;

namespace JumpBirdGame
{
    public class PlayerStateDead : IState
    {
        /* ----------------------------- Runtime Fields ----------------------------- */

        private Player _player;

        /* ------------------------------ Constructors ------------------------------ */

        public PlayerStateDead(Player player)
        {
            _player = player;
        }

        /* ------------------------------ State Events ------------------------------ */

        public void OnStateEnter()
        {
            _player.RigidBody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            _player.RigidBody2D.Sleep();
            _player.Input.enabled = false;
            _player.Body.enabled = false;
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