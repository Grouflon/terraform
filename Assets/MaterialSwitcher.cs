using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour {

    public Material runningMaterial;
    public Material terraformingMaterial;

	// Use this for initialization
	void Start () {
        m_statesManager = FindObjectOfType<StatesManager>();
	}
	
	// Update is called once per frame
	void Update () {

        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

        if (m_statesManager.state == StatesManager.GameStates.terraform)
        {
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.material = terraformingMaterial;
            }
        }
        else
        {
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.material = runningMaterial;
            }
        }
	}

    StatesManager m_statesManager;
}
