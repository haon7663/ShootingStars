using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DamageTMP : MonoBehaviour
{
    [SerializeField] private TMP_Text damageTMP;
    
    public void Setup(Transform target, int value)
    {
        damageTMP.text = value.ToString();
        
        transform.position = target.position + new Vector3(0, 0.2f);

        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveY(target.position.y - 3f, 1f).SetEase(Ease.InBack));
        sequence.Insert(0, transform.DOMoveX(target.position.x + Random.Range(-2f, 2f), 1f).SetEase(Ease.Linear));
        sequence.Insert(0.7f, damageTMP.DOFade(0f, 0.3f).SetEase(Ease.Linear));
        Destroy(gameObject, 1.01f);
    }
}
