using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class DemoBodySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject sliderController;
    [SerializeField] private int intervalDistance;
    private GameObject[] spawnedObjects; 

    private void Start() {
        spawnedObjects = new GameObject[(int)sliderController.GetComponent<Slider>().maxValue];
    }

    public void SpawnObject() {
        int numberOfObjects = (int)sliderController.GetComponent<Slider>().value;

        if(numberOfObjects > 0) {
            Vector3 spawnPosition = new(numberOfObjects * intervalDistance, 0, 0);

            if (spawnedObjects[numberOfObjects - 1] == null) {
                GameObject spawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
                spawnedObject.GetComponent<NetworkObject>().Spawn();
                spawnedObjects[numberOfObjects - 1] = spawnedObject;
            }
            else {
                Destroy(spawnedObjects[numberOfObjects]);
            }
            
        }
        else {
            foreach (GameObject objectInstance in spawnedObjects)
            {
                Destroy(objectInstance);
            }
        }
    }
}
