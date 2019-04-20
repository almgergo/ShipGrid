using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableNode : MonoBehaviour {
    public int i;
    public int j;

    public bool hit = false;

    private List<GameObject> neighbours;
    private UIController uIController;
    private ShipTurrets shipTurrets;
    private EconomyController economyController;

    public List<GameObject> GetNeighbours() {
        return this.neighbours;
    }

    internal void Init(int i, int j) {
        this.neighbours = new List<GameObject>();
        this.i = i;
        this.j = j;
        this.uIController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
        this.shipTurrets = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipTurrets>();
        this.economyController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EconomyController>();
    }

    public void ChangeColor() {
        if (this.hit) {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        } else {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        this.hit = !this.hit;
    }

    public void BuildBuilding() {
        if (economyController.PurchaseBuilding(this.uIController.SelectedBuilding)) {
            GameObject newTurret = Instantiate(this.uIController.SelectedBuilding, this.transform);
            newTurret.transform.SetParent(this.transform);
            newTurret.name = "Turret_" + gameObject.name;
            this.shipTurrets.AddTurret(newTurret.GetComponent<TurretController>());
        }
    }
}