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
  void LoadNextScene() {
    SceneManager.LoadScene(currentSceneIndex + 1);
  }

}
