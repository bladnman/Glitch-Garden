using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

  float speedMultiplier = 1f;
  float currentSpeed = 1f;
  bool isRushingHome = false;
  GameObject currentTarget;


  private void Awake() {
    FindObjectOfType<LevelController>().AttackerSpawned();
  }
  private void OnDestroy() {
    FindObjectOfType<LevelController>().AttackerKilled();
  }

  public void SetSpeedMultiplier(float multiplier) {
    speedMultiplier = multiplier;
  }
  public void SetIsRushingHome(bool isRushingHome) {
    this.isRushingHome = isRushingHome;
  }
  public bool GetIsRushingHome() {
    return isRushingHome;
  }
  public void SetMovementSpeed(float speed) {
    currentSpeed = speedMultiplier * speed;
  }
  void Update() {
    transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);

    if (!currentTarget) {
      StopAttacking();
    }
  }
  public void Attack(GameObject target) {
    StartAttacking();
    currentTarget = target;
  }
  public void StrikeCurrentTarget(int damage) {
    if (!currentTarget) return;

    Health health = currentTarget.GetComponent<Health>();
    health.Damage(damage);
  }
  public void StopAttacking() {
    GetComponent<Animator>().SetBool("isAttacking", false);
  }
  public void StartAttacking() {
    GetComponent<Animator>().SetBool("isAttacking", true);
  }

}
