using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTurrets : MonoBehaviour {
    List<TurretController> turrets;
    // Start is called before the first frame update
    void Start() {
        turrets = new List<TurretController>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void AddTurret(TurretController newTurret) {
        this.turrets.Add(newTurret);
    }
}