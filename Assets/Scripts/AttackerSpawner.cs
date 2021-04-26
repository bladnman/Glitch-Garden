using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

  [Range(0f, 8f)]
  [SerializeField] float minDelay = 1f;
  [Range(0f, 8f)]
  [SerializeField] float maxDelay = 5f;
  [SerializeField] Attacker[] attackerPrefabs;


  bool spawn = true;
  int currentAttackerIndex = 0;

  IEnumerator Start() {
    while (spawn) {
      yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
      SpawnAttacker();
    }
  }
  public void StopSpawning() {
    spawn = false;
  }
  private void SpawnAttacker() {

    if (!spawn) return;

    // back to the start
    if (currentAttackerIndex >= attackerPrefabs.Length) {
      currentAttackerIndex = 0;
    }

    var attackerPrefab = attackerPrefabs[currentAttackerIndex];

    Attacker newAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity) as Attacker;
    newAttacker.transform.parent = transform;

    currentAttackerIndex++;
  }

  void Update() {

  }

}
