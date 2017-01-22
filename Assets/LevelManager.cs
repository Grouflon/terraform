using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [HideInInspector]
    public CarMvt car;
    [HideInInspector]
    public AudioManager audioManager;

    public GameObject prop;
    public int propCount = 30;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        car = FindObjectOfType<CarMvt>();
        for (int i = 0; i < 30; i++) Instantiate(prop);
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
