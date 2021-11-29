using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class ObstacleMover : MonoBehaviour
    {
        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        // Component Refs
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private ObstacleSpawner _spawner;

        [SerializeField] private Vector3 _moveDirection = new Vector3(-1f, 0f, 0f);

        /* ----------------------------- Runtime Fields ----------------------------- */

        private bool _initialized = false;
        private bool _isMoving = false;
        private float _movedDistance = 0f;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            Initialize();
        }

        private void FixedUpdate()
        {
            if(_isMoving)
            {
                MoveObstaclesUpdate();
                CheckObstacleSpawnCondition();
            }
        }

        /* ----------------------------- Initialization ----------------------------- */

        private void Initialize()
        {
            if(_initialized)
                return;

            _movedDistance = 0f;
            _isMoving = false;
        }

        /* ----------------------------- Custom Methods ----------------------------- */

        private void MoveObstaclesUpdate()
        {
            if (_spawner.AreSpawnSlotsEmpty)
            {
                return;
            }

            float moveSpeed = _levelManager.ObstacleMoveSpeed;
            for (int i = 0; i < _spawner.NumActiveObstacles; i++)
            {
                _spawner.ActiveObstacles[i].transform.position += _moveDirection * moveSpeed * Time.deltaTime;
            }
            _movedDistance += moveSpeed * Time.fixedDeltaTime;
        }

        private void CheckObstacleSpawnCondition()
        {
            if(_spawner.AreSpawnSlotsEmpty)
            {
                return;
            }

            if (_movedDistance >= _levelManager.ObstacleDistance)
            {
                _movedDistance = 0f;
                _spawner.SpawnObstacle();
            }
        }

        /* ------------------------------- Game Events ------------------------------ */

        public void StartMoving()
        {
            _isMoving = true;
        }

        public void StopMoving()
        {
            _isMoving = false;
        }

        /* -------------------------------------------------------------------------- */
    }
}
