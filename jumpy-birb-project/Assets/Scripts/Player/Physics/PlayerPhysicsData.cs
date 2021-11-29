using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "PlayerPhysicsData", menuName = "jumpy-birb/Player/Player Physics Data", order = 1)]
    public class PlayerPhysicsData : ScriptableObject
    {
        /* ------------------------------- Properties ------------------------------- */

        public float JumpForce
        {
            get => _jumpForce;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] [Range(0f, 10f)] private float _jumpForce = 2f;

        /* -------------------------------------------------------------------------- */
    }
}