using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class PlayerSpriteSelector : MonoBehaviour
    {
        /* ------------------------------- Properties ------------------------------- */

        public int TargetIndex
        {
            get => _targetSpriteIndex;
            set
            {
                if(value >= 0 && value < _targetSpritesAsset.Count)
                {
                    _targetSpriteIndex = value;
                    _spriteRenderer.sprite = _targetSpritesAsset[(int)_targetSpriteIndex];
                }
                else
                {
                    _targetSpriteIndex = 0;
                }
            }
        }

        /* -------------------------- Component References -------------------------- */

        [Header("Component References")]
        [SerializeField] private SpriteRenderer _spriteRenderer;

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [Header("Default Values")]
        [SerializeField] int                   _defaultSpriteIndex;
        [SerializeField] PlayerSpriteAnimation _defaultSpriteAsset;

        /* ----------------------------- Runtime Fields ----------------------------- */

        private bool initialized = false;

        private int                   _targetSpriteIndex;
        private PlayerSpriteAnimation _targetSpritesAsset;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            if(!initialized)
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
            _targetSpritesAsset = _defaultSpriteAsset;
            TargetIndex = _defaultSpriteIndex;
        }

        private void AssertReferences()
        {
            Debug.Assert(_defaultSpriteIndex >= 0);
            Debug.Assert(_defaultSpriteAsset != null);
        }

        /* -------------------------- Game Event Callbacks -------------------------- */

        public void OnVisualsUpdated()
        {
            _targetSpritesAsset = VisualStyleManager.Instance.PlayerSpriteAnim;
        }

        /* -------------------------------------------------------------------------- */
    }
}