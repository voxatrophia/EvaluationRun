using UnityEngine;
using UnityEngine.Advertisements;

public class TestAd : MonoBehaviour {
    AdManager ad;

    void Start() {
        ad = GetComponent<AdManager>();
    }

    public void Advertise() {
        ad.ShowAd();
    }
 }
