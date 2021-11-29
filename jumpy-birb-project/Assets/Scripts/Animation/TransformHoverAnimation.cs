using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHoverAnimation : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _frequency = 1f;
    [SerializeField] private float _amplitude = 1f;

    private float t;
    private Vector3 _defaultPosition;

    private void Awake()
    {
        t = 0;
        _defaultPosition = _target.position;
    }

    private void Update()
    {
        t += Time.deltaTime * Mathf.PI;
        _target.position = _defaultPosition + Mathf.Sin(t * _frequency) * Vector3.up * _amplitude;
    }
}
