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
        /*if (input.ToggleGameState())
        {
            if (state == GameStates.terraform) state = GameStates.running;
            else state = GameStates.terraform;
        }*/

        state = input.currentGameState();

        if (state == GameStates.terraform)
        {
            // Time.timeScale = 0;
            oscController.enabled = true;

            Camera.main.backgroundColor = Color.black;
        }
        else
        {
            // Time.timeScale = 1;
            oscController.enabled = false;

            Camera.main.backgroundColor = new Color(146.0f / 255.0f, 174.0f / 255.0f, 1.0f);
        }
    }

    public enum GameStates
    {
        running,
        terraform
    }

    private TerrainRenderer m_terrainRenderer;
}
