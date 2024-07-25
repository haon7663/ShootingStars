using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;

    public abstract void Initialize(Vector2 startVec, Vector2 targetVec);
}
