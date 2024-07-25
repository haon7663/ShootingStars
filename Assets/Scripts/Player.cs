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

    public enum PlayerNumber
    {
        PL1,PL2
    }
    [SerializeField] private PlayerNumber playerNumber;

    private void Update()
    {
        Move();

        foreach (var pattern in patterns)
        {
            
        }
    }

    private void Move()
    {
        float x = 0, y = 0;
        if (playerNumber == PlayerNumber.PL1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                y = 1;
            }
            else if (Input.GetKey(KeyCode.S))
                y = -1;
            else
                y = 0;
            if (Input.GetKey(KeyCode.A))
                x = -1;
            else if (Input.GetKey(KeyCode.D)) x = 1;
            else x = 0;

        }
        else if (playerNumber == PlayerNumber.PL2)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                y = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
                y = -1;
            else
                y = 0;
            if (Input.GetKey(KeyCode.LeftArrow))
                x = -1;
            else if (Input.GetKey(KeyCode.RightArrow )) x = 1;
            else x = 0;
        }
       

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
