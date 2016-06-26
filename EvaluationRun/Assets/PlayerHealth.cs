using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public GameObject LevelEndPanel;

    void Start() {
        if (LevelEndPanel != null) {
            LevelEndPanel.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("Enemy")) {
            if (LevelEndPanel != null) {
                LevelEndPanel.SetActive(true);
            }
            Time.timeScale = 0;
        }

        if (coll.gameObject.CompareTag("Coin")) {
            CoinManager.Instance.AddCoins(1);
            coll.gameObject.SetActive(false);
        }

    }
}
