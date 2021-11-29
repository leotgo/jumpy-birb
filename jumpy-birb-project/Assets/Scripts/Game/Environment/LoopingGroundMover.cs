using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class LoopingGroundMover : MonoBehaviour
    {
        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        // Component Refs
        [SerializeField] private LevelManager _levelManager = null;

        // Default Values
        [SerializeField] private Transform[] _groundObjects;
        [SerializeField] private Vector3 _moveDir = new Vector3(-1f, 0f, 0f);

        /* ----------------------------- Runtime Fields ----------------------------- */

        private RoundRobinIndex _roundRobinIndex;
        private float _movedDistance;
        private float _groundWidth = 0f;
        private bool _isMoving = true;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            _isMoving = true;
            _movedDistance = 0;
            _roundRobinIndex = new RoundRobinIndex(0, _groundObjects.Length - 1);
            _groundWidth = Mathf.Abs(_groundObjects[0].position.x - _groundObjects[1].position.x);
            Debug.Log("Ground width: " + _groundWidth);
        }

        private void FixedUpdate()
        {
            if(!_isMoving)
                return;

            MoveObjects();
            _movedDistance += _levelManager.ObstacleMoveSpeed * Time.fixedDeltaTime;
            if (_movedDistance >= _groundWidth)
                SpawnNextElement();
        }

        private void MoveObjects()
        {
            foreach (var obj in _groundObjects)
            {
                obj.transform.position += _moveDir * _levelManager.ObstacleMoveSpeed * Time.fixedDeltaTime;
            }
        }

        /* -------------------------------- Utilities ------------------------------- */

        private void SpawnNextElement()
        {
            var targetObj = _groundObjects[_roundRobinIndex.Value];
            targetObj.transform.position = targetObj.position + Vector3.right * _groundWidth * _groundObjects.Length;
            _movedDistance = 0f;
        }

        /* -------------------------- Game Event Callbacks -------------------------- */

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