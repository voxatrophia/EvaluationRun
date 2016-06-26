using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectPooler))]
public class SpawnEnemies : MonoBehaviour {
    public float minEnemy = 0.5f;
    public float maxEnemy = 2f;
    ObjectPooler pool;
    void Start() {
        pool = GetComponent<ObjectPooler>();
        StartCoroutine(RandomSpawn());
    }

    void SpawnEnemy() {
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
            yield return new WaitForSeconds(Random.Range(minEnemy, maxEnemy));
            SpawnEnemy();
        }
    }
}
