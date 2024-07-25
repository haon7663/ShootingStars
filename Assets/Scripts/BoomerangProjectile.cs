using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BoomerangProjectile : Projectile
{
    private Rigidbody2D _rigid;

    [SerializeField] private float slowSpeed;
    private Vector2 _angleVec, _saveAngleVec;
    private float _t;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    
    public override void Initialize(Transform shooter, Vector2 targetVec, Health owner)
    {
        OwnerHealth = owner;
        
        transform.position = shooter.position;
        AngleVec = targetVec;
        _angleVec = targetVec * moveSpeed;
        _saveAngleVec = _angleVec;
    }

    private void Update()
    {
        _t += Time.deltaTime * slowSpeed;
        _rigid.velocity = _angleVec - _saveAngleVec * _t;
    }
}
