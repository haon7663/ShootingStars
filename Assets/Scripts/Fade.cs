using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : Singleton<Fade>
{
    [SerializeField] private Image image;

    private void Start()
    {
        image.enabled = true;
        FadeOut();
    }

    public void FadeIn()
    {
        var sequence = DOTween.Sequence();
        
        sequence.Append(image.DOFade(1, 0.5f));
        sequence.AppendCallback(() => { SceneManager.LoadScene("Battle"); });
    }
    
    public void FadeOut()
    {
        image.DOFade(0, 0.5f);
    }
}
