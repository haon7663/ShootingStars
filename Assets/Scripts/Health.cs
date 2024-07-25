using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHp, curHp;
    [SerializeField] Image hpBar;
    bool isInv;



    private void Awake()
    {
        curHp = maxHp;
    }

    public void GetDamage(float damage)
    {
        if (isInv) return;
        curHp -= damage;
        hpBar.fillAmount = curHp / maxHp;

        if (curHp < 0)
        {
            //Á×À½
        }
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

