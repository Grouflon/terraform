using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public CarMvt car;
    public AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        car = FindObjectOfType<CarMvt>();
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
