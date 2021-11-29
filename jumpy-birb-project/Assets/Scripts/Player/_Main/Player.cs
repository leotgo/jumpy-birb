using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JumpBirdGame
{
    public class Player : MonoBehaviour, IPhysicsEntity2D, IScriptableEventSource
    {
        /* -------------------------------- Singleton ------------------------------- */

        public static Player Instance
        {
            get => _instance;
        }

        private static Player _instance = null;

        /* ------------------------------- Properties ------------------------------- */

        public PlayerData Data
        {
            get => _data;
        }

        public Vector2 Velocity
        {
            get => _rigidbody2D.velocity;
        }

        public Rigidbody2D RigidBody2D
        {
            get => _rigidbody2D;
        }

        public Collider2D Collider
        {
            get => _collider;
        }

        public PlayerInputHandler Input
        {
            get => _inputHandler;
        }

        public PlayerBody Body
        {
            get => _bodyRotator;
        }

        /* --------------------------------- Events --------------------------------- */

        public event System.Action<ScriptableEvent> OnRaiseEvent;

        /* ----------------------------- Component refs ----------------------------- */

        [Header("Component References")]
        [SerializeField] private Rigidbody2D        _rigidbody2D;
        [SerializeField] private Collider2D         _collider;
        [SerializeField] private SpriteRenderer     _graphics;
        [SerializeField] private PlayerBody         _bodyRotator;
        [SerializeField] private PlayerInputHandler _inputHandler;

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [Header("Player Data")]
        [SerializeField] private PlayerData _data;

        /* ----------------------------- Runtime Fields ----------------------------- */

        private bool _initialized = false;
        private PlayerStateMachine _stateMachine;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
            Raise(_data.Events.OnSpawn);
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void OnDestroy()
        {
            Cleanup();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Hitbox hitbox = other.GetComponent<Hitbox>();
            if(hitbox != null)
            {
                hitbox.Owner.OnHitboxCollision(this);
            }
        }

        /* ----------------------------- Initialization ----------------------------- */

        private void Initialize()
        {
            if (_initialized)
                return;

            _instance = this;

            InitializeStateMachine();
#if UNITY_EDITOR
            AssertReferences();
#endif
            GameManager.Instance.OnPlayerInitialized(this);
            _initialized = true;
        }

        private void InitializeStateMachine()
        {
            _stateMachine = new PlayerStateMachine(this);
            OnRaiseEvent += _stateMachine.OnPlayerEvent;
            GameManager.Instance.GameEventSource.OnRaiseEvent += _stateMachine.OnGameEvent;
        }

#if UNITY_EDITOR
        private void AssertReferences()
        {
            Debug.Assert(_data         != null);
            Debug.Assert(_rigidbody2D  != null);
            Debug.Assert(_graphics     != null);
            Debug.Assert(_bodyRotator  != null);
            Debug.Assert(_inputHandler != null);
            Debug.Assert(_stateMachine != null);
        }
#endif

        /* --------------------------------- Actions -------------------------------- */

        public void Jump()
        {
            if(_stateMachine.IsDead || _stateMachine.IsFrozen)
                return;

            _rigidbody2D.velocity = Vector2.up * _data.Physics.JumpForce;
            Raise(_data.Events.OnJump);
        }

        public void PassObstacle()
        {
            Raise(_data.Events.OnScore);
        }

        public void HitObstacle()
        {
            if(_stateMachine.IsDead || _stateMachine.IsFrozen)
                return;

            Raise(_data.Events.OnHitObstacle);
            Raise(_data.Events.OnDeath);
        }

        public void HitGround()
        {
            Raise(_data.Events.OnHitGround);
        }

        private void Raise(ScriptableEvent evt)
        {
            // Debug.Log($"Player Raised Event {evt.name}");
            OnRaiseEvent?.Invoke(evt);
        }

        /* --------------------------------- Cleanup -------------------------------- */

        private void Cleanup()
        {
            GameManager.Instance.GameEventSource.OnRaiseEvent -= _stateMachine.OnGameEvent;
        }

        /* -------------------------------------------------------------------------- */
    }
}
