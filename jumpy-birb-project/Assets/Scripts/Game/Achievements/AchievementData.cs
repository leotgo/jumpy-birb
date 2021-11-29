using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "AchievementsData", menuName = "jumpy-birb/Game/Achievements Data", order = 1)]
    public class AchievementData : ScriptableObject
    {
        /* ------------------------------- Definitions ------------------------------ */

        [System.Serializable]
        public class Achievement
        {
            public int RequiredScore
            {
                get => _requiredScore;
            }

            public Sprite AchievementSprite
            {
                get => _achivementSprite;
            }

            [SerializeField] private int _requiredScore;
            [SerializeField] private Sprite _achivementSprite;
        }

        /* ------------------------------- Properties ------------------------------- */

        public Achievement this[int index]
        {
            get => _achievements[index];
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private Achievement[] _achievements;

        /* ------------------------------- Utilitites ------------------------------- */

        public Achievement GetBestAchievement(int score)
        {
            Achievement current = null;
            foreach(var achievement in _achievements)
            {
                if(score >= achievement.RequiredScore)
                    current = achievement;
            }
            return current;
        }

        /* -------------------------------------------------------------------------- */
    }
}
