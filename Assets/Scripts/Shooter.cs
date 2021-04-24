using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

  [SerializeField] GameObject projectile, gun;

  public void Fire() {
    var launchPosition = gun.transform.position;
    Instantiate(projectile, launchPosition, Quaternion.identity);
  }

}
