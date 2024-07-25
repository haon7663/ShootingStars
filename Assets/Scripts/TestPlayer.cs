using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public PatternSO patternSO;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            patternSO.Activate(transform.position, Vector2.right);
    }
}
