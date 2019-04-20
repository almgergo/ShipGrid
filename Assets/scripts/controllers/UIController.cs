using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject SelectedBuilding;

    public void SelectBuilding(GameObject building) {
        this.SelectedBuilding = building;
    }
}