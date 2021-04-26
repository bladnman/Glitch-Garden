using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

  [SerializeField] int cost = 50;

  public int GetStarCost() {
    return cost;
  }

  public void AddStars(int amount) {
    var starDisplay = FindObjectOfType<StarDisplay>();
    starDisplay.AddStars(amount);
  }
}
