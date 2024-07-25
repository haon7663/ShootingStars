using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private Image hpBar;

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

        if (_curHp < 0)
        {
            //����
        }

        return true;
    }

    public void GetInv(float time)
    {
        StartCoroutine(Inv(time));
    }

    IEnumerator Inv(float time)
    {
        isInv = true;
        yield return new WaitForSeconds(time);
        isInv = false;
    }


}

