using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class VisualStyleManager : MonoBehaviour
    {
        /* -------------------------------- Singleton ------------------------------- */

        public static VisualStyleManager Instance
        {
            get => _instance;
        }

        private static VisualStyleManager _instance = null;

        /* ------------------------------- Properties ------------------------------- */

        public GlobalEventSource EventSource
        {
             get => _eventSource;
        }

        public PlayerSpriteAnimation PlayerSpriteAnim
        {
            get => _targetSpriteAnimation;
        }

        public Sprite BackgroundSprite
        {
            get => _targetBackgroundSprite;
        }

        public Sprite PipeSprite
        {
            get => _targetPipeSprite;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [Header("Event Data")]
        [SerializeField] private GlobalEventSource _eventSource;
        [SerializeField] private ScriptableEvent _onVisualsUpdatedEvent;

        [Header("Style Data")]
        [SerializeField] private VisualStyleData _data;

        /* ----------------------------- Runtime Fields ----------------------------- */

        private TimeOfDay _timeOfDay = TimeOfDay.Day;

        private PlayerSpriteAnimation _targetSpriteAnimation = null;
        private Sprite _targetBackgroundSprite = null;
        private Sprite _targetPipeSprite = null;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            _instance = this;
            SetTimeOfDay(TimeOfDay.Day);
            _targetSpriteAnimation = _data.PlayerSpriteAnims[0];
        }

        /* -------------------------- Game Event Callbacks -------------------------- */

        public void OnGameSceneLoaded()
        {
            RandomizeVisualAssets();
        }

        /* -------------------------------- Utilities ------------------------------- */

        private void RandomizeTimeOfDay()
        {
            SetTimeOfDay((TimeOfDay)Random.Range((int)TimeOfDay.Day, (int)TimeOfDay.Night + 1));
        }

        private void SetTimeOfDay(TimeOfDay value)
        {
            _timeOfDay = value;
            _targetBackgroundSprite = _data.GetBackgroundSprite(value);
            _targetPipeSprite = _data.GetPipeSprite(value);
        }

        private void RandomizeVisualAssets()
        {
            RandomizeTimeOfDay();
            _targetSpriteAnimation = _data.GetRandomPlayerSpriteAnim();
            _eventSource.Raise(_onVisualsUpdatedEvent);
        }

        /* -------------------------------------------------------------------------- */
    }
}
