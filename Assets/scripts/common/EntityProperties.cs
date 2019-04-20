using UnityEngine;

[System.Serializable]
public class EntityProperties {
    public float MaxHealth;
    private float Health;

    public float Speed;
    public float TurnRate;

    public void Init() {
        this.Health = MaxHealth;
    }

    public bool TakeDamage(DamageProperties damageProperties) {
        Debug.Log(damageProperties.SoftDamage + ' ' + this.Health);
        this.Health -= damageProperties.SoftDamage;
        Debug.Log(this.Health);

        return this.Health < 0;
    }

    public string getHealth() {
        return this.Health.ToString();
    }

    public void moveForward(Transform transform) {
        transform.position += transform.forward * Time.deltaTime * Speed;
    }
}