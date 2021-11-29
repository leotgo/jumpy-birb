using UnityEngine;

namespace JumpBirdGame
{
    public class GameStateMachine
    {
        /* ----------------------------- Runtime Fields ----------------------------- */

        private StateMachine _stateMachine;
        private EventStateTransition[] _transitions;

        private GameManager _manager;
        private string _managerDefaultName;

        private GameStateSetup _stateSetup;
        private GameStateMainMenu _stateMainMenu;
        private GameStateTutorial _stateTutorial;
        private GameStatePlaying _statePlaying;
        private GameStatePaused _statePaused;
        private GameStateEnding _stateEnding;
        private GameStateRestartMenu _stateRestartMenu;

        /* ------------------------------ Constructors ------------------------------ */

        public GameStateMachine(GameManager gameManager)
        {
            _manager = gameManager;
            _managerDefaultName = gameManager.gameObject.name;

            _stateSetup       = new GameStateSetup(_manager);
            _stateMainMenu    = new GameStateMainMenu(_manager);
            _stateTutorial    = new GameStateTutorial(_manager);
            _statePlaying     = new GameStatePlaying(_manager);
            _statePaused      = new GameStatePaused(_manager);
            _stateEnding      = new GameStateEnding(_manager);
            _stateRestartMenu = new GameStateRestartMenu(_manager);

            _stateMachine = new StateMachine(_stateSetup);

            _transitions = new EventStateTransition[] {
                new EventStateTransition(_stateSetup      , _stateMainMenu   , _manager.SceneLoadEvents.OnLoadMainMenu  ),
                new EventStateTransition(_stateSetup      , _stateTutorial   , _manager.SceneLoadEvents.OnLoadGameScene ),

                new EventStateTransition(_stateMainMenu   , _stateTutorial   , _manager.SceneLoadEvents.OnLoadGameScene ),

                new EventStateTransition(_stateTutorial   , _statePlaying    , _manager.PlayerEvents.OnJump         , null, () => gameManager.Raise(gameManager.Events.OnGameplayStart)),

                new EventStateTransition(_statePlaying    , _statePaused     , _manager.UIEvents.OnRequestTogglePause ),
                new EventStateTransition(_statePlaying    , _stateEnding     , _manager.PlayerEvents.OnHitObstacle  , () => gameManager.Raise(gameManager.Events.OnGameplayEnd), null),
                new EventStateTransition(_statePlaying    , _stateRestartMenu, _manager.PlayerEvents.OnHitGround    , () => gameManager.Raise(gameManager.Events.OnGameplayEnd), null),

                new EventStateTransition(_statePaused     , _statePlaying    , _manager.UIEvents.OnRequestTogglePause ),
                new EventStateTransition(_statePaused     , _stateSetup      , _manager.UIEvents.OnRequestRestart   ),
                new EventStateTransition(_statePaused     , _stateSetup      , _manager.UIEvents.OnRequestMainMenu  ),

                new EventStateTransition(_stateEnding     , _stateRestartMenu, _manager.PlayerEvents.OnHitGround    ),
                new EventStateTransition(_stateRestartMenu, _stateTutorial   , _manager.SceneLoadEvents.OnLoadGameScene ),
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

        public void OnUIEvent(ScriptableEvent evt)
        {
            CheckTransitionConditions(evt);
        }

        public void OnSceneLoadEvent(ScriptableEvent evt)
        {
            CheckTransitionConditions(evt);
        }

        /* -------------------------------- Utilities ------------------------------- */

        private void CheckTransitionConditions(ScriptableEvent evt)
        {
            foreach (var transition in _transitions)
            {
                if (_stateMachine.CurrentState == transition.Source && evt == transition.Event)
                {
                    // Debug.Log($"Event {evt.name} caused Game State to transition from {transition.Source} to {transition.Target}");
                    transition.OnTransitionStart?.Invoke();
                    _manager.name = $"{_managerDefaultName} - {transition.Target}";
                    _stateMachine.SetState(transition.Target);
                    transition.OnTransitionEnd?.Invoke();
                    return;
                }
            }
        }

        /* -------------------------------------------------------------------------- */
    }
}