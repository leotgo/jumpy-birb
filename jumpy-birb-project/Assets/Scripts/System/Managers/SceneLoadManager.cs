using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

namespace JumpBirdGame
{
    public class SceneLoadManager : MonoBehaviour
    {
        /* -------------------------------- Singleton ------------------------------- */

        public static SceneLoadManager Instance
        {
            get => _instance;
        }

        private static SceneLoadManager _instance = null;

        /* ------------------------------- Properties ------------------------------- */

        public SceneLoadEventData Events
        {
            get => _events;
        }

        public GlobalEventSource EventSource
        {
            get => _eventSource;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [Header("Game Scenes")]
        [SerializeField] private int _sceneMainMenu = 1;
        [SerializeField] private int _sceneGame = 2;

        [Header("Scene Transition Animation")]
        [SerializeField] private Image _fadeImage;
        [SerializeField] private float _fadeTime = 0.2f;

        [Header("Events")]
        [SerializeField] private SceneLoadEventData _events;
        [SerializeField] private GlobalEventSource _eventSource;

        /* ----------------------------- Runtime Fields ----------------------------- */

        private bool _initialized = false;
        private bool _isLoading = false;

        private int _loadedScene;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
#if !(UNITY_EDITOR)
            LoadMainMenu();
#endif
        }

        /* ----------------------------- Initialization ----------------------------- */

        private void Initialize()
        {
            if(_initialized)
                return;

            _loadedScene = 0;
            _isLoading = false;
            _instance = this;

#if UNITY_EDITOR
            AssertReferences();
#endif

            _initialized = true;
        }

        private void AssertReferences()
        {
            Debug.Assert(_instance      != null);
            Debug.Assert(_fadeImage     != null);
        }

        /* -------------------------- Game Event Callbacks -------------------------- */

        public void OnLoadedGameScene(int index)
        {
            _loadedScene = index;
        }

        public void LoadGame()
        {
            LoadGameScene(_sceneGame);
        }

        public void LoadMainMenu()
        {
            LoadGameScene(_sceneMainMenu);
        }

        public void Exit()
        {
            Application.Quit();
        }


        /* ------------------------------ Scene Loading ----------------------------- */

        private void LoadGameScene(int buildIndex)
        {
            if(!_isLoading)
                StartCoroutine(LoadSceneRoutine(buildIndex));
        }

        private IEnumerator LoadSceneRoutine(int buildIndex)
        {
            _isLoading = true;
            _fadeImage.gameObject.SetActive(true);

            // Fade in Black Screen
            var fadeInOperation = _fadeImage.DOFade(1f, _fadeTime).AsyncWaitForCompletion();
            while(!fadeInOperation.IsCompleted)
                yield return new WaitForEndOfFrame();

            // Unload previous scene
            if(_loadedScene > 0)
            {
                var unloadOperation = SceneManager.UnloadSceneAsync(_loadedScene);
                while(!unloadOperation.isDone)
                    yield return new WaitForEndOfFrame();
            }

            // Load next scene
            var loadOperation = SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
            while(!loadOperation.isDone)
                yield return new WaitForEndOfFrame();

            // Fade out Black Screen
            var fadeOutOperation = _fadeImage.DOFade(0f, _fadeTime).AsyncWaitForCompletion();
            while(!fadeOutOperation.IsCompleted)
                yield return new WaitForEndOfFrame();

            _fadeImage.gameObject.SetActive(false);
            _isLoading = false;
        }

        /* -------------------------------- Utilities ------------------------------- */

        public void Raise(ScriptableEvent evt)
        {
            _eventSource.Raise(evt);
        }

        /* -------------------------------------------------------------------------- */
    }
}
