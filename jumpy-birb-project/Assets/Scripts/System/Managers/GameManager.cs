using UnityEngine;

namespace JumpBirdGame
{
    public class GameManager : MonoBehaviour
    {
        /* -------------------------------- Singleton ------------------------------- */

        public static GameManager Instance
        {
            get => _instance;
        }

        private static GameManager _instance = null;

        /* ------------------------------- Properties ------------------------------- */

        public Vector3 DefaultPlayerPosition
        {
            get => _defaultPlayerPosition;
        }

        public GameEventData Events 
        {
             get => _gameEvents;
        }

        public GlobalEventSource GameEventSource
        {
            get => _gameEventSource;
        }

        public PlayerEventData PlayerEvents
        {
            get => _playerEvents;
        }

        public UIEventData UIEvents
        {
            get => _uiEvents;
        }

        public SceneLoadEventData SceneLoadEvents
        {
            get => _sceneLoadEvents;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        
        [Header("Component References")]
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private SceneLoadManager _sceneLoadManager;

        [Header("Event Data")]
        [SerializeField] private GameEventData _gameEvents;
        [SerializeField] private PlayerEventData _playerEvents;
        [SerializeField] private UIEventData _uiEvents;
        [SerializeField] private GlobalEventSource _gameEventSource;
        [SerializeField] private SceneLoadEventData _sceneLoadEvents;

        /* ----------------------------- Runtime Fields ----------------------------- */

        private bool _initialized = false;
        private Vector3 _defaultPlayerPosition;
        private Player _player;
        private GameStateMachine _stateMachine;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            Initialize();
        }

        /* ----------------------------- Initialization ----------------------------- */

        private void Initialize()
        {
            if(_initialized)
                return;

            _instance = this;
            _stateMachine = new GameStateMachine(this);
            _uiManager.UIEventSource.OnRaiseEvent += _stateMachine.OnUIEvent;
            _sceneLoadManager.EventSource.OnRaiseEvent += _stateMachine.OnSceneLoadEvent;

            _initialized = true;
        }

        /* ----------------------------- Public Methods ----------------------------- */

        public void Raise(ScriptableEvent evt)
        {
            Debug.Log($"Game Event: {evt.name}");
            _gameEventSource.Raise(evt);
        }

        /* ------------------------------- Game Events ------------------------------ */

        public void OnPlayerInitialized(Player player)
        {
            _player = player;
            _defaultPlayerPosition = player.transform.position;
            player.OnRaiseEvent += _stateMachine.OnPlayerEvent;
        }

        /* -------------------------------------------------------------------------- */
    }
}
