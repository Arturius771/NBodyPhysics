using Unity.Netcode;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildShipStrategy", menuName = "*/Strategies/BuildShipStrategy")]
public class BuildShipStrategy : BuildStrategy {
    [SerializeField] private GameObject prefabToBuild;
    [SerializeField] private int metalResourceCost = 50;
    [SerializeField] private int energyResourceDrainRate = 50;
    [SerializeField] private int buildTime = 30;

    public override void Build(Transform spawnLocation) {
        GameObject ship = Instantiate(prefabToBuild, spawnLocation.position, Quaternion.identity);

        NetworkManager networkManager = FindObjectsOfType<NetworkManager>()[0];

        ulong id = networkManager.GetComponent<NetworkManager>().LocalClientId;

        Debug.Log(id);
        Debug.Log(networkManager.IsClient);

        ship.GetComponent<NetworkObject>().SpawnWithOwnership(id);
    }

    public override int GetMetalResourceCost() {
        return metalResourceCost;
    }

    public override int GetEnergyResourceDrainRate() {
        return energyResourceDrainRate;
    }

    public override int GetBuildTime() {
        return buildTime;
    }
}


