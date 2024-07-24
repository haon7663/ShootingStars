using UnityEngine;
using BezierEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private TrailRenderer trailRenderer;
    
    [SerializeField] private float setterRandomValue;
    [SerializeField] private float getterRandomValue;
    
    [SerializeField] private float speed;
    
    private Vector2 _p0, _p1, _p2, _p3;
    private float _t;

    public void Initialize(Transform setter, Transform getter)
    {
        _p0 = setter.position;
        _p1 = (Vector2)setter.position + Random.insideUnitCircle * setterRandomValue;
        _p2 = (Vector2)getter.position + Random.insideUnitCircle * getterRandomValue;
        _p3 = getter.position;

        transform.position = setter.position;
        trailRenderer.emitting = true;
    }

    private void Update()
    {
        _t += speed * Time.deltaTime;
        transform.position = Bezier.GetPoint(_p0, _p1, _p2, _p3, _t);
    }
}
