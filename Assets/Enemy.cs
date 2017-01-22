using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [HideInInspector]
    public CarMvt car;
    [HideInInspector]
    public AudioManager audioManager;

    float swingFr = 0;
    float swingAm = 0;
    float lifeTime = 0;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        car = FindObjectOfType<CarMvt>();

        swingFr = Random.value * 2.0f + 2.0f;
        swingAm = Random.value * 30.0f;
        m_baseScale = transform.localScale;
        transform.localScale = new Vector3(1, 1, 1) * 0.00000001f;
    }

    void Update()
    {
        lifeTime += Time.deltaTime;

        float t = Mathf.Sin(Time.time * swingFr);
        transform.rotation = Quaternion.Euler(0, 0, t * swingAm);
        transform.localScale = m_baseScale * Ease.BackOut(Mathf.Clamp01(lifeTime / 0.5f)) + new Vector3(1.0f, 1.0f, 1.0f) * t * 0.1f;
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

            FindObjectOfType<LevelManager>().score = 0;
        }
    }

    Vector3 m_baseScale;
}
