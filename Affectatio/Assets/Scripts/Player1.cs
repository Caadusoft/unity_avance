using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    [System.Serializable]
    public class PlayerStats
    {
        public int Health = 100;
    }

    public PlayerStats playerStats = new PlayerStats();
    public int fall = -20;

    void Update()
    {
            if (transform.position.y <= fall)
            {
            DamagePlayer(999999);
            }

    }

    public void takedmg(int degat)
    {
        this.playerStats.Health = this.playerStats.Health - degat;
        Debug.Log(this.playerStats.Health);
    }

    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }
}
