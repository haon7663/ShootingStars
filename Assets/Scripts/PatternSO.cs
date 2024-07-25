using System.Collections;
using DG.Tweening;
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

    public void UpdateCall(Vector2 startVec, Vector2 targetVec)
    {
        if (_coolDown < 0)
        {
            Activate(startVec, targetVec);
            _coolDown = coolDownInterval;
        }
        else
        {
            _coolDown -= Time.deltaTime;
        }
    }

    public void Activate(Vector2 startVec, Vector2 targetVec)
    {
        var sequence = DOTween.Sequence();
        
        var multiShotAngle = 0f;
        for (var i = 0; i < multiShotCount; i++)
        {
            var emissionAngle = emissionType == EmissionType.Angle ? intervalAngle : 360f / (projectileCount + 1);
            for (var j = -projectileCount / 2; j <= projectileCount / 2; j++)
            {
                var angle = multiShotAngle;
                var saveJ = j;
                sequence.AppendCallback(() =>
                {
                    var targetAngle = Mathf.Atan2(targetVec.y, targetVec.x) * Mathf.Rad2Deg + angle + emissionAngle * saveJ;
                    var targetRad = targetAngle * Mathf.Deg2Rad;
                    var targetVector = new Vector2(Mathf.Cos(targetRad), Mathf.Sin(targetRad));

                    var projectile = Instantiate(projectilePrefab);
                    projectile.Initialize(startVec, targetVector);
                });

                if (fireType == FireType.Sequence)
                    sequence.AppendInterval(sequenceInterval);
            }
            multiShotAngle += multiShotAngleInterval;
            sequence.AppendInterval(multiShotSequenceInterval);
        }
    }
}
