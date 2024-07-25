using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float damage;

    protected Health OwnerHealth;
    protected Vector2 AngleVec;

    private void Start()
    {
        Destroy(gameObject, 3);
    }

    public abstract void Initialize(Transform shooter, Vector2 targetVec, Health owner);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out var health))
        {
            if (OwnerHealth == health)
                return;
            
            if(health.OnDamage(damage, AngleVec))
                Destroy(gameObject);
        }
    }
}
