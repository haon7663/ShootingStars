using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private List<PatternSO> patterns;

    [SerializeField] private Transform target;
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 angleVec;

    private void Update()
    {
        Move();

        foreach (var pattern in patterns)
        {
            
        }
    }

    private void Move()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(x, y, 0).normalized;

        float moveX = moveDirection.x * moveSpeed * Time.deltaTime;
        float moveY = moveDirection.y * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveX, moveY, 0));
    }

    private void FireProjectile()
    {
        //var projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();
        //projectile.Initialize(transform.position, angleVec);
    }
}
