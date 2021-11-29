using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class GameBackgroundUpdater : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void OnVisualsUpdated()
        {
            _spriteRenderer.sprite = VisualStyleManager.Instance.BackgroundSprite;
        }
    }
}
