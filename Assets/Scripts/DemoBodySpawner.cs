using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

public class DemoBodySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private int intervalDistance;
    [SerializeField] private GameObject uiDocument; // TODO - we need some DI to handle finding the root UIDocument component in other GameObjects
    [SerializeField] private string targetSliderId = "NumberOfPlanetsSlider";
    private GameObject[] spawnedObjects;
    VisualElement root;
    SliderInt slider;
    private System.Random random = new System.Random();

    private void Start() {
        root = uiDocument.GetComponent<UIDocument>().rootVisualElement;
        slider = root.Q<SliderInt>(targetSliderId);
        slider.RegisterCallback<ChangeEvent<int>>(OnSliderValueChanged);

        spawnedObjects = new GameObject[slider.highValue];
    }

    private void OnSliderValueChanged(ChangeEvent<int> valueChangeEvent) {
        SpawnObject();
    }

    public void SpawnObject() {
        int numberOfObjects = slider.value;

        if (numberOfObjects > 0) {
            Vector3 spawnPosition = new(numberOfObjects * intervalDistance, 0, 0);

            if (spawnedObjects[numberOfObjects - 1] == null) {
                int randomPrefab = random.Next(0, prefabs.Length);
                GameObject spawnedObject = Instantiate(prefabs[randomPrefab], spawnPosition, Quaternion.identity);
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
