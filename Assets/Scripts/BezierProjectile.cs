using System;
using UnityEngine;
using BezierEngine;
using UnityEngine.Serialization;

public class BezierProjectile : MonoBehaviour
{
    private TrailRenderer _trailRenderer;
    
    [SerializeField] private float moveSpeed;
    
    [SerializeField] private float setRadius;
    [SerializeField] private float getRadius;

    private Bezier _bezier;
    private float _t;

    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    public void Initialize(Transform setter, Transform getter)
    {
        _bezier = new Bezier(setter.position, getter.position, setRadius, getRadius);

        transform.position = setter.position;
        _trailRenderer.emitting = true;
    }

    private void Update()
    {
        _t += moveSpeed * Time.deltaTime;
        transform.position = BezierMath.GetPoint(_bezier, _t);
    }
}
