using UnityEngine;

namespace JumpBirdGame
{
    public class PlayerBodyRotator : MonoBehaviour
    {
        /* -------------------------- Component References -------------------------- */

        [SerializeField] private Player _player;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            UpdateBodyRotation();
        }

        /* ----------------------------- Initialization ----------------------------- */

        private void Initialize()
        {
#if UNITY_EDITOR
            AssertReferences();
#endif
        }

#if UNITY_EDITOR
        private void AssertReferences()
        {
            Debug.Assert(_player != null);
        }
#endif

        /* ---------------------------- Animation Updates --------------------------- */

        private void UpdateBodyRotation()
        {
            bool isMovingUpwards = _player.Velocity.y > 0f;
            if (isMovingUpwards)
            {
                _player.Body.Graphics.transform.rotation = GetUpwardsRotation();
            }
            else
            {
                _player.Body.Graphics.transform.rotation = GetDownwardsRotation();
            }
        }

        private Quaternion GetUpwardsRotation()
        {
            return Quaternion.Euler(0f, 0f, _player.Data.Animation.UpwardsRotation);
        }

        private Quaternion GetDownwardsRotation()
        {
            float targetZAngle = Mathf.Lerp(_player.Data.Animation.MinDownwardsRotation,
                                            _player.Data.Animation.MaxDownwardsRotation,
                                            _player.Velocity.y / _player.Data.Animation.MinVerticalSpeed);
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetZAngle);
            return Quaternion.Lerp(_player.Body.Graphics.transform.rotation,
                                   targetRotation,
                                   _player.Data.Animation.RotationLerpSpeed * Time.deltaTime);
        }

        /* -------------------------------------------------------------------------- */
    }
}