using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour {
  const string MASTER_VOLUME_KEY = "master_volume";
  const float DEFAULT_VOLUME = 0.5f;
  const float MIN_VOLUME = 0f;
  const float MAX_VOLUME = 1f;

  const string DIFFICULTY_KEY = "difficulty";
  const float DEFAULT_DIFFICULTY = 1;
  const float MIN_DIFFICULTY = 0;
  const float MAX_DIFFICULTY = 2;

  public static void SetMasterVolume(float value) {
    PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, Mathf.Clamp(value, MIN_VOLUME, MAX_VOLUME));
  }
  public static float GetMasterVolume() {
    return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
  }
  public static bool HasSavedVolume() {
    return PlayerPrefs.HasKey(MASTER_VOLUME_KEY);
  }

  public static void SetDifficulty(float value) {
    PlayerPrefs.SetFloat(DIFFICULTY_KEY, Mathf.Clamp(value, MIN_DIFFICULTY, MAX_DIFFICULTY));
  }
  public static float GetDifficulty() {
    return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
  }
  public static bool HasSavedDifficulty() {
    return PlayerPrefs.HasKey(DIFFICULTY_KEY);
  }

}
