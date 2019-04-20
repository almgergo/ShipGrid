using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    [SerializeField]
    public DamageProperties DamageProperties;
    [SerializeField]
    public EntityProperties EntityProperties;

    private ProjectileModifier projectileModifier;
    private bool toDestroy = false;
    private float ttl;

    // Start is called before the first frame update
    void Start() {
        EntityProperties.Init();
        ttl = Time.time + 20;
    }

    public void Init(ProjectileModifier modifier) {
        this.projectileModifier = modifier;
    }

    // Update is called once per frame
    void Update() {
        this.EntityProperties.moveForward(transform, projectileModifier);
    }

    void LateUpdate() {
        if (toDestroy || ttl < Time.time) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        EnemyController EnemyController = other.GetComponent<EnemyController>();
        if (EnemyController != null) {
            this.toDestroy = true;
        }
    }

    public DamageProperties DealDamage() {
        return projectileModifier.ModifyDamage(this.DamageProperties);
    }

    public float GetCooldownMultiplier() {
        return this.projectileModifier.GetCooldownMultiplier();
    }
}