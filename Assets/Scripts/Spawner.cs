using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform Player;
    public List<Transform> SpawnPoints;
    public GameObject EnemyPrefab;
    public bool IsActive = true;
    public void Spawn() {
        if (IsActive) {
            foreach (Transform i in SpawnPoints) {
                var Enemy = Instantiate(EnemyPrefab, i.position, Quaternion.identity);
                Enemy.GetComponent<EnemyAI>().Player = Player;
            }
        }
    }
    public void SetActiveBool(bool Is) {
        IsActive = Is;
    }
}
