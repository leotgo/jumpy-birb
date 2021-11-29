using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "SoundMap", menuName = "jumpy-birb/Audio/Sound Map", order = 1)]
    public class SoundMap : ScriptableObject
    {
        /* ------------------------------- Definitions ------------------------------ */

        [System.Serializable]
        public struct SoundEvent
        {
            public ScriptableEvent Event
            {
                get => _event;
            }

            public SoundEffect Effect
            {
                get => _effect;
            }

            [SerializeField] private ScriptableEvent _event;
            [SerializeField] private SoundEffect     _effect; 
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private List<SoundEvent> _soundEvents;

        /* ----------------------------- Runtime Fields ----------------------------- */

        private bool _initialized = false;
        private Dictionary<ScriptableEvent, SoundEffect> _soundEventMap;

        /* ----------------------------- Initialization ----------------------------- */

        private void Initialize()
        {
            if(_initialized)
                return;

            _soundEventMap = new Dictionary<ScriptableEvent, SoundEffect>();
            foreach(var soundEvent in _soundEvents)
            {
                _soundEventMap.Add(soundEvent.Event, soundEvent.Effect);
            }
        }

        /* ----------------------------- Public Methods ----------------------------- */

        public bool HasEvent(ScriptableEvent sourceEvent)
        {
            Initialize();

            return _soundEventMap.ContainsKey(sourceEvent);
        }

        public SoundEffect GetSoundEffect(ScriptableEvent sourceEvent)
        {
            Initialize();

            SoundEffect effect = null;
            bool hasEvent = _soundEventMap.TryGetValue(sourceEvent, out effect);
            if(hasEvent)
            {
                return effect;
            }
            else
            {
                Debug.LogError($"Error ({name}): Unable to find {typeof(SoundEffect)} for {typeof(ScriptableEvent)} {sourceEvent.name}");
                return null;
            }
        }

        /* -------------------------------------------------------------------------- */
    }
}
