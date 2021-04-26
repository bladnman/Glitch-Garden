using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

  [SerializeField] Slider volumeSlider;
  [SerializeField] Slider difficultySlider;
  [SerializeField] float defaultVolume = 0.8f;
  [SerializeField] float defaultDifficulty = 0.5f;


  float volume, difficulty;

  private void Start() {
    LoadLastOptions();
    UpdateSliders();
  }
  void LoadLastOptions() {

    volume = defaultVolume;
    difficulty = defaultDifficulty;

    if (PlayerPrefsController.HasSavedVolume()) {
      volume = PlayerPrefsController.GetMasterVolume();
    }

    if (PlayerPrefsController.HasSavedDifficulty()) {
      difficulty = PlayerPrefsController.GetDifficulty();
    }
  }
  public void SetDefaults() {
    volume = defaultVolume;
    difficulty = defaultDifficulty;

    UpdateSliders();
  }
  void UpdateSliders() {
    if (volumeSlider) {
      volumeSlider.value = volume;
    }
    if (difficultySlider) {
      difficultySlider.value = difficulty;
    }
  }
  public void SetVolume(float value) {
    PlayerPrefsController.SetMasterVolume(value);
    FindObjectOfType<MusicPlayer>().SetVolume(value);
  }
  public void SetDifficulty(float value) {
    PlayerPrefsController.SetDifficulty(value);
  }
}
