using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour {

  [SerializeField] Defender defenderPrefab;

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
