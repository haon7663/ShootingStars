using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum PlayerNumber
{
    Pl1,Pl2
}

public class Player : MonoBehaviour
{
    private Animator _animator;
    private Health _health;
    
    public List<PatternSO> patterns;

    [SerializeField] private Transform target;
    
    [SerializeField] private float moveSpeed,dashSpeed,dashChargeCool;
    [SerializeField] int dashMaxCount,curDashCount;
    float curDashChargeCool;
    [SerializeField] private Vector2 angleVec;
    [FormerlySerializedAs("dashUI")] [SerializeField] private GameObject[] dashUIs;

    Rigidbody2D rigid;
    GhostEffect ghostEffect;

    private float _dashTime;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ghostEffect = GetComponent<GhostEffect>();
        _animator = GetComponent<Animator>();
        curDashChargeCool = dashChargeCool;
    }
    
    public PlayerNumber playerNumber;

    private void Awake()
    {
        _health = GetComponentInChildren<Health>();
    }

    private void Update()
    {
        if (!BattleManager.Inst.isPlaying)
            return;
        
        Move();

        foreach (var pattern in patterns)
        {
            pattern.UpdateCall(transform, angleVec, _health);
        }

        Dash();
        _dashTime -= Time.deltaTime;

        if(curDashCount < dashMaxCount)
        {
            if(curDashChargeCool>0)
                curDashChargeCool -= Time.deltaTime;
            else
            {
                curDashChargeCool = dashChargeCool;
                curDashCount++;
                SetDashUI();
            }
        }
    }
    

    private void Move()
    {
        if (_dashTime > 0)
        {
            _animator.SetBool("isRun", false);
            return;
        }
        
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
        {
            angleVec = new Vector3(x, y, 0).normalized;
            _animator.SetBool("isRun", true);
            if(x != 0)
                transform.localScale = new Vector3(x, 1);
        }
        else
        {
            _animator.SetBool("isRun", false);
        }
        Vector3 moveDirection = new Vector3(x, y, 0).normalized;

        float moveX = moveDirection.x * moveSpeed * Time.deltaTime;
        float moveY = moveDirection.y * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveX, moveY, 0));
    }

    void Dash()
    {
        if(curDashCount > 0)
        {
            switch (playerNumber)
            {
                case PlayerNumber.Pl1:
                    if (Input.GetKeyDown(KeyCode.LeftShift))
                        DashMove();
                    break;
                case PlayerNumber.Pl2:
                    if (Input.GetKeyDown(KeyCode.RightShift))
                        DashMove();
                    break;
            }
        }  
    }

    void DashMove()
    {
        if (_dashTime > 0)
            return;
        
        ghostEffect.ActiveGhost(0.2f);
        _health.OnDashInv(0.15f);
        rigid.velocity = new Vector2(angleVec.x, angleVec.y) * dashSpeed;
        transform.localScale = new Vector3(angleVec.x > 0 ? 1 : -1, 1);
        curDashCount--;
        _dashTime = 0.15f;
        SetDashUI();
        StartCoroutine(WaitVelocity());
    }

    IEnumerator WaitVelocity()
    {
        yield return new WaitForSeconds(0.15f);
        rigid.velocity = Vector2.zero;
    }

    public void AddPattern(PatternSO patternSO)
    {
        patterns.Add(patternSO);
    }

    private void SetDashUI()
    {
        for (int i = 0; i < 3; i++)
        {
            dashUIs[i].SetActive(curDashCount > i); 
        }
    }
}
