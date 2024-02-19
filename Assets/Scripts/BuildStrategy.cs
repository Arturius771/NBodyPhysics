using UnityEngine;

public abstract class BuildStrategy : ScriptableObject {
    public abstract void Build(Transform spawnLocation);
    public abstract int GetMetalResourceCost();
    public abstract int GetEnergyResourceDrainRate();
    public abstract int GetBuildTime();
}
