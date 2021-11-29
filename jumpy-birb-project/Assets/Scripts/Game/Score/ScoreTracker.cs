using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class ScoreTracker : MonoBehaviour
    {
        /* ------------------------------- Properties ------------------------------- */

        public int PlayerScore
        {
            get => _playerScore;
        }

        public int BestScore
        {
            get => _bestScore;
        }

        public bool HasNewBestScore
        {
            get => _hasNewBestScore;
        }

        /* --------------------------------- Events --------------------------------- */

        public event System.Action<int> OnScoreChange;

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private Player _player;

        /* ----------------------------- Runtime Fields ----------------------------- */

        private bool _initialized = false;
        private int _playerScore = 0;
        private int _bestScore = 0;
        private bool _hasNewBestScore = false;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            Initialize();
        }

        /* ----------------------------- Initialization ----------------------------- */

        private void Initialize()
        {
            if (_initialized)
                return;

            SetupDefaultValues();
            SetupBestScore();
            SetupEventHandlers();

            _initialized = true;
        }

        private void SetupDefaultValues()
        {
            _playerScore = 0;
            _bestScore = 0;
            _hasNewBestScore = false;
        }

        private void SetupBestScore()
        {
            bool hasSaveData = SaveManager.Instance.HasSave;
            if(!hasSaveData)
                SaveScore(0);
            else
                _bestScore = SaveManager.Instance.Load().BestScore;
        }

        private void SetupEventHandlers()
        {
            _player.OnRaiseEvent += OnPlayerEvent;
        }

        /* ----------------------------- Event Callbacks ---------------------------- */

        private void OnPlayerEvent(ScriptableEvent evt)
        {
            if(evt == _player.Data.Events.OnScore)
            {
                _playerScore++;
                OnScoreChange?.Invoke(_playerScore);
            }
        }

        public void OnGameplayEnd()
        {
            if(_playerScore > _bestScore)
            {
                _bestScore = _playerScore;
                _hasNewBestScore = true;
                Debug.Log($"Player achieved new best score of {_bestScore}.");
                SaveScore(_bestScore);
            }
        }

        /* -------------------------------- Utilities ------------------------------- */

        private void SaveScore(int score)
        {
            SaveData newBestScoreData = new SaveData();
            newBestScoreData.BestScore = score;
            SaveManager.Instance.Save(newBestScoreData);
        }

        /* -------------------------------------------------------------------------- */
    }
}
