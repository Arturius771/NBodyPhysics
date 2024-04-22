using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int health = 100;
    [SerializeField] private string enemyTeamLayerName = "Team2";
    [SerializeField] private bool canBeKilled = true;

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) {
            Destroy(this.gameObject);
            if (canBeKilled) {
                Destroy(transform.parent.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer(enemyTeamLayerName) && other.gameObject.name != "EnemyDetector") {
            health -= 1;
        }
    }
}
