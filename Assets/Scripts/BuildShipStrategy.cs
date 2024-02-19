using UnityEngine;

[CreateAssetMenu(fileName = "BuildShipStrategy", menuName = "*/Strategies/BuildShipStrategy")]
public class BuildShipStrategy : BuildStrategy {
    [SerializeField] private GameObject prefabToBuild;
    [SerializeField] private int strikeCraftMetalResourceCost = 50;
    [SerializeField] private int strikeCraftEnergyDrainRate = 50;
    [SerializeField] private int strikeCraftBuildTime = 30;

    public override void Build(Transform spawnLocation) {
        Instantiate(prefabToBuild, spawnLocation.position, Quaternion.identity);

    }

    public override int GetMetalResourceCost() {
        return strikeCraftMetalResourceCost;
    }

    public override int GetEnergyResourceDrainRate() {
        return strikeCraftEnergyDrainRate;
    }

    public override int GetBuildTime() {
        return strikeCraftBuildTime;
    }
}


