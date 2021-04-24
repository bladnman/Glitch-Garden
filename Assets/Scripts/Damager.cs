using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {
  [SerializeField] [Range(1, 20)] int damage = 1;

  private void OnTriggerEnter2D(Collider2D other) {
    Debug.Log($"M@ [{GetType()}] we triggered something");   // M@: 
    var health = other.gameObject.GetComponent<Health>();
    if (!health) return;

    health.Damage(damage);

  }

}
