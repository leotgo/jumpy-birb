using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class ObstacleSpawner : MonoBehaviour
    {
        /* ------------------------------- Properties ------------------------------- */

        public bool AreSpawnSlotsEmpty
        {
            get => _numActiveObstacles <= 0;
        }

        public bool AreSpawnSlotsFull
        {
            get => _numActiveObstacles >= _maxSpawnedObstacles;
        }

        public int NumActiveObstacles
        {
            get => _numActiveObstacles;
        }

        public GameObject[] ActiveObstacles
        {
            get => _activeObstacles;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        // Component Refs
        [SerializeField] private LevelManager _levelManager = null;
        [SerializeField] private ObjectPool _pool = null;

        [SerializeField, Range(1, 10)] private int _maxSpawnedObstacles = 4;
        [SerializeField] private Transform _spawnPoint;

        /* ----------------------------- Runtime Fields ----------------------------- */

        private bool _initialized = false;
        private RoundRobinIndex _roundRobinIndex;
        private int _numActiveObstacles = 0;
        private GameObject[] _activeObstacles = null;

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

            _activeObstacles = new GameObject[_maxSpawnedObstacles];
            _roundRobinIndex = new RoundRobinIndex(0, _maxSpawnedObstacles - 1);
            _numActiveObstacles = 0;
#if UNITY_EDITOR
            AssertReferences();
#endif
        }

#if UNITY_EDITOR
        private void AssertReferences()
        {
            Debug.Assert(_pool != null);
            Debug.Assert(_spawnPoint != null);
        }
#endif

        /* ----------------------------- Public Methods ----------------------------- */

        public void SpawnObstacle()
        {
            int index = _roundRobinIndex.Value;
            if (AreSpawnSlotsFull)
            {
                DespawnObstacle(_activeObstacles[index]);
            }
            var obj = _pool.Retrieve();
            _activeObstacles[index] = obj;
            SetupObstacle(obj);

            if (!AreSpawnSlotsFull)
            {
                _numActiveObstacles++;
            }
        }

        /* -------------------------------- Utilities ------------------------------- */

        private void SetupObstacle(GameObject obstacleGameObject)
        {
            obstacleGameObject.SetActive(true);
            obstacleGameObject.transform.position = _spawnPoint.position;

            float aperture = _levelManager.ObstacleAperture;
            float width = _levelManager.ObstacleWidth;
            float heightVariance = _levelManager.ObstacleHeightCenterVariance;
            float height = Random.Range(-heightVariance / 2f, heightVariance / 2f);

            Obstacle obstacle = obstacleGameObject.GetComponent<Obstacle>();
            obstacle.SetObstacleAperture(aperture);
            obstacle.SetHeightCenterOffset(height);
            obstacle.SetObstacleWidth(width);
        }

        private void DespawnObstacle(GameObject obstacleGameObject)
        {
            obstacleGameObject.SetActive(false);
        }

        /* -------------------------------------------------------------------------- */
    }
}