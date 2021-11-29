using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class ObjectPool : MonoBehaviour
    {
        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private ObjectPoolData _data;

        private GameObject[] poolObjects;

        /* ----------------------------- Runtime Fields ----------------------------- */

        private bool _initialized = false;
        private RoundRobinIndex _roundRobinIndex;

        /* ------------------------------ Unity Events ------------------------------ */
        private void Awake()
        {
            if(!_initialized)
            {
                Initialize();
            }
        }

        /* ----------------------------- Initialization ----------------------------- */

        private void Initialize()
        {
#if UNITY_EDITOR
            AssertReferences();
#endif
            InstantiatePoolObjects();
            _roundRobinIndex = new RoundRobinIndex(0, _data.Size - 1);
        }

#if UNITY_EDITOR
        private void AssertReferences()
        {
            Debug.Assert(_data != null);
            Debug.Assert(_data.Prefab != null);
            Debug.Assert(_data.Size > 0);
        }
#endif

        private void InstantiatePoolObjects()
        {
            List<GameObject> instantiatedObjects = new List<GameObject>();
            for (int i = 0; i < _data.Size; i++)
            {
                var obj = GameObject.Instantiate(_data.Prefab);
                obj.SetActive(false);
                obj.transform.parent = this.transform;
                instantiatedObjects.Add(obj);
            }
            poolObjects = instantiatedObjects.ToArray();
        }

        /* ----------------------------- Public Methods ----------------------------- */

        public GameObject Retrieve()
        {
            return poolObjects[_roundRobinIndex.Value];
        }

        /* -------------------------------------------------------------------------- */
    }
}