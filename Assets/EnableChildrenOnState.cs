using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableChildrenOnState : MonoBehaviour {

    public bool enableOnTerraform = false;

	// Use this for initialization
	void Start () {
        m_statesManager = FindObjectOfType<StatesManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_statesManager.state == StatesManager.GameStates.terraform)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(enableOnTerraform);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(!enableOnTerraform);
            }
        }
	}

    StatesManager m_statesManager;
}
