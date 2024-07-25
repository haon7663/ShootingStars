using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum EmissionType { Angle, Entire, }
public enum FireType { Immediate, Sequence }

[CreateAssetMenu(menuName = "ScriptableObject/PatternSO", fileName = "PatternSO")]
public class PatternSO : ScriptableObject
{
    public Projectile projectilePrefab;

    [Space]
    public int multiShotCount;
    public float multiShotInterval;

    [Space]
    public EmissionType emissionType;
    public int projectileCount;
    [DrawIf("emissionType", EmissionType.Angle)]
    public float intervalAngle;
    
    [Space]
    public FireType fireType;
    [DrawIf("fireType", FireType.Sequence)]
    public float sequenceInterval;
    
    [Space]
    public float duration;
}
