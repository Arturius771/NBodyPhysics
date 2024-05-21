using System.Reflection;
using Unity.Netcode;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnProjectileStrategy", menuName = "*/Strategies/SpawnProjectileStrategy")]
public class SpawnProjectileStrategy : EnemyEncounterStrategy {
    [SerializeField] private GameObject prefab;

    public override void HandleEncounter(GameObject enemy, GameObject parentShip) {

        GameObject spawnedPrefab = Instantiate(prefab, parentShip.transform.position, Quaternion.identity);
        spawnedPrefab.GetComponent<NetworkObject>().Spawn();

        if (spawnedPrefab.GetComponent<MissileController>()) {
            spawnedPrefab.GetComponent<MissileController>().target = enemy;
        }
    }
}


