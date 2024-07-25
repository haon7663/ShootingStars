using UnityEngine;

namespace BezierEngine
{
    public class Bezier
    {
        public Vector2 P1, P2, P3, P4;

        public Bezier(Vector2 setterPos, Vector2 getterPos, float setRadius, float getRadius)
        {
            P1 = setterPos;
            P2 = setterPos + Random.insideUnitCircle * setRadius;
            P3 = getterPos + Random.insideUnitCircle * getRadius;
            P4 = getterPos;
        }
    }
    
    public static class BezierMath
    {
        public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
        {
            t = Mathf.Clamp01(t);
            var oneMinusT = 1 - t;

            return oneMinusT * oneMinusT * p0 +
                   2f * oneMinusT * t * p1 +
                   t * t * p2;
        }

        public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            t = Mathf.Clamp01(t);
            var oneMinusT = 1 - t;

            return oneMinusT * oneMinusT * oneMinusT * p0 +
                   3f * oneMinusT * oneMinusT * t * p1 +
                   3f * oneMinusT * t * t * p2 +
                   t * t * t * p3;
        }
        
        public static Vector3 GetPoint(Bezier bezier, float t)
        {
            return GetPoint(bezier.P1, bezier.P2, bezier.P3, bezier.P4, t);
        }
    }
}