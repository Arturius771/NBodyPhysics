using UnityEngine;

public abstract class BuildStrategy : ScriptableObject {
    public abstract void Build(Transform spawnLocation);
    public abstract int GetResourceCost();
    public abstract int GetBuildTime();
}
