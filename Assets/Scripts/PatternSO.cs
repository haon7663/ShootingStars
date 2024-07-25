using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EmissionType { Angle, Entire, }
public enum FireType { Immediate, Sequence }

[CreateAssetMenu(menuName = "ScriptableObject/PatternSO", fileName = "PatternSO")]
public class PatternSO : ScriptableObject
{
    public Projectile projectilePrefab;

    public EmissionType emissionType;
    public FireType fireType;
    
    public float duration;
}
