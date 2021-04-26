using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour {
  private void OnTriggerEnter2D(Collider2D other) {
    var attacker = GetComponent<Attacker>();
    if (attacker.GetIsRushingHome()) {
      attacker.StopAttacking();
      return;
    }

    GameObject otherObject = other.gameObject;

    if (otherObject.GetComponent<Defender>() != null) {
      GetComponent<Attacker>().Attack(otherObject);
    }
  }
}
