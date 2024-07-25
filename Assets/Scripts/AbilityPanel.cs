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

    public void Initialize(PatternSO patternSO)
    {
        _patternSO = patternSO;
        
        iconImage.sprite = patternSO.iconSprite;
        nameText.text = patternSO.name;
        descriptionText.text = patternSO.description;
    }

    public void AddAbility()
    {
        BattleManager.Inst.SelectedPlayer.AddPattern(_patternSO);
    }
}
