using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class AudioEventPlayer : MonoBehaviour
    {
        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private MonoBehaviour _eventSource;
        [SerializeField] private AudioSource[] _audioSources; 
        [SerializeField] private SoundMap _soundMap;

        /* ----------------------------- Runtime Fields ----------------------------- */
        private bool _initialized = false;
        private IScriptableEventSource _source;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            Initialize();
        }

        /* ----------------------------- Initialization ----------------------------- */

        private void Initialize()
        {
            if(_initialized)
                return;

            if(_eventSource is IScriptableEventSource)
            {
                _source = _eventSource as IScriptableEventSource;
                _source.OnRaiseEvent += OnSourceRaiseEvent;
            }
#if UNITY_EDITOR
            AssertReferences();
#endif
        }

#if UNITY_EDITOR
        private void AssertReferences()
        {
            Debug.Assert(_eventSource != null);
            Debug.Assert(_source != null);
            Debug.Assert(_audioSources != null);
            Debug.Assert(_soundMap != null);
        }
#endif

        /* ----------------------------- Event Callbacks ---------------------------- */

        private void OnSourceRaiseEvent(ScriptableEvent evt)
        {
            if(_soundMap.HasEvent(evt))
            {
                SoundEffect effect = _soundMap.GetSoundEffect(evt);
                PlaySoundEffect(effect);
            }
        }

        private void PlaySoundEffect(SoundEffect effect)
        {
            AudioSource source = GetFirstAvailableAudioSource();
            source.clip = effect.Clip;
            source.pitch = effect.Pitch;
            source.volume = effect.Volume;
            source.Play();
        }

        private AudioSource GetFirstAvailableAudioSource()
        {
            foreach(var source in _audioSources)
            {
                if(!source.isPlaying)
                    return source;
            }
            return _audioSources[0];
        }

        /* -------------------------------------------------------------------------- */
    }
}
