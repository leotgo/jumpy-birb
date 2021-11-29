using UnityEngine;
using UnityEngine.UI;

namespace JumpBirdGame
{
    public class UIScoreText : MonoBehaviour
    {
        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private ScoreTracker _scoreTracker;
        [SerializeField] private Text _text;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            _scoreTracker.OnScoreChange += OnScoreChanged;
        }

        /* --------------------------- Game Event Handlers -------------------------- */

        private void OnScoreChanged(int newValue)
        {
            _text.text = newValue.ToString();
        }

        /* -------------------------------------------------------------------------- */
    }
}
