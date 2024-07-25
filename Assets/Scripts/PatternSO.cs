using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PatternSO", fileName = "PatternSO")]
public class PatternSO : ScriptableObject
{
    public Projectile projectilePrefab;

    public float duration;
}
