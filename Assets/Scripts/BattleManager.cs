using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    public bool isPlaying = false;
    
    public Player SelectedPlayer { get; private set; }

    public Player p1;
    public Player p2;

    public void SelectPlayer(Player player)
    {
        SelectedPlayer = player;
    }
}
