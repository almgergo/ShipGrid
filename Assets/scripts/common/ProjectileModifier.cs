using UnityEngine;

[System.Serializable]
public class ProjectileModifier {
    public float DamageMultiplier = 1;
    public float SpeedMultiplier = 1;
    public float CooldownMultiplier = 1;

    public ProjectileModifier(float dm, float sm, float cm) {
        this.DamageMultiplier = dm;
        this.SpeedMultiplier = sm;
        this.CooldownMultiplier = cm;
    }

    public float GetDamageMultiplier() {
        return this.DamageMultiplier;
    }

    public float GetSpeedMultiplier() {
        return this.SpeedMultiplier;
    }

    public float GetCooldownMultiplier() {
        return this.CooldownMultiplier;
    }

    public DamageProperties ModifyDamage(DamageProperties dp) {
        return new DamageProperties(dp.SoftDamage * this.DamageMultiplier);
    }
}