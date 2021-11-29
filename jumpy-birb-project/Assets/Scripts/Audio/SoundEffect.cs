using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "SoundEffectName", menuName = "jumpy-birb/Audio/Sound Effect", order = 1)]
    public class SoundEffect : ScriptableObject
    {
        /* ------------------------------- Definitions ------------------------------ */

        public enum ClipSelectionStrategy
        {
            First,
            RoundRobin,
            Random
        }

        /* ------------------------------- Properties ------------------------------- */

        public AudioClip Clip
        {
            get => GetNextAudioClip();
        }

        public float Pitch
        {
            get => Random.Range(_pitch.x, _pitch.y);
        }

        public float Volume
        {
            get => Random.Range(_volume.x, _volume.y);
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private AudioClip[] _clips;
        [SerializeField] private ClipSelectionStrategy _clipSelectionStrategy;
        [SerializeField, MinMaxSlider(0.5f, 2f)] private Vector2 _pitch = new Vector2(1f, 1f);
        [SerializeField, MinMaxSlider(0f, 1f)] private Vector2 _volume = new Vector2(0.9f, 1f);

        /* ----------------------------- Runtime Fields ----------------------------- */

        // Using a runtime field for a ScriptableObject representing a sound effect
        // was deemed acceptable for the scope of this project, as the collateral
        // effects caused by changes in this index from multiple instances of the same
        // SoundEffect should produce no negative behavior in the Player's perception.
        private RoundRobinIndex _roundRobinIndex;

        /* ----------------------------- Helper Methods ----------------------------- */

        private AudioClip GetNextAudioClip()
        {
            if(_clips == null || _clips.Length == 0)
            {
                Debug.LogError($"Error: Unable to select a valid {typeof(AudioClip)} for {typeof(SoundEffect)} {name}.");
                return null;
            }

            switch(_clipSelectionStrategy)
            {
                case ClipSelectionStrategy.First:
                    return _clips[0];
                case ClipSelectionStrategy.Random:
                    return _clips[Random.Range(0, _clips.Length)];
                case ClipSelectionStrategy.RoundRobin:
                default:
                    {
                        if(_roundRobinIndex == null)
                        {
                            _roundRobinIndex = new RoundRobinIndex(0, _clips.Length - 1);
                        }
                        return _clips[_roundRobinIndex.Value];
                    }
            }
        }

        /* -------------------------------------------------------------------------- */
    }
}
