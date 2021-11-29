using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "LevelProgressionData", menuName = "jumpy-birb/Game/Level Progression Data", order = 1)]
    public class LevelProgressionData : ScriptableObject
    {
        /* ------------------------------- Definitions ------------------------------ */

        [System.Serializable]
        public struct GameLevel
        {
            public int RequiredScore
            {
                get => _requiredScore;
            }

            public LevelData Data
            {
                get => _levelData;
            }

            [SerializeField] private int _requiredScore;
            [SerializeField] private LevelData _levelData;
        }

        /* ------------------------------- Properties ------------------------------- */

        public GameLevel this[int index] 
        {
            get => _levels[index];
        }

        public int NumLevels
        {
            get => _levels.Length;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private GameLevel[] _levels;

        /* -------------------------------------------------------------------------- */
    }
}