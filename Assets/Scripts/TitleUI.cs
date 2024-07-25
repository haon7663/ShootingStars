using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        
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
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            pl2Ready = true;
            buttons[1].sprite = buttonPushSprite[1];
        }
        else
        {
            pl2Ready = false;
        }

        if(pl1Ready && pl2Ready)
        {
            GameStart();
        }
    }

    // Update is called once per frame
    public void GameStart()
    {
        // 게임 시작
        SceneManager.LoadScene(0);
    }
}
