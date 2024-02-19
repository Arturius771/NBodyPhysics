using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{

    private static List<SpaceshipController> selectedShips = new();

    private void Update() {
        if (Input.GetMouseButtonDown(MouseButton.left)) {
            SelectSingleShip();
        }

        if (Input.GetKeyDown("z")) {
            SelectAllShips();
        }
    }


    private void SetSelectedInShipController(SpaceshipController ship) {
        ship.selected = true; 
    }

    private void SetDeselectedInShipController(SpaceshipController ship) {
        ship.selected = false; 
    }

    private void SelectSingleShip() {

        ClearSelectedShips();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10000000, Color.red, 1f);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) {

            SpaceshipController clickedShip = hit.collider.GetComponent<SpaceshipController>();

            if (clickedShip) {
                selectedShips.Add(clickedShip);

                foreach (SpaceshipController ship in selectedShips) {
                    SetSelectedInShipController(ship);
                }
            }
        }
    }

    private void SelectAllShips() {
        SpaceshipController[] spaceships = FindObjectsOfType<SpaceshipController>();
        selectedShips.AddRange(spaceships);

        foreach (SpaceshipController ship in selectedShips) {
            SetSelectedInShipController(ship);
        }
    }

    private void ClearSelectedShips() {
        foreach (SpaceshipController ship in new List<SpaceshipController>(selectedShips)) { // Need a copy of selectedShips to modify it as we iterate over it
            SetDeselectedInShipController(ship);
            selectedShips.Remove(ship);
        }
    }
}
