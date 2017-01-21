using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {

    public GameObject car;
    public GameObject audioManager;

	void Start () {
		
	}
	
	void Update () {
        if (Vector2.Distance(car.transform.position, transform.position) < 1)
        {
            audioManager.GetComponent<AudioManager>().playLoot();
            Destroy(gameObject);
        }
    }
}
