using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GhostSprite : MonoBehaviour
{
    [SerializeField] SpriteRenderer body, hair;
    // Start is called before the first frame update
    void Start()
    {
        body.DOFade(0, .5f);
        hair.DOFade(0, .5f);
        Destroy(body.gameObject, 0.501f);
        Destroy(hair.gameObject, 0.501f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
