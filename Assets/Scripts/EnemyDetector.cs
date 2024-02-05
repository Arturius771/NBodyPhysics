using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour {
    [SerializeField] private EnemyEncounterStrategy strategy;
    [SerializeField] private string enemyTeamLayerName = "Team2";
    [SerializeField] private float checkFrequency = 1;
    private readonly List<GameObject> enemies = new();


    private void Start() {
        StartCoroutine(CheckForEnemies());
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer(enemyTeamLayerName)) {
            if (!enemies.Contains(other.gameObject)) {
                enemies.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer(enemyTeamLayerName)) {
            if (enemies.Contains(other.gameObject)) {
                enemies.Remove(other.gameObject);
            }
        }
    }

    IEnumerator CheckForEnemies() {
        while (true) {
            yield return new WaitForSeconds(checkFrequency);

            if (enemies.Count > 0) {
                GameObject closestEnemy = GetClosestEnemy();
                if (closestEnemy != null) {
                    strategy.HandleEncounter(closestEnemy, gameObject);
                }
            }
        }
    }

    private GameObject GetClosestEnemy() {
        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies) {
            if (enemy != null) {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance) {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

        return closestEnemy;
    }
}
