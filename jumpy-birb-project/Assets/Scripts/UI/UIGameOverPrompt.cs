using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JumpBirdGame
{
    public class UIGameOverPrompt : MonoBehaviour
    {
        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        // Data Refs
        [SerializeField] private AchievementData _achievementData;

        // Component Refs
        [SerializeField] private ScoreTracker _scoreTracker;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _bestScoreText;
        [SerializeField] private Image _newBestScorePrompt;
        [SerializeField] private Image _medalImage;

        /* ------------------------------ Unity Events ------------------------------ */

        private void OnEnable()
        {
            UpdateScoreTexts();
            UpdateAchievementUI();
        }

        /* -------------------------------- Utilities ------------------------------- */

        private void UpdateScoreTexts()
        {
            _scoreText.text = _scoreTracker.PlayerScore.ToString();
            _bestScoreText.text = _scoreTracker.BestScore.ToString();
            _newBestScorePrompt.gameObject.SetActive(_scoreTracker.HasNewBestScore);
        }

        private void UpdateAchievementUI()
        {
            var achievement = _achievementData.GetBestAchievement(_scoreTracker.PlayerScore);
            if(achievement == null)
            {
                _medalImage.gameObject.SetActive(false);
            }
            else
            {
                _medalImage.gameObject.SetActive(true);
                _medalImage.sprite = achievement.AchievementSprite;
            }
        }

        /* -------------------------------------------------------------------------- */
    }
}
