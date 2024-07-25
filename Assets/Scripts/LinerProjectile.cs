using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LinerProjectile : Projectile
{
    private Rigidbody2D _rigid;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public override void Initialize(Transform shooter, Vector2 targetVec, Health owner)
    {
        OwnerHealth = owner;
        
        AngleVec = targetVec;
        transform.position = shooter.position;
        _rigid.velocity = targetVec * moveSpeed;
    }
}
