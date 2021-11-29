using System.Collections.Generic;

namespace JumpBirdGame
{
    public class StateMachine
    {
        /* ------------------------------- Properties ------------------------------- */

        public IState CurrentState
        {
            get => _currentState;
        }

        /* ----------------------------- Runtime Fields ----------------------------- */

        private IState _defaultState = null;
        private IState _currentState = null;

        /* ------------------------------ Constructors ------------------------------ */
        
        public StateMachine(IState defaultState)
        {
            _defaultState = defaultState;
            _currentState = defaultState;
            Initialize();
        }

        /* ----------------------------- Initialization ----------------------------- */

        private void Initialize()
        {
            _currentState.OnStateEnter();
        }

        /* ----------------------------- Public Methods ----------------------------- */

        public void Update()
        {
            _currentState.OnStateUpdate();
        }

        public void SetState(IState target)
        {
            _currentState.OnStateExit();
            _currentState = target;
            _currentState.OnStateEnter();
        }

        /* -------------------------------------------------------------------------- */
    }
}