using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace JumpBirdGame
{
    public class GameUIDirector : MonoBehaviour
    {
        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [Header("UI Element References")]
        [SerializeField] private CanvasGroup _tutorialUI;
        [SerializeField] private CanvasGroup _gameplayUI;
        [SerializeField] private CanvasGroup _restartUI;
        [SerializeField] private CanvasGroup _pauseUI;

        [Header("Animation")]
        [SerializeField] private float _fadeTime = 0.5f;

        /* ----------------------------- Runtime Fields ----------------------------- */

        private bool _initialized = false;

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
#if UNITY_EDITOR
            AssertReferences();
#endif
            _tutorialUI.gameObject.SetActive(false);
            _gameplayUI.gameObject.SetActive(false);
            _restartUI.gameObject.SetActive(false);
            _pauseUI.gameObject.SetActive(false);
        }

#if UNITY_EDITOR
        private void AssertReferences()
        {
            Debug.Assert(_tutorialUI != null);
            Debug.Assert(_gameplayUI != null);
            Debug.Assert(_restartUI  != null);
            Debug.Assert(_pauseUI    != null);
        }
#endif

        /* --------------------------------- Actions -------------------------------- */

        public void Pause()
        {
            Debug.Log("Player requested a pause");
            UIManager.Instance.TogglePause();
        }

        public void Resume()
        {
            Debug.Log("Player requested to resume game");
            UIManager.Instance.TogglePause();
        }

        public void PlayAgain()
        {
            Debug.Log("Player requested to play again");
            UIManager.Instance.Restart();
        }

        public void RequestMainMenu()
        {
            Debug.Log("Player requested to return to the main menu");
            UIManager.Instance.RequestMainMenu();
        }

        /* -------------------------- Game Event Callbacks -------------------------- */

        public void ShowTutorialUI()
        {
            _tutorialUI.interactable = true;
            _tutorialUI.gameObject.SetActive(true);
            _tutorialUI.alpha = 0f;
            _tutorialUI.DOFade(1f, _fadeTime);
        }

        public void HideTutorialUI()
        {
            _tutorialUI.interactable = false;
            _tutorialUI.DOFade(0f, _fadeTime).onComplete += () => _tutorialUI.gameObject.SetActive(false);
        }

        public void ShowGameplayUI()
        {
            _gameplayUI.interactable = true;
            _gameplayUI.gameObject.SetActive(true);
            _gameplayUI.alpha = 0f;
            _gameplayUI.DOFade(1f, _fadeTime);
        }

        public void HideGameplayUI()
        {
            _gameplayUI.interactable = false;
            _gameplayUI.DOFade(0f, _fadeTime).onComplete += () => _gameplayUI.gameObject.SetActive(false);
        }

        public void ActivateGameplayUI()
        {
            _gameplayUI.gameObject.SetActive(true);
        }

        public void DeactivateGameplayUI()
        {
            _gameplayUI.gameObject.SetActive(false);
        }

        public void ShowPauseUI()
        {
            _pauseUI.interactable = true;
            _pauseUI.gameObject.SetActive(true);
        }

        public void HidePauseUI()
        {
            _pauseUI.interactable = false;
            _pauseUI.gameObject.SetActive(false);
        }

        public void ShowRestartUI()
        {
            _restartUI.interactable = true;
            _restartUI.gameObject.SetActive(true);
            _restartUI.alpha = 0f;
            _restartUI.DOFade(1f, _fadeTime);
        }

        /* -------------------------------------------------------------------------- */
    }
}
