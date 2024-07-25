using System.Collections;
using UnityEngine;

public enum EmissionType { Angle, Entire, }
public enum FireType { Immediate, Sequence }

[CreateAssetMenu(menuName = "ScriptableObject/PatternSO", fileName = "PatternSO")]
public class PatternSO : ScriptableObject
{
    public Projectile projectilePrefab;

    [Space]
    public int multiShotCount;
    public float multiShotAngleInterval;
    public float multiShotSequenceInterval;

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
    public float coolDownInterval;
    private float _coolDown;

    public IEnumerator Activate(Vector2 startVec, Vector2 targetVec)
    {
        var multiShotAngle = 0f;
        for (var i = 0; i < multiShotCount; i++)
        {
            var emissionAngle = emissionType == EmissionType.Angle ? intervalAngle : 360f / projectileCount;
            for (var j = -projectileCount / 2; j <= projectileCount / 2; j++)
            {
                var targetAngle = Mathf.Atan2(targetVec.y, targetVec.x) + multiShotAngle * j + emissionAngle;
                var targetVector = new Vector2(Mathf.Cos(targetAngle), Mathf.Sin(targetAngle));
                
                var projectile = Instantiate(projectilePrefab);
                projectile.Initialize(startVec, targetVector);

                if (fireType == FireType.Sequence)
                    yield return YieldInstructionCache.WaitForSeconds(sequenceInterval);
            }
            multiShotAngle += multiShotAngleInterval;
            yield return YieldInstructionCache.WaitForSeconds(multiShotSequenceInterval);
        }
    }
}
