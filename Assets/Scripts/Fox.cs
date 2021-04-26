using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {
  private void OnTriggerEnter2D(Collider2D other) {
    var attacker = GetComponent<Attacker>();
    if (attacker.GetIsRushingHome()) {
      attacker.StopAttacking();
      return;
    }

    GameObject otherObject = other.gameObject;

    // found a defneder... now what?
    if (otherObject.GetComponent<Defender>() != null) {
      if (otherObject.GetComponent<Gravestone>()) {
        GetComponent<Animator>().SetTrigger("jumpTrigger");
      } else {
        GetComponent<Attacker>().Attack(otherObject);
      }
    }
  }
}
