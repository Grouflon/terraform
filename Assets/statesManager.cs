using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour
{
    public InputController input;
    public OscillatorController oscController;

    public GameStates state = GameStates.running;

	void Start () {
        m_terrainRenderer = FindObjectOfType<TerrainRenderer>();
	}
	
	void Update () {
        if (input.GetAnyShapeMode())
        {
            state = GameStates.terraform;
        }
        else
        {
            state = GameStates.running;
        }


        if (state == GameStates.terraform)
        {
            // Time.timeScale = 0;
            //oscController.enabled = true;

            Camera.main.backgroundColor = Color.black;
            Camera.main.GetComponent<PostRenderer>().enabled = true;
        }
        else
        {
            // Time.timeScale = 1;
            //oscController.enabled = false;

            Camera.main.backgroundColor = new Color(146.0f / 255.0f, 174.0f / 255.0f, 1.0f);
            Camera.main.GetComponent<PostRenderer>().enabled = false;
        }
    }

    public enum GameStates
    {
        running,
        terraform
    }

    private TerrainRenderer m_terrainRenderer;
}
