using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour {

  [SerializeField] int baseLives = 15;
  int lives;
  TMP_Text label;

  public int GetLives() {
    return lives;
  }

  void Start() {
    var difficulty = (int)PlayerPrefsController.GetDifficulty();
    lives = Mathf.CeilToInt(GetHalf(baseLives, difficulty));
    label = GetComponent<TMP_Text>();
    UpdateDisplay();
  }
  void UpdateDisplay() {
    label.text = $"{lives}";
  }
  public int StarTotal() {
    return lives;
  }
  public bool HasEnoughLives(int amount) {
    return lives >= amount;
  }
  public void AddLives(int amount) {
    lives += amount;
    UpdateDisplay();
  }
  public void RemoveLives(int amount) {
    if (lives < amount) return;

    lives -= amount;
    UpdateDisplay();
  }
  float GetHalf(float value, int times) {
    for (int i = 0; i < times; i++) {
      value = value / 2;
    }
    return value;
  }
}
