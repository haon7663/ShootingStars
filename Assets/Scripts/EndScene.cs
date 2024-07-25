using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    [SerializeField] private GameObject p1WinObject;
    [SerializeField] private GameObject p2WinObject;
    private void Start()
    {
        var p1 = 0;
        var p2 = 0;
        foreach (var playerGameStat in GameManager.Inst.playerGameStats)
        {
            switch (playerGameStat)
            {
                case PlayerGameStat.P1:
                    p1++;
                    break;
                case PlayerGameStat.P2:
                    p2++;
                    break;
            }
        }
        if(p1 < p2)
            p1WinObject.SetActive(true);
        else
            p2WinObject.SetActive(true);
        
        Invoke(nameof(FadeIn), 4);
    }

    private void FadeIn()
    {
        Fade.Inst.FadeIn("Title");
    }
}
