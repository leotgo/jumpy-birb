using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class PlayerStateMachine
    {
        /* ------------------------------- Properties ------------------------------- */

        public bool IsWaiting
        {
            get => _stateMachine.CurrentState == _stateWaiting;
        }

        public bool IsPlaying
        {
            get => _stateMachine.CurrentState == _statePlaying;
        }

        public bool IsFrozen
        {
            get => _stateMachine.CurrentState == _stateFrozen;
        }

        public bool IsDead
        {
            get => _stateMachine.CurrentState == _stateDying || _stateMachine.CurrentState == _stateDead;
        }

        /* ----------------------------- Runtime Fields ----------------------------- */

        private StateMachine _stateMachine = null;

        private PlayerStateWaiting _stateWaiting = null;
        private PlayerStatePlaying _statePlaying = null;
        private PlayerStateFrozen  _stateFrozen  = null;
        private PlayerStateDying   _stateDying   = null;
        private PlayerStateDead    _stateDead    = null;

        private EventStateTransition[] _transitions = null;

        private Player _player;
        private string _defaultPlayerName;

        /* ------------------------------ Constructors ------------------------------ */

        public PlayerStateMachine(Player player)
        {
            _player = player;
            _defaultPlayerName = player.gameObject.name;

            _stateWaiting = new PlayerStateWaiting(player);
            _statePlaying = new PlayerStatePlaying(player);
            _stateFrozen  = new PlayerStateFrozen (player);
            _stateDying   = new PlayerStateDying  (player);
            _stateDead    = new PlayerStateDead   (player);

            _stateMachine = new StateMachine(_stateWaiting);

            _transitions = new EventStateTransition[] {
                new EventStateTransition(_stateWaiting, _statePlaying, player.Data.Events.OnJump       ),
                new EventStateTransition(_statePlaying, _stateDying  , player.Data.Events.OnHitObstacle),
                new EventStateTransition(_statePlaying, _stateDead   , player.Data.Events.OnHitGround  ),
                new EventStateTransition(_stateDying  , _stateDead   , player.Data.Events.OnHitGround   ),

                new EventStateTransition(_statePlaying, _stateFrozen  , GameManager.Instance.Events.OnPauseStart),
                new EventStateTransition(_stateFrozen , _statePlaying , GameManager.Instance.Events.OnPauseEnd  ),
            };
        }

        /* -------------------------- State Machine Events -------------------------- */

        public void Update()
        {
            _stateMachine.Update();
        }

        /* ----------------------------- Event Handling ----------------------------- */

        public void OnPlayerEvent(ScriptableEvent evt)
        {
            CheckTransitionConditions(evt);
        }

        public void OnGameEvent(ScriptableEvent evt)
        {
            CheckTransitionConditions(evt);
        }

        private void CheckTransitionConditions(ScriptableEvent evt)
        {
            foreach (var transition in _transitions)
            {
                if (_stateMachine.CurrentState == transition.Source && evt == transition.Event)
                {
                    Debug.Log($"Player set to state {transition.Target}");
                    _player.gameObject.name = $"{_defaultPlayerName} - {transition.Target}";
                    _stateMachine.SetState(transition.Target);
                }
            }
        }

        /* -------------------------------------------------------------------------- */
    }
}