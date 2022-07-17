using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    public Animator transition;

    private CanvasGroupScript canvasGroup;

    [SerializeField] private float transitionTime = 1f;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        canvasGroup = CanvasGroupScript.instance;
    }

    public void LoadMainMenu() {
        StartCoroutine(LoadLevel(0));
    }

    public void LoadGameScene() {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadScene(int sceneToLoad) {
        StartCoroutine(LoadLevel(sceneToLoad));
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

        switch(levelIndex) {
            case 0:
                canvasGroup.LoadMainMenu();
                break;
            case 1:
                canvasGroup.LoadGameScene();
                break;
        }
        transition.SetTrigger("End");
    }

    public void Quit() {
        Application.Quit();
    }
}
