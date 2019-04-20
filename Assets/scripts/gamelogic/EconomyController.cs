using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyController : MonoBehaviour {
    public Text GoldText;
    public float MaxGold;
    public float CurrentGold;

    void FixedUpdate() {
        GoldText.text = "Gold: " + CurrentGold;
    }

    public bool PurchaseBuilding(GameObject buildingObject) {
        BuildingProperties bp = buildingObject.GetComponent<BuildingProperties>();
        if (bp != null && bp.GoldCost <= CurrentGold) {
            CurrentGold -= bp.GoldCost;
            return true;
        } else {
            return false;
        }
    }

    public void AddBounty(EntityProperties ep) {
        this.CurrentGold += ep.Bounty;
    }
}