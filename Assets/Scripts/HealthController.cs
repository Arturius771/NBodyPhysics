using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int health = 100;
    [SerializeField] private string enemyTeamLayerName = "Team2";

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) {
            Destroy(transform.parent.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.layer == LayerMask.NameToLayer(enemyTeamLayerName)) {
            health -= 10;
            Destroy(other.gameObject);
        }
    }
}
