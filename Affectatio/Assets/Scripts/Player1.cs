using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    public float camShakeAmt = 0.1f;
    CameraShake camShake;

    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 100;
        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }

        }

        public void Init()
        {
            curHealth = maxHealth;
        }
    }

    public PlayerStats stats = new PlayerStats();
    public int fall = -20;

    [SerializeField]
    private StatusIndicator statusIndicator;

     void Start()
    {

        camShake = GameMaster.gm.GetComponent<CameraShake>();
        if (camShake == null)
        {
            Debug.Log("Le script cameraShake n'a pas été trouvé");
        }

        stats.Init();
        
        if (statusIndicator == null)
        {
            Debug.Log("Pas d'indicateur de santé sur le héros");
        }
        else
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
    }

    void Update()
    {
            if (transform.position.y <= fall)
            {
            DamagePlayer(999999);
            }

        if (stats.curHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }

    }

    public void takedmg(int degat)
    {
        this.stats.curHealth = this.stats.curHealth - degat;
        Debug.Log(this.stats.curHealth);
        statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        camShake.Shake(camShakeAmt, 0.2f);
    }

    public void DamagePlayer(int damage)
    {
        stats.curHealth -= damage;
        if (stats.curHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }
        statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
    }
}
