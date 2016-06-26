using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelEndUI : MonoBehaviour {

    public void Start() {
        Time.timeScale = 1;
    }

    //public GameObject LevelEndPanel;

    //void Start() {
    //    if (LevelEndPanel != null) {
    //        LevelEndPanel.SetActive(false);
    //    }
    //}

    public void TryAgain() {
        CoinManager.Instance.SaveCoins();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WatchAd() {
        AdManager.Instance.ShowAd("rewardedVideo", true);
    }

    public void GoToMainMenu() {
        //Play intersticial ad
        AdManager.Instance.ShowAdToMainMenu();
    }
}
