using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MoveObject : MonoBehaviour
{
    private float _x, _y;
    private float _fAngle;
    
    private void Start()
    {
    }

    private void Update()
    {
        _fAngle += Mathf.PI * Time.deltaTime;
        _x = Mathf.Cos(_fAngle);
        _y = Mathf.Sin(_fAngle);
        
        transform.position = new Vector3(_x, _y);
    }
}
