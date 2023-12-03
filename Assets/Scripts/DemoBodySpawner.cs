using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

public class DemoBodySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int intervalDistance;
    private GameObject[] spawnedObjects;
    VisualElement root;
    SliderInt slider;

    private void Start() {

        root = GetComponent<UIDocument>().rootVisualElement;
        slider = root.Q<SliderInt>("NumberOfPlanetsSlider");

        spawnedObjects = new GameObject[slider.highValue];
    }

    public void SpawnObject() {
        int numberOfObjects = slider.value;

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
