using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {
  [SerializeField] GameObject vfx;
  [SerializeField] AudioSource sfx;
  [SerializeField] bool isHome = false;
  [SerializeField] bool isDying = false;

  private void OnTriggerEnter2D(Collider2D other) {
    GameObject otherObject = other.gameObject;

    if (otherObject.GetComponent<Attacker>() != null) {
      PlayFXAt(otherObject.gameObject.transform.position);
      if (isHome && !isDying) {
        // reduce lives
        var livesDisplay = FindObjectOfType<LivesDisplay>();
        livesDisplay.RemoveLives(1);

        if (livesDisplay.GetLives() < 1) {
          DoDeathSequence();
        }
      }
    }

    Destroy(otherObject.gameObject);
  }
  void PlayFXAt(Vector2 position) {

    if (vfx) {
      var item = Instantiate(vfx, position, Quaternion.identity);
      Destroy(item, 1.5f);
    }
    // todo: SFX too!
    if (sfx) {
      sfx.Play();
    }
  }
  void DoDeathSequence() {
    isDying = true;


    FindObjectOfType<LevelController>().AllLivesLost();

    // // disable all buttons
    // foreach (var item in FindObjectsOfType<DefenderButton>()) {
    //   item.enabled = false;
    // }

    // // triple speed of all attackers
    // foreach (var item in FindObjectsOfType<Attacker>()) {
    //   item.SetSpeedMultiplier(6);
    // }

    // LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
    // levelLoader.LoadGameOver(2.0f);
  }

}
