using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerGameStat { P1, P2, Both }
public class GameManager : SingletonDontDestroyOnLoad<GameManager>
{
    public PlayerGameStat playerGameStat = PlayerGameStat.Both;

    public List<PatternSO> saveP1Patterns = new List<PatternSO>();
    public List<PatternSO> saveP2Patterns = new List<PatternSO>();

    private void Start()
    {
        BattleManager.Inst.p1.patterns = saveP1Patterns;
        BattleManager.Inst.p2.patterns = saveP2Patterns;
    }
}

public static class YieldInstructionCache
{
    public static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();
    public static readonly WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();
    private static readonly Dictionary<float, WaitForSeconds> waitForSeconds = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds WaitForSeconds(float seconds)
    {
        WaitForSeconds wfs;
        if (!waitForSeconds.TryGetValue(seconds, out wfs))
            waitForSeconds.Add(seconds, wfs = new WaitForSeconds(seconds));
        return wfs;
    }
}