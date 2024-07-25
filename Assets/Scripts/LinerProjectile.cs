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

    public override void Initialize(Vector2 startVec, Vector2 targetVec, Health owner)
    {
        OwnerHealth = owner;
        
        transform.position = startVec;
        _rigid.velocity = targetVec * moveSpeed;
    }
}
