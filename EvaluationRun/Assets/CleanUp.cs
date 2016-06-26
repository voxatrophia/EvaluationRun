using UnityEngine;

public class CleanUp : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            Debug.Log("Hit");
        }

        if (other.CompareTag("Coin")) {
            Debug.Log("Coin");
        }
    }
}
