using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace JumpBirdGame
{
    public class PlayerTouchInputHandler : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private LayerMask _collisionMask; 

        /* ------------------------------ Unity Events ------------------------------ */

        private void Update()
        {
            // Make UI Block Scene Raycasts
            if(EventSystem.current.IsPointerOverGameObject())
                return;

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    HandleTouch(touch.position);
                    
                }
            }
            else if (Input.GetMouseButtonDown(0))
            {
                HandleTouch(Input.mousePosition);
            }
        }

        private void HandleTouch(Vector2 position)
        {
            // Debug.Log($"Touch at: {position}");
            Ray ray = Camera.main.ScreenPointToRay(position);
            var hit = Physics2D.Raycast(ray.origin, ray.direction, 10f, _collisionMask.value);
            if(hit.collider != null)
            {
                _player.Jump();
            }
        }

        /* -------------------------------------------------------------------------- */
    }
}
