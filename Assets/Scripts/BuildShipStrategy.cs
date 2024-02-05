using UnityEngine;

public abstract class BuildShipStrategy : ScriptableObject {
    public abstract void BuildShip(Transform spawnLocation);
    public abstract int GetResourceCost();
    public abstract int GetBuildTime();
}
