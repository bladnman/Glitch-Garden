using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

  [SerializeField] GameObject winLabel;
  [SerializeField] GameObject loseDialog;
  [SerializeField] AudioSource winSfx;
  [SerializeField] AudioSource loseSfx;
  [SerializeField] float delayBeforeNextLevel = 4f;

  int numberOfAttackers = 0;
  bool levelTimerFinished = false;
  bool hasLost = false;

  private void Start() {
    winLabel.SetActive(false);
    // loseDialog.SetActive(false);
  }


  public void AttackerSpawned() {
    numberOfAttackers++;
  }
  public void AttackerKilled() {
    numberOfAttackers--;
    if (numberOfAttackers <= 0 && levelTimerFinished) {
      HandleWinCondition();
    }
  }
  public void LevelTimerFinished() {
    levelTimerFinished = true;
    StopSpawners();
  }
  public void AllLivesLost() {
    if (hasLost) return;
    hasLost = true;
    StopSpawners();
    DestroyAllDefenders();
    RushAllAttackers();
    HandleLoseCondition();
  }
  void StopSpawners() {
    foreach (var item in FindObjectsOfType<AttackerSpawner>()) {
      item.StopSpawning();
    }
  }
  void RushAllAttackers() {
    // triple speed of all attackers
    foreach (var item in FindObjectsOfType<Attacker>()) {
      item.SetSpeedMultiplier(6);
    }
  }
  void DestroyAllDefenders() {
    var def = FindObjectsOfType<Defender>();
    foreach (var item in FindObjectsOfType<Defender>()) {
      Destroy(item.gameObject);
    }
  }
  void HandleWinCondition() {
    winLabel.SetActive(true);

    if (winSfx) {
      winSfx.Play();
    }

    LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
    levelLoader.LoadNextLevel(delayBeforeNextLevel);
  }
  void HandleLoseCondition() {
    loseDialog.SetActive(true);

    if (loseSfx) {
      loseSfx.Play();
    }
  }
}
