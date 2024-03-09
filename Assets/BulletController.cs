using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5f;

    void Update() {
        // Move the projectile in its direction at the specified speed
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
