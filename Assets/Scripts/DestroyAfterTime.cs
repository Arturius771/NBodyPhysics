using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float secondsToWait = 5f;

    // Update is called once per frame
    void Update() { 
        secondsToWait -= Time.deltaTime;
        if (secondsToWait < 0) {
            Destroy(this.gameObject);
        }
    }
}
