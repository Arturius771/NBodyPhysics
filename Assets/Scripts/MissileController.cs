using UnityEngine;

public class MissileController : MonoBehaviour {
    [SerializeField] int speed = 200;
    [SerializeField] int maxRange = 1000;
    public GameObject target;
    private Vector3 startPosition;
    Vector3 lastKnownEnemyPosition;

    public void Start() {
        startPosition = this.gameObject.transform.position;
        lastKnownEnemyPosition = target.transform.position;
    }

    public void FixedUpdate() {
        Vector3 currentPosition = this.gameObject.transform.position;
        float distance = Vector3.Distance(currentPosition, startPosition);

        if (distance > maxRange) {
            transform.position = Vector3.MoveTowards(transform.position, lastKnownEnemyPosition, speed / 2 * Time.fixedDeltaTime);
            speed--;
            if (speed <= 0) {
                Destroy(this.gameObject);
            }
        }
        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, lastKnownEnemyPosition, speed * Time.fixedDeltaTime);
            transform.LookAt(target.transform);
            lastKnownEnemyPosition = target.transform.position;
        }
        else {
            transform.position = Vector3.MoveTowards(transform.position, lastKnownEnemyPosition, speed * Time.fixedDeltaTime);
            if(this.transform.position == lastKnownEnemyPosition) {
                Destroy(this.gameObject);
            }
        }
    }
}