﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(LineRenderer))]
[ExecuteInEditMode]
public class TerrainRenderer : MonoBehaviour {

    public enum RenderingMode
    {
        wireframe,
        solid
    }

    public float stepSize = 5.0f;
    public float amplifier = 10.0f;
    public float heightConstant = 10.0f;

    public Material terraformMaterial;
    public Material runningMaterial;

    // Use this for initialization
    void Start()
    {
        m_statesManager = FindObjectOfType<StatesManager>();
        m_oscillator = FindObjectOfType<Oscillator>();
        m_meshFilter = GetComponent<MeshFilter>();
        m_meshRenderer = GetComponent<MeshRenderer>();
        m_collider = GetComponent<EdgeCollider2D>();
        m_lineRenderer = GetComponent<LineRenderer>();

        m_mesh = new Mesh();
        m_meshFilter.mesh = m_mesh;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_oscillator == null)
            return;

        int terrainLength = m_oscillator.surfaceHeights.Length;

        m_vertices = new Vector3[terrainLength * 2];
        m_indices = new int[terrainLength * 6];

        Vector2[] colliderPoints = new Vector2[terrainLength];
        Vector3[] linePoints = new Vector3[terrainLength];

        for (int i = 0; i < terrainLength ; ++i)
        {
            float xPosition = (terrainLength * -0.5f * stepSize) + i * stepSize;
            float value = m_oscillator.surfaceHeights[i] * amplifier;

            colliderPoints[i] = new Vector2(xPosition, value);

            m_vertices[i * 2 + 0] = new Vector3(xPosition, value, 0.1f);
            m_vertices[i * 2 + 1] = new Vector3(xPosition, -heightConstant, 0.1f);

            linePoints[i] = new Vector3(xPosition, value, 0.0f);

            if (i < terrainLength - 1)
            {
                m_indices[i * 6 + 0] = i * 2 + 0;
                m_indices[i * 6 + 1] = i * 2 + 2;
                m_indices[i * 6 + 2] = i * 2 + 1;
                m_indices[i * 6 + 3] = i * 2 + 2;
                m_indices[i * 6 + 4] = i * 2 + 3;
                m_indices[i * 6 + 5] = i * 2 + 1;
            }
        }

        m_mesh.vertices = m_vertices;
        m_mesh.SetIndices(m_indices, MeshTopology.Triangles, 0);

        m_collider.points = colliderPoints;

        m_lineRenderer.numPositions = terrainLength;
        m_lineRenderer.SetPositions(linePoints);

        m_lineRenderer.startWidth = 0.3f + 0.08f * Mathf.Sin(Time.time * 4.0f);
        m_lineRenderer.startWidth = 0.3f + 0.08f * Mathf.Cos(Time.time * 4.0f);

        if (m_statesManager.state == StatesManager.GameStates.terraform)
        {
            m_lineRenderer.enabled = true;
            //m_meshRenderer.enabled = false;
            m_meshRenderer.material = terraformMaterial;
        }
        else
        {
            m_lineRenderer.enabled = false;
            //m_meshRenderer.enabled = true;
            m_meshRenderer.material = runningMaterial;
        }
    }

    Vector3[] m_vertices;
    int[] m_indices;
    Mesh m_mesh;
    MeshFilter m_meshFilter;
    MeshRenderer m_meshRenderer;
    EdgeCollider2D m_collider;
    LineRenderer m_lineRenderer;

    Oscillator m_oscillator;
    StatesManager m_statesManager;
}
