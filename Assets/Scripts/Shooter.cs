using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

  [SerializeField] GameObject projectile, gun;

  AttackerSpawner laneSpawner;
  Animator animator;
  GameObject projectileParent;
  const string PROJECTILE_PARENT_NAME = "Projectiles";

  private void Start() {
    animator = GetComponent<Animator>();
    laneSpawner = GetLaneSpawner();
    CreateProjectileParent();
  }
  private void Update() {
    if (IsAttackerInLane()) {
      // shoot animation
      animator.SetBool("isAttacking", true);
    } else {
      // idle animation
      animator.SetBool("isAttacking", false);
    }
  }
  private void CreateProjectileParent() {
    projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
    if (!projectileParent) {
      projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
    }
  }
  private AttackerSpawner GetLaneSpawner() {
    var spawners = FindObjectsOfType<AttackerSpawner>();
    foreach (var spawner in spawners) {
      var isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) < 1;
      // found it!
      if (isCloseEnough) {
        return spawner;
      }
    }
    return null;
  }
  private bool IsAttackerInLane() {
    return laneSpawner.transform.childCount > 0;
  }

  public void Fire() {
    Vector2 launchPosition = gun != null ? gun.transform.position : transform.position;
    var item = Instantiate(projectile, launchPosition, Quaternion.identity);
    item.transform.parent = projectileParent.transform;
  }

}
