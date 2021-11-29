using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class LevelManager : MonoBehaviour
    {
        /* ------------------------------- Properties ------------------------------- */

        public int CurrentLevel
        {
            get => _currentLevel;
            set
            {
                _currentLevel = value;
                _levelData = _levelProgressionData[_currentLevel].Data;
            }
        }

        public float ObstacleAperture
        {
            get => _levelData.ObstacleAperture;
        }

        public float ObstacleMoveSpeed
        {
            get => _levelData.ObstacleMoveSpeed;
        }

        public float ObstacleDistance
        {
            get => _levelData.ObstacleDistance;
        }

        public float ObstacleHeightCenterVariance
        {
            get => _levelData.ObstacleHeightCenterVariance;
        }

        public float ObstacleWidth
        {
             get => _levelData.ObstacleWidth;
        }
        
        private bool HasNextLevel
        {
            get => _currentLevel < _levelProgressionData.NumLevels - 1;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        // Component Refs
        [SerializeField] private ScoreTracker _scoreTracker;

        // Data Refs
        [SerializeField] private LevelProgressionData _levelProgressionData = null;

        /* ----------------------------- Runtime Fields ----------------------------- */

        private int _currentLevel = 0;
        private LevelData _levelData = null;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            CurrentLevel = 0;
            _scoreTracker.OnScoreChange += OnScoreChange;
        }

        /* -------------------------- Game Event Callbacks -------------------------- */

        public void OnScoreChange(int newScore)
        {
            if(!HasNextLevel)
                return;

            if(newScore >= _levelProgressionData[_currentLevel + 1].RequiredScore)
                CurrentLevel++;
        }

        /* -------------------------------------------------------------------------- */
    }
}