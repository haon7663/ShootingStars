using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private Transform target;

    [SerializeField] Vector2 minPos, maxPos;
    [SerializeField] float speed;

    private void Start()
    {
        InvokeRepeating(nameof(FireProjectile), 0, 0.1f);
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(x, y, 0).normalized;

        float moveX = moveDirection.x * speed * Time.deltaTime;
        float moveY = moveDirection.y * speed * Time.deltaTime;
        transform.Translate(new Vector3(moveX, moveY, 0));
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,minPos.x, maxPos.x),Mathf.Clamp(transform.position.y,minPos.y, maxPos.y));    
    }

    private void FireProjectile()
    {
        var projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();
        projectile.Initialize(transform, target);
    }
}
