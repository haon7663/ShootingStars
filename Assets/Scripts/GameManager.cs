using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerGameStat { P1, P2, Both }
public class GameManager : SingletonDontDestroyOnLoad<GameManager>
{
    public PlayerGameStat playerGameStat = PlayerGameStat.Both;
    public PlayerGameStat[] playerGameStats;
    public int phase;

    public List<PatternSO> saveP1Patterns = new List<PatternSO>();
    public List<PatternSO> saveP2Patterns = new List<PatternSO>();

    public void Initialize()
    {
        playerGameStat = PlayerGameStat.Both;
        playerGameStats = new PlayerGameStat[]
            { PlayerGameStat.Both, PlayerGameStat.Both, PlayerGameStat.Both, PlayerGameStat.Both, PlayerGameStat.Both };
        phase = 0;
        saveP1Patterns = new List<PatternSO>();
        saveP2Patterns = new List<PatternSO>();
    }

    public bool SetGameStats(PlayerGameStat playerStat)
    {
        playerGameStat = playerStat;
        playerGameStats[phase++] = playerStat;

        if (phase > 4)
            return false;
        return true;
    }
    
    void OnEnable()
    {
        // 델리게이트 체인 추가
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        OnScene();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnScene()
    {
        foreach (var p in saveP1Patterns)
        {
            if(BattleManager.Inst)
                BattleManager.Inst.p1.AddPattern(p);
        }
        foreach (var p in saveP2Patterns)
        {
            if(BattleManager.Inst)
                BattleManager.Inst.p2.AddPattern(p);
        }
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