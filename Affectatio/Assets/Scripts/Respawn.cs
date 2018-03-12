using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    [SerializeField] public Transform playerPrefab;
    [SerializeField] public Transform spawnPoint;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        playerPrefab.transform.position = spawnPoint.transform.position;
    }
}
