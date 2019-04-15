using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class GameData
{

    public ShipType selectedShip;
    public List<ShipProperties> shipTypes;

    Dictionary<ShipType, ShipProperties> _shipTypesDictionary;
    public Dictionary<ShipType, ShipProperties> ShipTypesDictionary
    {
        get { return this._shipTypesDictionary; }
        set { this._shipTypesDictionary = value; }
    }

    public void ArrangeData()
    {
        this.ShipTypesDictionary = new Dictionary<ShipType, ShipProperties>();
        foreach (ShipProperties prop in this.shipTypes)
        {
            Debug.Log(prop.ToString);
            this.ShipTypesDictionary.Add(prop.shipType, prop);
        }
    }

}