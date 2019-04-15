using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                Transform objectHit = hit.transform;
                Debug.Log(hit.transform.gameObject.name);

                BuildableNode buildable = hit.transform.gameObject.GetComponent<BuildableNode>();
                if (buildable != null) {
                    buildable.ChangeColor();
                    buildable.GetNeighbours().ForEach(n => {
                        n.GetComponent<BuildableNode>().ChangeColor();
                    });
                }
                // hit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                // Do something with the object that was hit by the raycast.
            }
        }
    }
}