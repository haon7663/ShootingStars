using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class Player : MonoBehaviour
{
    private Health _health;
    
    [SerializeField] private List<PatternSO> patterns;

    [SerializeField] private Transform target;
    
    [SerializeField] private float moveSpeed,dashSpeed;
    [SerializeField] private Vector2 angleVec;

    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public enum PlayerNumber
    {
        Pl1,Pl2
    }
    [SerializeField] private PlayerNumber playerNumber;

    private void Awake()
    {
        _health = GetComponentInChildren<Health>();
    }

    private void Update()
    {
        Move();

        foreach (var pattern in patterns)
        {
            pattern.UpdateCall(transform.position, angleVec, _health);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Dash();
        }
    }

    private void Move()
    {
        float x = 0, y = 0;
        switch (playerNumber)
        {
            case PlayerNumber.Pl1:
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
                break;
            }
            case PlayerNumber.Pl2:
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
                break; 
            }
        }

        if (x != 0 || y != 0)
            angleVec = new Vector3(x, y, 0).normalized;
        Vector3 moveDirection = new Vector3(x, y, 0).normalized;

        float moveX = moveDirection.x * moveSpeed * Time.deltaTime;
        float moveY = moveDirection.y * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveX, moveY, 0));
    }

    void Dash()
    {
        rigid.velocity = new Vector2(angleVec.x, angleVec.y) * dashSpeed;
        StartCoroutine(WaitVelocity());
    }

    IEnumerator WaitVelocity()
    {
        yield return new WaitForSeconds(0.1f);
        rigid.velocity = Vector2.zero;
    }
}
