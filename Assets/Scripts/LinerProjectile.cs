using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerProjectile : Projectile
{
    private Rigidbody2D _rigid;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public override void Initialize(Vector2 startVec, Vector2 targetVec)
    {
        transform.position = startVec;
        _rigid.velocity = targetVec * moveSpeed;
    }
}
