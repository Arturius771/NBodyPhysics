using UnityEngine;
using UnityEngine.UI;

public class DemoBodySpawner : MonoBehaviour
{
    public GameObject body;
    public GameObject numberOfPlanetsSlider;
    public int intervalDistance;
    public GameObject[] spawnedBodies; 

    private void Start() {
        spawnedBodies = new GameObject[(int)numberOfPlanetsSlider.GetComponent<Slider>().maxValue];
    }

    public void SpawnObject() {
        int numberOfPlanets = (int)numberOfPlanetsSlider.GetComponent<Slider>().value;

        if(numberOfPlanets > 0) {
            Vector3 position = new(numberOfPlanets * intervalDistance, 0, 0);

            if (spawnedBodies[numberOfPlanets - 1] == null) {
                GameObject spawnBody = Instantiate(body, position, Quaternion.identity);
                spawnedBodies[numberOfPlanets - 1] = spawnBody;
            }
            else {
                Destroy(spawnedBodies[numberOfPlanets]);
            }
            
        }
        else {
            foreach (GameObject body in spawnedBodies)
            {
                Destroy(body);
            }
        }
    }
}
