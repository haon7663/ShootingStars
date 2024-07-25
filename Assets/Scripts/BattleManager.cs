using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    public Player SelectedPlayer { get; private set; }

    public void SelectPlayer(Player player)
    {
        SelectedPlayer = player;
    }
}
