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
    [SerializeField] private Image outlineImage;

    private PatternSO _patternSO;
    private Player _player;

    public void Initialize(PatternSO patternSO, Player player)
    {
        _patternSO = patternSO;
        
        iconImage.sprite = patternSO.iconSprite;
        nameText.text = patternSO.name;
        descriptionText.text = patternSO.description;
        outlineImage.color = player.playerNumber == PlayerNumber.Pl1 ? Color.red : Color.blue;

        _player = player;
    }

    public void AddAbility()
    {
        _player.AddPattern(_patternSO);
        switch (_player.playerNumber)
        {
            case PlayerNumber.Pl1:
                GameManager.Inst.saveP1Patterns.Add(_patternSO);
                AbilityManager.Inst.CloseP1Panel();
                if(GameManager.Inst.playerGameStat == PlayerGameStat.Both)
                    AbilityManager.Inst.ShowPanel(BattleManager.Inst.p2);
                else
                    BattleManager.Inst.isPlaying = true;
                break;
            case PlayerNumber.Pl2:
                GameManager.Inst.saveP2Patterns.Add(_patternSO);
                AbilityManager.Inst.CloseP2Panel();
                BattleManager.Inst.isPlaying = true;
                break;
        }
    }
}
