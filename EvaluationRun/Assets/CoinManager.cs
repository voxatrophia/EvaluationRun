using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class CoinManager : Singleton<CoinManager> {
    public Text coinText;
    public Text coinTotal;

    [SerializeField]
    int coins;
    int coinsCollectedThisLevel = 0;

    public void Start() {
        //load coins from PlayerPrefs
        if (PlayerPrefs.HasKey("coins")) {
            coins = PlayerPrefs.GetInt("coins");
        }
        else {
            coins = 0;
        }
    }

    void Update() {
        coinText.text = string.Format("Coins x{0}", coinsCollectedThisLevel);
        coinTotal.text = string.Format("Total Coins x{0}", coins);
    }

    public void DoubleCoins() {
        AddCoins(coinsCollectedThisLevel * 2);
    }

    public void AddCoins(int amt) {
        coinsCollectedThisLevel += amt;
    }

    public int GetCoins() {
        return coinsCollectedThisLevel;
    }

    public void RemoveCoins(int amt) {
        coinsCollectedThisLevel -= amt;
    }

    public void SaveCoins() {
        coins += coinsCollectedThisLevel;
        PlayerPrefs.SetInt("coins", coins);
        //save coins in PlayerPrefs
    }
}
