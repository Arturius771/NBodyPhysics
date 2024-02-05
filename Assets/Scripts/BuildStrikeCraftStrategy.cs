using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildStrikeCraftStrategy", menuName = "*/Strategies/BuildStrikeCraftStrategy")]
public class BuildStrikeCraftStrategy : BuildShipStrategy {
    [SerializeField] private GameObject prefabToBuild;
    [SerializeField] private int strikeCraftResourceCost = 50;
    [SerializeField] private int strikeCraftBuildTime = 30;

    public override void BuildShip(Transform spawnLocation) {
        Instantiate(prefabToBuild, spawnLocation.position, Quaternion.identity);

    }

    public override int GetResourceCost() {
        return strikeCraftResourceCost;
    }

    public override int GetBuildTime() {
        return strikeCraftBuildTime;
    }
}


