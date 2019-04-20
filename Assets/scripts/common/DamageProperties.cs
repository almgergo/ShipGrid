using UnityEngine;

[System.Serializable]
public class DamageProperties {
    public float SoftDamage;

    public DamageProperties(float softDamage) {
        this.SoftDamage = softDamage;
    }
}