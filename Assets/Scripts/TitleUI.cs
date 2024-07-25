using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    bool pl1Ready,pl2Ready;
    [SerializeField] Sprite[] buttonSprite;
    [SerializeField] Sprite[] buttonPushSprite;
    [SerializeField] Image[] buttons;

    private bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            pl1Ready = true;
            buttons[0].sprite = buttonPushSprite[0];
        }
        else
        {
            pl1Ready = false;
            buttons[0].sprite = buttonSprite[0];
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            pl2Ready = true;
            buttons[1].sprite = buttonPushSprite[1];
        }
        else
        {
            pl2Ready = false;
            buttons[1].sprite = buttonSprite[1];
        }

        if(pl1Ready && pl2Ready)
        {
            if (isStart)
                return;
            isStart = true;
            if (GameManager.Inst)
                GameManager.Inst.Initialize();
            GameStart();
        }
    }

    // Update is called once per frame
    public void GameStart()
    {
        Fade.Inst.FadeIn("Battle");
    }
}
