using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadUI : MonoBehaviour
{
    [SerializeField] GameObject pl1HeadUIPrefab, pl2HeadUIPrefab, canvas;
    [SerializeField] GameObject PL1, PL2;
    GameObject pl1HeadUI, pl2HeadUI;
    Camera m_camera;
    // Start is called before the first frame update
    void Start()
    {
        m_camera = Camera.main;
        pl1HeadUI = Instantiate(pl1HeadUIPrefab, PL1.transform.position,Quaternion.identity,canvas.transform);
        pl2HeadUI = Instantiate(pl2HeadUIPrefab, PL2.transform.position, Quaternion.identity, canvas.transform);
        pl1HeadUI.GetComponent<RectTransform>().SetAsFirstSibling();
        pl2HeadUI.GetComponent<RectTransform>().SetAsFirstSibling();
    }

    // Update is called once per frame
    void Update()
    {
        pl1HeadUI.transform.position = m_camera.WorldToScreenPoint(PL1.transform.position + new Vector3(0,1.2f,0));
        pl2HeadUI.transform.position = m_camera.WorldToScreenPoint(PL2.transform.position + new Vector3(0, 1.2f, 0));
    }
}
