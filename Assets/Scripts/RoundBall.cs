using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundBall : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private int index;

    private void Start()
    {
        switch (GameManager.Inst.playerGameStats[index])
        {
            case PlayerGameStat.Both:
                image.color = Color.white;
                break;
            case PlayerGameStat.P1:
                image.color = Color.blue;
                break;
            case PlayerGameStat.P2:
                image.color = Color.red;
                break;
        }
    }
}
