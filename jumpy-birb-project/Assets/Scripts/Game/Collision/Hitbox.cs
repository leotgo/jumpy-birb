using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    [RequireComponent(typeof(Collider2D))]
    public class Hitbox : MonoBehaviour
    {
        /* ------------------------------- Properties ------------------------------- */

        public IHitboxOwner Owner
        {
            get => _owner;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private GameObject _ownerObject;

        /* ----------------------------- Runtime Fields ----------------------------- */

        private bool _initialized = false;
        private IHitboxOwner _owner;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            if(_initialized)
                return;

            _owner = _ownerObject.GetComponent<IHitboxOwner>();
#if UNITY_EDITOR
            AssertReferences();
#endif
            _initialized = true;
        }

#if UNITY_EDITOR
        private void AssertReferences()
        {
            Debug.Assert(_ownerObject != null);
            Debug.Assert(_owner       != null);
        }
#endif
    }
}
