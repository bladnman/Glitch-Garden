using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

  [Range(0f, 8f)]
  [SerializeField] float minDelay = 1f;
  [Range(0f, 8f)]
  [SerializeField] float maxDelay = 5f;
  [SerializeField] Attacker attackerPrefab;

  bool spawn = true;
  IEnumerator Start() {
    while (spawn) {
      yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
      SpawnAttacker();
    }
  }

  private void SpawnAttacker() {
    Instantiate(attackerPrefab, transform.position, Quaternion.identity);
  }

  void Update() {

  }

}
