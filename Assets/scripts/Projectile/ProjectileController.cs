using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    [SerializeField]
    public DamageProperties DamageProperties;
    [SerializeField]
    public EntityProperties EntityProperties;
    private bool toDestroy = false;

    // Start is called before the first frame update
    void Start() {
        EntityProperties.Init();
    }

    // Update is called once per frame
    void Update() {
        this.EntityProperties.moveForward(transform);
    }

    void LateUpdate() {
        if (toDestroy) {
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
        return this.DamageProperties;
    }
}