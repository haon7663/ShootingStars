using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private Transform target;

    private void Start()
    {
        InvokeRepeating(nameof(FireProjectile), 0, 0.1f);
    }

    private void FireProjectile()
    {
        var projectile = Instantiate(projectilePrefab).GetComponent<BezierProjectile>();
        projectile.Initialize(transform, target);
    }
}
