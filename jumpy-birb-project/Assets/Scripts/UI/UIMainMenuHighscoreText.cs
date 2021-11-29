using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JumpBirdGame
{
    public class UIMainMenuHighscoreText : MonoBehaviour
    {
        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        // Component Refs
        [SerializeField] private Text _highScoreText;

        // Default Values
        [SerializeField] private string _defaultText = "High Score";

        /* ----------------------------- Runtime Fields ----------------------------- */

        private int _highScore;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            LoadHighScore();
            if (_highScore == 0)
                gameObject.SetActive(false);
        }

        /* -------------------------------- Utilities ------------------------------- */

        private void LoadHighScore()
        {
            var saveData = SaveManager.Instance.Load();
            _highScore = saveData.BestScore;
            _highScoreText.text = $"{_defaultText}: {_highScore}";
        }

        /* -------------------------------------------------------------------------- */
    }
}
