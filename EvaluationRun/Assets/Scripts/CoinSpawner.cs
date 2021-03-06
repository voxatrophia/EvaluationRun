﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectPooler))]
public class CoinSpawner : MonoBehaviour {
    public float minSpawn = 2f;
    public float maxSpawn = 5f;
    ObjectPooler pool;
    void Start() {
        pool = GetComponent<ObjectPooler>();
        StartCoroutine(RandomSpawn());
    }

    void SpawnCoin() {
        GameObject obj = pool.GetPooledObject();
        if (obj == null) return;

        Vector3 pos = obj.transform.position;
        pos.x = transform.position.x;
        obj.transform.position = pos;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }

    IEnumerator RandomSpawn() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minSpawn, maxSpawn));
            SpawnCoin();
        }
    }
}