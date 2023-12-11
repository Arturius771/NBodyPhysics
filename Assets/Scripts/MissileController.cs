using UnityEngine;

public class MissileController : MonoBehaviour {
    [SerializeField] int speed = 10;
    [SerializeField] int maxRange = 500; // TODO
    public GameObject target;

    public void FixedUpdate() {
        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.fixedDeltaTime);
            transform.LookAt(target.transform);
        }
        else {
            Destroy(this.gameObject);
        }
    }
}