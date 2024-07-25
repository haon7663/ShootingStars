using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AbilityManager : Singleton<AbilityManager>
{
    [SerializeField] public AbilityPanel[] abilityPanelsP1;
    [SerializeField] public AbilityPanel[] abilityPanelsP2;

    private void Start()
    {
        ShowPanel(BattleManager.Inst.p1);
    }

    public void ShowPanel(Player player)
    {
        SelectPattern(player);
    }

    private void SelectPattern(Player player)
    {
        var patterns = Resources.LoadAll<PatternSO>("Patterns");
        foreach (var abilityPanel in player.playerNumber == PlayerNumber.Pl1 ? abilityPanelsP1 : abilityPanelsP2)
        {
            PatternSO pattern;
            do
            {
                pattern = patterns[Random.Range(0, patterns.Length)];
            } while (player.patterns.Contains(pattern));
            
            abilityPanel.gameObject.SetActive(true);
            abilityPanel.Initialize(pattern, player);
        }
    }

    public void CloseP1Panel()
    {
        Debug.Log("CP1");
        foreach (var abilityPanel in abilityPanelsP1)
        {
            abilityPanel.gameObject.SetActive(false);
        }
    }
    public void CloseP2Panel()
    {
        Debug.Log("CP2");
        foreach (var abilityPanel in abilityPanelsP2)
        {
            abilityPanel.gameObject.SetActive(false);
        }
    }
}
