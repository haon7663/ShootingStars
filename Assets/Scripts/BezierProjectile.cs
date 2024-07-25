using System;
using UnityEngine;
using BezierEngine;
using UnityEngine.Serialization;

public class BezierProjectile : Projectile
{
    private TrailRenderer _trailRenderer;
    
    [SerializeField] private float setRadius;
    [SerializeField] private float getRadius;

    private Bezier _bezier;
    private float _t;

    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    public override void Initialize(Vector2 startVec, Vector2 targetVec, Health owner)
    {
        OwnerHealth = owner;
        
        _bezier = new Bezier(startVec, targetVec, setRadius, getRadius);

        transform.position = startVec;
        _trailRenderer.emitting = true;
    }

    private void Update()
    {
        _t += moveSpeed * Time.deltaTime;
        transform.position = BezierMath.GetPoint(_bezier, _t);
    }
}
