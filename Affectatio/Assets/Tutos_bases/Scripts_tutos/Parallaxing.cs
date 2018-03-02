using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    [SerializeField] private GameObject[] parralaxGo;
    [SerializeField] private float[] speedParralax;
    private Camera cam;
    private Vector3 previousCamPos;

    void Start ()
    {
        cam = Camera.main;
        previousCamPos = cam.transform.position;
	}
	
	void Update ()
    {
		for (int i=0; i<parralaxGo.Length; i++)
        {
            float speed = (previousCamPos.x - cam.transform.position.x) * speedParralax[i];
            Vector3 newPosition = new Vector3(parralaxGo[i].transform.position.x + speed, parralaxGo[i].transform.position.y, parralaxGo[i].transform.position.z);
            parralaxGo[i].transform.position = newPosition;
        }

        previousCamPos = cam.transform.position;
	}
}
