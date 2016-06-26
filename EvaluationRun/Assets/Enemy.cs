using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    void OnEnable() {
        //Invoke("Destroy", 6f);
    }

    void Destroy() {
        gameObject.SetActive(false);
    }
}
