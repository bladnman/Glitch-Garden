using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
  [SerializeField] [Range(1, 500)] int healthMax = 10;
  [SerializeField] int healthCurrent;
  [SerializeField] GameObject deathVFX;

  public event EventHandler onHealthChanged;

  private void Start() {
    healthCurrent = healthMax;
  }
  public void Damage(int amount) {
    var before = healthCurrent;
    healthCurrent -= Mathf.Abs(amount);
    if (healthCurrent < 0) {
      healthCurrent = 0;
    }

    // if there was a change, notify listeners
    if (healthCurrent != before) {
      SignalChange();
    }

    if (healthCurrent < 1) {
      TrigerDeathVFX();
      Destroy(gameObject);
    }
  }
  public int GetHealth() {
    return healthCurrent;
  }
  void SignalChange() {
    if (onHealthChanged != null) onHealthChanged(this, EventArgs.Empty);
  }
  void TrigerDeathVFX() {
    if (!deathVFX) return;
    GameObject vfx = Instantiate(deathVFX, transform.position, transform.rotation);
    Destroy(vfx, 1f);
  }
}
