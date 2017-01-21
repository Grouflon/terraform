using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject car;
    public GameObject audioManager;

    void Start()
    {

    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Car"))
        {
            audioManager.GetComponent<AudioManager>().playDie();
            Destroy(gameObject);
        }
    }

}
