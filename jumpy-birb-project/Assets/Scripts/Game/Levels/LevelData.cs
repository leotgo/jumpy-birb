using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "jumpy-birb/Game/Level Data", order = 1)]
    public class LevelData : ScriptableObject
    {
        /* ------------------------------- Properties ------------------------------- */

        public float ObstacleAperture
        {
            get => _obstacleAperture;
        }

        public float ObstacleHeightCenterVariance
        {
            get => _obstacleHeightCenterVariance;
        }

        public float ObstacleWidth
        {
            get => _obstacleWidth;
        }

        public float ObstacleMoveSpeed
        {
            get => _obstacleMoveSpeed;
        }

        public float ObstacleDistance
        {
            get => _obstacleDistance;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [Header("Obstacle Properties")]
        [SerializeField] private float _obstacleAperture = 1.25f;
        [SerializeField] private float _obstacleHeightCenterVariance = 2f;
        [SerializeField] private float _obstacleWidth = 1f;
        [SerializeField] private float _obstacleMoveSpeed = 0.75f;
        [SerializeField] private float _obstacleDistance = 2f;

        /* -------------------------------------------------------------------------- */
    }
}
