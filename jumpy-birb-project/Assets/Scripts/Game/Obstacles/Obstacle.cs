using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class Obstacle : MonoBehaviour, IHitboxOwner
    {
        /* ------------------------ Inspector-Assigned Fields ----------------------- */
        
        [SerializeField] private Transform _upperPipe;
        [SerializeField] private Transform _lowerPipe;
        [SerializeField] private SpriteRenderer[] _renderers;

        /* ----------------------------- Runtime Fields ----------------------------- */

        private bool _initialized = false;
        private bool _playerScored = false;
        private float _defaultWidth;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            Initialize();
        }

        private void OnEnable()
        {
            _playerScored = false;
            foreach(var r in _renderers)
            {
                r.sprite = VisualStyleManager.Instance.PipeSprite;
            }
        }

        private void FixedUpdate()
        {
            if(!_playerScored && transform.position.x < GameManager.Instance.DefaultPlayerPosition.x)
            {
                _playerScored = true;
                Player.Instance.PassObstacle();
            }
        }

        /* ----------------------------- Initialization ----------------------------- */

        private void Initialize()
        {
            if(_initialized)
                return;

            _defaultWidth = transform.localScale.x;
        }

        /* ----------------------------- Obstacle Setup ----------------------------- */

        public void SetHeightCenterOffset(float heightOffset)
        {
            transform.position = transform.position + Vector3.up * heightOffset;
        }

        public void SetObstacleAperture(float aperture)
        {
            _upperPipe.transform.localPosition = Vector3.up * aperture / 2f;
            _lowerPipe.transform.localPosition = Vector3.down * aperture / 2f;
        }

        public void SetObstacleWidth(float width)
        {
            transform.localScale = Vector3.up * 1f + Vector3.forward * 1f + Vector3.right * width;
        }

        /* ------------------------------- Game Events ------------------------------ */

        public void OnHitboxCollision(IPhysicsEntity2D entity)
        {
            if(entity is Player)
            {
                var player = entity as Player;
                player.HitObstacle();
            }
        }

        /* -------------------------------------------------------------------------- */
    }
}
