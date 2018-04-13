using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;

    void start()
    {
        if (gm == null)
        {
            //création d'une variable pour le collider vide
            gm = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<GameMaster>();
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;

    public void RespawnPlayer()
    {
        //Permet de placer à nouver le héros
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public static void KillPlayer(Player1 player)
    {
        Destroy(player.gameObject);
        //on instancie là où se trouve le collider vide
        gm.RespawnPlayer();
    }

    public static void KillEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
        
    }
}
