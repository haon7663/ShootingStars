using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GhostEffect : MonoBehaviour
{
    [SerializeField] SpriteRenderer ghost;
    [SerializeField] float ghostSpawnCool;
    bool inGhost;
    float curGhostSpawnCool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curGhostSpawnCool > 0) curGhostSpawnCool -= Time.deltaTime;
        if (inGhost && curGhostSpawnCool<=0)
        {
            curGhostSpawnCool = ghostSpawnCool;
            SpriteRenderer currentGhost = Instantiate(ghost, transform.position, Quaternion.identity);
            currentGhost.transform.localScale = transform.localScale;
        }   
      
    }

    public void ActiveGhost(float time)
    {
        StartCoroutine(GhostActiveCool(time));
    }

    IEnumerator GhostActiveCool(float time)
    {
        inGhost = true;
        yield return new WaitForSeconds(time);
        inGhost = false;
    }
}
