using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour {

    void Start() {
        PlayerPrefs.DeleteKey("coins");
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
        //AdManager.Instance.ShowAdToStartGame();
    }

    public void QuitGame() {
        AppHelper.Quit();
    }
}