using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
  [SerializeField] [Range(0f, 10f)] float loadDelay = 3f;

  int currentSceneIndex;

  void Start() {
    currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    // delay on loading scene
    if (currentSceneIndex == 0) {
      StartCoroutine(WaitForTime());
    }

  }
  IEnumerator WaitForTime() {
    yield return new WaitForSeconds(loadDelay);
    LoadNextScene();
  }
  public void LoadStartScene() {
    SceneManager.LoadScene("Start Screen");
  }
  public void LoadOptionsScene() {
    SceneManager.LoadScene("Options Screen");
  }
  public void LoadLevelScene() {
    SceneManager.LoadScene("Level 1");
  }
  public void RestartLevel() {
    SceneManager.LoadScene(currentSceneIndex);
  }
  public void LoadNextLevel(float delay = 0) {
    StartCoroutine(DoLoadNextLevel(delay));
  }
  IEnumerator DoLoadNextLevel(float delay = 0) {
    yield return new WaitForSeconds(delay);
    LoadLevelScene();
  }
  public void QuitGame() {
    Application.Quit();
  }
  public void LoadNextScene() {
    SceneManager.LoadScene(currentSceneIndex + 1);
  }
  public void LoadGameOver(float delay = 0) {
    Debug.Log($"M@ [{GetType()}] ok ok ok gotcha");   // M@: 
    StartCoroutine(DoLoadGameOver(delay));
  }
  IEnumerator DoLoadGameOver(float delay = 0) {
    Debug.Log($"M@ [{GetType()}] {delay} :  then load Lose Screen");   // M@: 
    yield return new WaitForSeconds(delay);
    SceneManager.LoadScene("Lose Screen");
  }

}
