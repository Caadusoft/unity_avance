using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;

public class gameManager : MonoBehaviour {

	private static gameManager instance ;
    public static gameManager Instance { get { return instance; } }
    private Transform playerInstanciate;
    [SerializeField]
    private Transform PlayerPrefab;
    [SerializeField]
    private Transform SpawnPoint;
    private UnitySampleAssets._2D.Camera2DFollow cam;
    private player PlayerScript;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        cam = Camera.main.GetComponent<Camera2DFollow>();
    }
    void Start ()
    {
        InstanciatePlayer();
	}

    private void InstanciatePlayer()
    {
        playerInstanciate = Instantiate(PlayerPrefab, SpawnPoint.position, Quaternion.identity) as Transform;
        cam.target = playerInstanciate;

        PlayerScript = playerInstanciate.GetComponent<player>();
        PlayerScript.MonEvent += PlayerScript_MonEvent;
    }

    private void PlayerScript_MonEvent()
    {
        Destroy(playerInstanciate.gameObject);
        StartCoroutine(RespawnPlayer());
        //permet de démarrer la méthode RespawPlayer
    }

    private IEnumerator RespawnPlayer()
    {
        Debug.Log("3");
        yield return new WaitForSeconds(3);

        Debug.Log("2");
        yield return new WaitForSeconds(2);

        Debug.Log("1");
        yield return new WaitForSeconds(1);

        InstanciatePlayer();
        //on dit à la caméra quel est mon nouveau joueur
    }

    void Update ()
    {
		
	}
}
