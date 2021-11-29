using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class UIManager : MonoBehaviour
    {
        /* -------------------------------- Singleton ------------------------------- */

        public static UIManager Instance
        {
            get => _instance;
        }

        private static UIManager _instance = null;

        /* ------------------------------- Properties ------------------------------- */

        public GlobalEventSource UIEventSource
        {
            get => _eventSource;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private UIEventData _events;
        [SerializeField] private GlobalEventSource _eventSource;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            _instance = this;
        }

        /* ------------------------------- Game Events ------------------------------ */

        public void StartGame()
        {
            Raise(_events.OnRequestStartGame);
            SceneLoadManager.Instance.LoadGame();
        }

        public void ExitGame()
        {
            Raise(_events.OnRequestExitGame);
            SceneLoadManager.Instance.Exit();
        }

        public void TogglePause()
        {
            Raise(_events.OnRequestTogglePause);
        }

        public void RequestMainMenu()
        {
            Raise(_events.OnRequestMainMenu);
            SceneLoadManager.Instance.LoadMainMenu();
        }

        public void Restart()
        {
            Raise(_events.OnRequestRestart);
            SceneLoadManager.Instance.LoadGame();
        }

        /* -------------------------------- Utilities ------------------------------- */

        private void Raise(ScriptableEvent evt)
        {
            _eventSource.Raise(evt);
        }

        /* -------------------------------------------------------------------------- */
    }
}
