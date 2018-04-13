using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int dmg = 10;

    [System.Serializable]
    public class EnemyStats
    {
        public int Health = 100;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "heros")
        {
            col.GetComponent<Player1>().DamagePlayer(10);
        }
    }

    public EnemyStats stats = new EnemyStats();

    public void DamageEnemy(int damage)
    {
        stats.Health -= damage;
        if (stats.Health <= 0)
        {
            GameMaster.KillEnemy(this);
        }
    }
}
