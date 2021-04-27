using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

  Defender defender;
  GameObject defenderParent;
  const string DEFENDER_PARENT_NAME = "Defenders";

  private void Start() {
    CreateDefenderParent();
  }

  private void CreateDefenderParent() {
    defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
    if (!defenderParent) {
      defenderParent = new GameObject(DEFENDER_PARENT_NAME);
    }
  }

  private void OnMouseDown() {

    if (!defender) return;

    AttemptToPlaceDefenderAt(GetSquareClicked());
  }
  public void SetSelectedDefender(Defender defenderToSelect) {
    defender = defenderToSelect;
  }

  void AttemptToPlaceDefenderAt(Vector2 gridPos) {
    var starDisplay = FindObjectOfType<StarDisplay>();
    int defenderCost = defender.GetStarCost();

    if (starDisplay.HasEnoughStars(defenderCost)) {
      SpawnDefender(gridPos);
      starDisplay.RemoveStars(defenderCost);
    }

  }

  Vector2 GetSquareClicked() {
    var clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    var worldPos = Camera.main.ScreenToWorldPoint(clickPos);

    return SnappedGridpoint(worldPos);
  }
  Vector2 SnappedGridpoint(Vector2 worldPos) {
    return new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));
  }
  void SpawnDefender(Vector2 worldPos) {
    Defender newDefender = Instantiate(defender,
        worldPos,
        Quaternion.identity) as Defender;
    newDefender.transform.parent = defenderParent.transform;
  }
}
