using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipGridManager : MonoBehaviour {
    public GameObject Buildable;
    public GameObject ShipGrid;
    const float SIZE_X = 1.8f;
    const float SIZE_Y = 1.6f;

    private List<BuildableNode> nodes;
    private ShipController shipController;

    void Start() {
        this.shipController = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipController>();
        this.InitGrid();
    }

    private void InitGrid() {
        this.nodes = new List<BuildableNode>();

        for (int i = 0; i < this.shipController.ShipProperties.rows; i++) {
            for (int j = 0; j < this.shipController.ShipProperties.columns; j++) {
                bool isOddRow = i % 2 == 1;

                GameObject newBuildable = CreateNewBuildable(i, j, isOddRow);
                InitBuildableNode(i, j, newBuildable);

            }
        }

        this.FindNeighbours();
        // foreach (BuildableNode n in nodes) {
        //     foreach (GameObject neighbour in n.GetNeighbours()) {
        //         Vector3 direction = neighbour.transform.position - n.transform.position;

        //         Debug.DrawRay(n.gameObject.transform.position,
        //             direction,
        //             Color.blue, 40);
        //     }
        // }
    }

    private void InitBuildableNode(int i, int j, GameObject newBuildable) {
        BuildableNode bn = newBuildable.GetComponent<BuildableNode>();
        if (bn != null) {
            bn.Init(i, j);
            nodes.Add(bn);
        }
    }

    private GameObject CreateNewBuildable(int i, int j, bool isOddRow) {
        GameObject newBuildable = Instantiate(Buildable,
            new Vector3((j + (isOddRow ? 0.5f : 0)) * SIZE_X, 0.1f, i * SIZE_Y),
            Quaternion.LookRotation(Vector3.forward)
        );
        newBuildable.transform.SetParent(ShipGrid.transform);
        newBuildable.name = "Buildable_" + (i * this.shipController.ShipProperties.columns + j);
        return newBuildable;
    }

    private void FindNeighbours() {
        foreach (BuildableNode n in this.nodes) {
            // Debug.Log(n.gameObject.name + " i: " + n.i + ", j: " + n.j);
            for (int angle = 0; angle < 360; angle += 60) {
                Vector3 direction = Quaternion.AngleAxis(angle, Vector3.up) * n.gameObject.transform.right;

                this.ScanForNeighbour(n, direction);

            }
        }
    }

    private void ScanForNeighbour(BuildableNode node, Vector3 direction) {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(node.gameObject.transform.position, direction, out hit, Mathf.Infinity, LayerMask.GetMask("Buildable"))) {
            // Debug.DrawRay(node.gameObject.transform.position, direction * hit.distance, Color.white, 2);
            node.GetNeighbours().Add(hit.transform.gameObject);
        } else {
            // Debug.DrawRay(node.gameObject.transform.position, direction * 1000, Color.black, 2);
        }
    }
}