using UnityEngine;
using UnityEngine.UIElements;

public class MissileController : MonoBehaviour {
    [SerializeField] int speed = 200;
    [SerializeField] int maxRange = 1000; // TODO
    public GameObject target;
    private Vector3 startPosition;

    public void Start() {
        startPosition = this.gameObject.transform.position;
    }

    public void FixedUpdate() {
        Vector3 currentPosition = this.gameObject.transform.position;
        float distance = Vector3.Distance(currentPosition, startPosition);
        if(distance > maxRange) {
            Destroy(this.gameObject);
        }

        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.fixedDeltaTime);
            transform.LookAt(target.transform);
        }
        else {
            Destroy(this.gameObject);
        }
    }
}