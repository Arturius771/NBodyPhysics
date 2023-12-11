using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnProjectileStrategy", menuName = "*/Strategies/SpawnProjectileStrategy")]
public class SpawnProjectileStrategy : EnemyEncounterStrategy {
    [SerializeField] private GameObject prefab;
    private GameObject enemy;
    private GameObject gameObject; 

    public override void HandleEncounter(GameObject newEnemy, GameObject newGameObject) {
        enemy = newEnemy;
        gameObject = newGameObject;

        GameObject spawnedPrefab = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);

        if (spawnedPrefab.GetComponent<MissileController>()) {
            spawnedPrefab.GetComponent<MissileController>().target = enemy;
        }
    }
}


