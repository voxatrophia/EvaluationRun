using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdManager : Singleton<AdManager> {

    public void ShowAdToMainMenu() {

        //Pauses editor to act like device
        #if UNITY_EDITOR
            StartCoroutine(WaitForAd());
        #endif

        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackMainMenu;

        if (Advertisement.IsReady()) {
            Advertisement.Show("video", options);
        }
    }

    public void ShowAdToStartGame() {

        //Pauses editor to act like device
        #if UNITY_EDITOR
            StartCoroutine(WaitForAd());
        #endif

        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackStartGame;

        if (Advertisement.IsReady()) {
            Advertisement.Show("video", options);
        }
    }

    //Show an ad
    //Zone is optional
    public void ShowAd(string zone = "", bool callback = false) {

        //Pauses editor to act like device
        #if UNITY_EDITOR
            StartCoroutine(WaitForAd());
        #endif

        if (string.Equals(zone, ""))
            zone = null;

        ShowOptions options = new ShowOptions();

        if (callback) {
            options.resultCallback = AdCallbackhandler;
        }

        if (Advertisement.IsReady(zone)) {
            Advertisement.Show(zone, options);
        }
    }

    void AdCallbackStartGame(ShowResult result) {
        SceneManager.LoadScene(1);
    }

    void AdCallbackMainMenu(ShowResult result) {
        SceneManager.LoadScene(0);
    }

    void AdCallbackhandler(ShowResult result) {
        switch (result) {
            case ShowResult.Finished:
                //Reward player with double coins
                CoinManager.Instance.DoubleCoins();
                Debug.Log("Ad Finished. Rewarding player...");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad skipped. Son, I am dissapointed in you");
                break;
            case ShowResult.Failed:
                Debug.Log("I swear this has never happened to me before");
                break;
        }
        //Save coins to playerPrefs
        CoinManager.Instance.SaveCoins();
        //Reload scene
        SceneManager.LoadScene(1);
    }

    IEnumerator WaitForAd() {
        float currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        yield return null;

        while (Advertisement.isShowing)
            yield return null;

        Time.timeScale = currentTimeScale;
    }
}