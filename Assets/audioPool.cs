using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPool : MonoBehaviour {

    public AudioClip[] pool;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void play()
    {
        if (pool.Length>0) { 
            GetComponent<AudioSource>().clip = pool[Mathf.FloorToInt(Random.value * pool.Length)];
            GetComponent<AudioSource>().Play();
        }
    }

}
