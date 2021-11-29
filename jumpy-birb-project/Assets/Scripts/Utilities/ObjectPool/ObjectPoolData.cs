using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "ObjectPoolName", menuName = "jumpy-birb/System/Object Pool Data", order = 1)]
    public class ObjectPoolData : ScriptableObject
    {
        /* ------------------------------- Properties ------------------------------- */

        public GameObject Prefab
        {
            get => _prefab;
        }

        public int Size
        {
            get => _size;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private GameObject _prefab;
        [SerializeField, Range(1, 100)] private int _size = 10;

        /* -------------------------------------------------------------------------- */
    }
}