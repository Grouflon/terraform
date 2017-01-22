using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [HideInInspector]
    public CarMvt car;
    [HideInInspector]
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
            Oscillator oscillo = FindObjectOfType<Oscillator>();
            oscillo.resetOsc();
            Loot[] loots = FindObjectsOfType<Loot>() as Loot[];
            for (int i = 0; i < loots.Length; i++) Destroy(loots[i].gameObject);
            Enemy[] enemies = FindObjectsOfType<Enemy>() as Enemy[];
            for (int i = 0; i < enemies.Length; i++) if (enemies[i]!=this) Destroy(enemies[i].gameObject);
            Destroy(gameObject);
        }
    }

}
