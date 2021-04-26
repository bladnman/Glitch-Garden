using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarDisplay : MonoBehaviour {

  [SerializeField] int stars = 100;
  TMP_Text starText;

  void Start() {
    starText = GetComponent<TMP_Text>();
    UpdateDisplay();
  }
  void UpdateDisplay() {
    starText.text = $"{stars}";
  }
  public int StarTotal() {
    return stars;
  }
  public bool HasEnoughStars(int amount) {
    return stars >= amount;
  }
  public void AddStars(int amount) {
    stars += amount;
    UpdateDisplay();
  }
  public void RemoveStars(int amount) {
    if (stars < amount) return;

    stars -= amount;
    UpdateDisplay();
  }
}
