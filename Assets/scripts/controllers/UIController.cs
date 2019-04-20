using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject SelectedBuilding;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void SelectBuilding(GameObject building) {
        Debug.Log("button clicked");
        this.SelectedBuilding = building;
    }
}