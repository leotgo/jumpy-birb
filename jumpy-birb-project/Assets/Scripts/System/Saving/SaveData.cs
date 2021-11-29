using System;
using UnityEngine;

namespace JumpBirdGame
{
    [Serializable]
    public class SaveData
    {
        public int BestScore
        {
            get => _bestScore;
            set => _bestScore = value;
        }

        [SerializeField] private int _bestScore;

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

        public void LoadFromJson(string jsonText)
        {
            JsonUtility.FromJsonOverwrite(jsonText, this);
        }
    }
}