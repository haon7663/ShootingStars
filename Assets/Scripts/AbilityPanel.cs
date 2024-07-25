using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPanel : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;

    private PatternSO _patternSO;
    private Player _player;

    public void Initialize(PatternSO patternSO, Player player)
    {
        _patternSO = patternSO;
        
        iconImage.sprite = patternSO.iconSprite;
        nameText.text = patternSO.name;
        descriptionText.text = patternSO.description;

        _player = player;
    }

    public void AddAbility()
    {
        _player.AddPattern(_patternSO);
        switch (_player.playerNumber)
        {
            case PlayerNumber.Pl1:
                AbilityManager.Inst.CloseP1Panel();
                AbilityManager.Inst.ShowPanel(BattleManager.Inst.p2);
                break;
            case PlayerNumber.Pl2:
                AbilityManager.Inst.CloseP2Panel();
                BattleManager.Inst.isPlaying = true;
                break;
        }
    }
}
