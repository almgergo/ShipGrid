using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public EntityProperties EntityProperties;

    private EconomyController economyController;
    private bool toDestroy = false;
    // Start is called before the first frame update
    void Start() {
        this.EntityProperties.Init();
        this.economyController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EconomyController>();
    }

    // Update is called once per frame
    void Update() {

    }

    void LateUpdate() {
        if (toDestroy) {
            economyController.AddBounty(this.EntityProperties);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        ProjectileController projectileController = other.GetComponent<ProjectileController>();
        if (projectileController != null) {
            this.TakeDamage(projectileController.DealDamage());
        }
    }

    public void TakeDamage(DamageProperties damageProperties) {
        if (EntityProperties.TakeDamage(damageProperties)) {
            toDestroy = true;
        }
    }
}