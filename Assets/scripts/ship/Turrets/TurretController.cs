using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
    public GameObject Projectile;
    public GameObject Nozzle;
    [SerializeField]
    public ProjectileModifier projectileModifier;

    private GameObject target;

    public float fireCooldownInSeconds;
    private float nextFire;
    // Start is called before the first frame update
    void Start() {
        nextFire = Time.time + fireCooldownInSeconds;
        // projectileModifier = new ProjectileModifier(1, 1, 1);
    }

    // Update is called once per frame
    void Update() {
        if (target == null) {
            FindTarget();
        } else if (Time.time >= nextFire) {
            FireProjectile();
        }
    }

    public void FindTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0) {
            target = enemies[Random.Range(0, enemies.Length - 1)];
        }
    }

    public void FireProjectile() {
        Vector3 relativePos = target.transform.position - transform.position;
        GameObject newProjectile = Instantiate(
            Projectile, Nozzle.transform.position, Quaternion.LookRotation(relativePos, Vector3.up)
        );

        // add projectile modifire to the new projectile
        ProjectileController controller = newProjectile.GetComponent<ProjectileController>();
        controller.Init(this.projectileModifier);

        nextFire = Time.time + fireCooldownInSeconds * controller.GetCooldownMultiplier();

    }

}