using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

  [SerializeField] [Range(0, 25f)] float speed = 10f;
  [SerializeField] [Range(1, 20)] int damage = 1;

  void Update() {
    transform.Translate(Vector2.right * Time.deltaTime * speed);
  }

  private void OnTriggerEnter2D(Collider2D other) {
    var health = other.gameObject.GetComponent<Health>();
    var attacker = other.gameObject.GetComponent<Attacker>();

    if (attacker && health) {
      health.Damage(damage);
      Destroy(gameObject);
    }

  }
}
