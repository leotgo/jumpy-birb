using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class EventStateTransition
    {
        /* ------------------------------- Properties ------------------------------- */

        public IState Source
        {
            get => _source;
        }

        public IState Target
        {
            get => _target;
        }

        public ScriptableEvent Event
        {
            get => _event;
        }

        // Invoked Before OnStateExit
        public System.Action OnTransitionStart
        {
             get => _onTransitionStart;
        }

        // Invoked After OnStateEnter
        public System.Action OnTransitionEnd
        {
            get => _onTransitionEnd;
        }

        /* ----------------------------- Runtime Fields ----------------------------- */

        private IState _source;
        private IState _target;
        private ScriptableEvent _event;
        private System.Action _onTransitionStart;
        private System.Action _onTransitionEnd;

        /* ------------------------------ Constructors ------------------------------ */

        public EventStateTransition(IState source, IState target, ScriptableEvent evt, System.Action onTransitionStart = null, System.Action onTransitionEnd = null)
        {
            _source = source;
            _target = target;
            _event = evt;
            _onTransitionStart = onTransitionStart;
            _onTransitionEnd = onTransitionEnd;
        }

        /* -------------------------------------------------------------------------- */
    }
}