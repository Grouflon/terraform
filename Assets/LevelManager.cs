using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [HideInInspector]
    public CarMvt car;
    [HideInInspector]
    public AudioManager audioManager;

    public GameObject prop;
    bool winDone = false;
    public int propCount = 30;
    public float poppingSpeed = 5;
    float elapsedForPopping = 0;
    int nextToPop = 0;

    public GameObject loot;
    public GameObject enemy;

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
            if (!winDone)
            {
                audioManager.playWin();
                winDone = true;
            }
        }
        else
        {
            winDone = false;
        }
        elapsedForPopping += Time.deltaTime;
        while (elapsedForPopping > poppingSpeed)
        {
            GameObject toAdd = null;
            if (nextToPop == 0) toAdd = loot;
            if (nextToPop == 1) toAdd = enemy;
            Instantiate(toAdd);
            float screenStartX = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x;
            float screenEndX = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, 0.0f)).x;
            float screenStartY = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).y;
            float screenEndY = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 1.0f, 0.0f)).y;
            toAdd.transform.position = new Vector2(Random.value * (screenEndX-screenStartX) + screenStartX, Random.value * (screenEndY - screenStartY) + screenStartY);
            elapsedForPopping -= poppingSpeed;
            nextToPop = (nextToPop+1)% 2;
        }
    }
}
