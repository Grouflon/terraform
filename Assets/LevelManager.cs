using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public CarMvt car;
    public AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        car = FindObjectOfType<CarMvt>();
    }
    
    void Update () {
        Loot[] loots = FindObjectsOfType<Loot>() as Loot[];
        if (loots.Length == 0)
        {
            audioManager.playWin();
            Destroy(gameObject);// TODO pas bien
        }
	}
}
