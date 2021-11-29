using UnityEngine;

namespace JumpBirdGame
{
    public class PlayerStateFrozen : IState
    {
        /* ----------------------------- Runtime Fields ----------------------------- */

        private RigidbodyConstraints2D _defaultConstraints;
        private Player _player;

        /* ------------------------------ Constructors ------------------------------ */

        public PlayerStateFrozen(Player player)
        {
            _player = player;
        }

        /* ------------------------------ State Events ------------------------------ */

        public void OnStateEnter()
        {
            _defaultConstraints = _player.RigidBody2D.constraints;
            _player.RigidBody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            _player.RigidBody2D.Sleep();
            _player.Body.SetRotation(false);
            _player.Body.SetFlapping(false);
            _player.Body.enabled = false;
            _player.Collider.enabled = false;
        }

        public void OnStateUpdate()
        {
            // Do nothing
        }

        public void OnStateExit()
        {
            _player.RigidBody2D.constraints = _defaultConstraints;
            _player.RigidBody2D.WakeUp();
            _player.Body.SetRotation(true);
            _player.Body.SetFlapping(true);
            _player.Body.enabled = true;
            _player.Collider.enabled = true;
        }

        /* -------------------------------------------------------------------------- */
    }
}