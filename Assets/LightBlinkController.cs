using System.Collections;
using UnityEngine;

public class LightBlinkController : MonoBehaviour {
    [SerializeField] float blinkFrequency; // Change int to float for WaitForSeconds
    private Light lightComponent;
    private bool active = true;

    // Start is called before the first frame update
    void Start() {
        lightComponent = GetComponent<Light>();
        StartCoroutine(BlinkLight());
    }

    private IEnumerator BlinkLight() {
        while (true) {
            yield return new WaitForSeconds(blinkFrequency);
            active = !active;
            lightComponent.enabled = active;
        }
    }
}
