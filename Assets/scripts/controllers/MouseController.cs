using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
    public float CameraScrollSpeed;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, float.PositiveInfinity, LayerMask.GetMask("Buildable"))) {
                Transform objectHit = hit.transform;

                BuildableNode buildable = hit.transform.gameObject.GetComponentInChildren<BuildableNode>();
                if (buildable != null) {
                    buildable.BuildBuilding();
                    // buildable.GetNeighbours().ForEach(n => {
                    //     n.GetComponent<BuildableNode>().ChangeColor();
                    // });
                }
                // hit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                // Do something with the object that was hit by the raycast.
            }
        }

        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * CameraScrollSpeed;
        fov = Mathf.Clamp(fov, 45, 120);
        Camera.main.fieldOfView = fov;
    }
}