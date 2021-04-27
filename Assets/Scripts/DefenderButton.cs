using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour {

  [SerializeField] Defender defenderPrefab;
  Text priceLabel;

  private void Start() {
    priceLabel = GetComponentInChildren<Text>();
    if (priceLabel && defenderPrefab) {
      priceLabel.text = $"{defenderPrefab.GetStarCost()}";
    }
  }
  private void OnMouseDown() {
    DisableAllButtons();
    gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
  }
  void DisableAllButtons() {
    foreach (DefenderButton button in FindObjectsOfType<DefenderButton>()) {
      button.GetComponent<SpriteRenderer>().color = new Color32(48, 48, 48, 255);
    }
  }
}
