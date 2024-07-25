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

    private void ShowPanel(Player player)
    {
        SelectPattern(player);
    }

    private void SelectPattern(Player player)
    {
        var patterns = Resources.LoadAll<PatternSO>("Patterns");
        foreach (var abilityPanel in abilityPanelsP1)
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
        foreach (var abilityPanel in abilityPanelsP1)
        {
            abilityPanel.gameObject.SetActive(false);
        }
    }
    public void CloseP2Panel()
    {
        foreach (var abilityPanel in abilityPanelsP2)
        {
            abilityPanel.gameObject.SetActive(false);
        }
    }
}
