using UnityEngine;

[System.Serializable]
public class EntityProperties {
    public float Bounty = 0;
    public float MaxHealth;
    private float Health;

    public float Speed;
    public float TurnRate;

    public void Init() {
        this.Health = MaxHealth;
    }

    public bool TakeDamage(DamageProperties damageProperties) {
        this.Health -= damageProperties.SoftDamage;

        return this.Health < 0;
    }

    public string getHealth() {
        return this.Health.ToString();
    }

    public void moveForward(Transform transform, ProjectileModifier projectileModifier) {
        transform.position += transform.forward * Time.deltaTime * Speed * projectileModifier.SpeedMultiplier;
    }
}