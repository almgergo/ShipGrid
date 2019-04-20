using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    GameData gameData;
    public ShipProperties ShipProperties;

    private ShipType _shipType;
    public ShipType ShipType {
        get { return this._shipType; }
        set {
            this._shipType = value;
            if (this.gameData.ShipTypesDictionary != null) {
                this.ShipProperties = this.gameData.ShipTypesDictionary[value];
            }
        }
    }

    // Start is called before the first frame update
    void Start() {
        this.gameData = GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<ParamLoader>().GameData;
        this.ShipType = this.gameData.selectedShip;
    }

    // Update is called once per frame
    void Update() {

    }
}