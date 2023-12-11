using UnityEngine;

public abstract class EnemyEncounterStrategy : ScriptableObject {
    public abstract void HandleEncounter(GameObject enemy, GameObject gameObject);
}
