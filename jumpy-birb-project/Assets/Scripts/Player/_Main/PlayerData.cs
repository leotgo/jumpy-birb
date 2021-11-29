using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "jumpy-birb/Player/Player Data", order = 1)]
    public class PlayerData : ScriptableObject
    {
        /* ------------------------------- Properties ------------------------------- */
 
        public PlayerAnimationData Animation
        {
            get => _animationData;
        }

        public PlayerPhysicsData Physics
        {
            get => _physicsData;
        }

        public PlayerEventData Events
        {
            get => _eventData;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private PlayerAnimationData _animationData;
        [SerializeField] private PlayerPhysicsData _physicsData;
        [SerializeField] private PlayerEventData _eventData;

        /* -------------------------------------------------------------------------- */
    }
}