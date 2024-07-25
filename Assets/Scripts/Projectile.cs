using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float damage;

    public abstract void Initialize(Vector2 startVec, Vector2 targetVec);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out var health))
        {
            health.OnDamage(damage);
        }
    }
}
