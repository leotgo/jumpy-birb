using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class RectTransformHoverAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform _target;
        [SerializeField] private float _frequency = 1f;
        [SerializeField] private float _amplitude = 1f;

        private float t;
        private Vector2 _defaultPosition;

        private void Awake()
        {
            t = 0;
            _defaultPosition = _target.anchoredPosition;
        }

        private void Update()
        {
            t += Time.deltaTime * Mathf.PI;
            _target.anchoredPosition = _defaultPosition + Mathf.Sin(t * _frequency) * Vector2.up * _amplitude;
        }
    }
}
