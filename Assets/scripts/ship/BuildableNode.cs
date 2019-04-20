using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableNode : MonoBehaviour {
    public int i;
    public int j;

    public bool hit = false;

    private List<GameObject> neighbours;
    private UIController UIController;
    private ShipTurrets ShipTurrets;

    public List<GameObject> GetNeighbours() {
        return this.neighbours;
    }

    internal void Init(int i, int j) {
        this.neighbours = new List<GameObject>();
        this.i = i;
        this.j = j;
        this.UIController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
        this.ShipTurrets = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipTurrets>();
    }

    public void ChangeColor() {
        if (this.hit) {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        } else {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        this.hit = !this.hit;
    }

    public GameObject BuildBuilding() {
        GameObject newTurret = Instantiate(this.UIController.SelectedBuilding, this.transform);
        newTurret.transform.SetParent(this.transform);
        newTurret.name = "Turret_" + gameObject.name;
        this.ShipTurrets.AddTurret(newTurret.GetComponent<TurretController>());
        return newTurret;
    }
}