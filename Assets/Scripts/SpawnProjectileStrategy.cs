using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnProjectileStrategy", menuName = "*/Strategies/SpawnProjectileStrategy")]
public class SpawnProjectileStrategy : EnemyEncounterStrategy {
    [SerializeField] private GameObject prefab;

    public override void HandleEncounter(GameObject enemy, GameObject parentShip) {

        GameObject spawnedPrefab = Instantiate(prefab, parentShip.transform.position, Quaternion.identity);

        if (spawnedPrefab.GetComponent<MissileController>()) {
            spawnedPrefab.GetComponent<MissileController>().target = enemy;
        }
    }
}


