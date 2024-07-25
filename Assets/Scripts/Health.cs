using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private Image hpBar;

    [SerializeField] private SpriteRenderer[] spriteRenderers;
    
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material whiteMaterial;
    
    private bool isInv;
    private float _curHp;

    private void Awake()
    {
        _curHp = maxHp;
    }

    public bool OnDamage(float damage)
    {
        if (isInv) return false;
        
        _curHp -= damage;
        hpBar.fillAmount = _curHp / maxHp;

        OnInvincibility(0.25f);
        OnWhite(0.1f);

        if (_curHp < 0)
        {
            //����
        }

        return true;
    }
    
    private void OnInvincibility(float time)
    {
        var sequence = DOTween.Sequence();

        sequence.AppendCallback(() =>
        {
            isInv = true;
        });
        sequence.AppendInterval(time);
        sequence.AppendCallback(() =>
        {
            isInv = false;
        });
    }

    private void OnWhite(float time)
    {
        var sequence = DOTween.Sequence();

        sequence.AppendCallback(() =>
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.material = whiteMaterial;
            }
        });
        sequence.AppendInterval(time);
        sequence.AppendCallback(() =>
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.material = defaultMaterial;
            }
        });
    }
}

