using UnityEngine;

namespace JumpBirdGame
{
    public class PlayerBody : MonoBehaviour
    {
        /* ------------------------------- Properties ------------------------------- */

        public SpriteRenderer Graphics
        {
            get => _graphics;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private SpriteRenderer    _graphics;
        [SerializeField] private Animator          _animator;
        [SerializeField] private PlayerBodyRotator _bodyRotator;

        [SerializeField] private string _idleAnimatorParamName = "idle";

        /* ----------------------------- Event Responses ---------------------------- */

        public void SetRotation(bool rotation)
        {
            _bodyRotator.enabled = rotation;
        }

        public void SetFlapping(bool flapping)
        {
            _animator.SetBool(_idleAnimatorParamName, !flapping);
        }

        public void StopRotating()
        {
            _bodyRotator.enabled = false;
        }

        public void StopFlapping()
        {
            _animator.SetBool(_idleAnimatorParamName, true);
        }

        /* -------------------------------------------------------------------------- */
    }
}