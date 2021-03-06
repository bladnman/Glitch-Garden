using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

  [Tooltip("Level timer in seconds")]
  [SerializeField] float levelTime = 10f;

  bool triggeredLevelFinished = false;

  void Update() {
    if (triggeredLevelFinished) return;

    GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

    bool isTimerFinished = (Time.timeSinceLevelLoad >= levelTime);
    if (isTimerFinished) {
      triggeredLevelFinished = true;
      FindObjectOfType<LevelController>().LevelTimerFinished();
    }
  }
}
