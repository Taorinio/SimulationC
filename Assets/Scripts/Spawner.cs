using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform Player;
    public List<Transform> SpawnPoints;
    public GameObject EnemyPrefab;
    public bool IsActive = true;
    public void Spawn(int Times) {
        if (IsActive) {
            for (int k = 0; k < Times; k++) {
                foreach (Transform i in SpawnPoints) {
                    var Enemy = Instantiate(EnemyPrefab, i.position, Quaternion.identity);
                    if (Enemy.tag == "enemy") {
                        Enemy.GetComponent<EnemyAI>().Player = Player;
                    }
                    else {
                        Enemy.GetComponent<BossAI>().Player = Player;
                    }
                }
            }
        }
    }
    public void SetActiveBool(bool Is) {
        IsActive = Is;
    }
}
