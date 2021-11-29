using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "PlayerAnimationData", menuName = "jumpy-birb/Player/Player Animation Data", order = 1)]
    public class PlayerAnimationData : ScriptableObject
    {
        /* ------------------------------- Properties ------------------------------- */

        public float UpwardsRotation
        {
            get => _upwardsRotation;
        }

        public float MinDownwardsRotation
        {
            get => _minDownwardsRotation;
        }

        public float MaxDownwardsRotation
        {
            get => _maxDownwardsRotation;
        }

        public float MinVerticalSpeed
        {
            get => _minVerticalSpeed;
        }

        public float RotationLerpSpeed
        {
            get => _rotationLerpSpeed;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [Header("Body Rotations")]
        [SerializeField, Range(-180f, 180f)] private float _upwardsRotation = 30;
        [SerializeField, Range(-180f, 180f)] private float _minDownwardsRotation = 0f;
        [SerializeField, Range(-180f, 180f)] private float _maxDownwardsRotation = -90f;

        [Header("Thresholds")]
        [SerializeField, Range(-20f, 0f)] private float _minVerticalSpeed = -10f;

        [Header("Animation Speed")]
        [SerializeField, Range(0f, 10f)] private float _rotationLerpSpeed = 3f;

        /* -------------------------------------------------------------------------- */
    }
}