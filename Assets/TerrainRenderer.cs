using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]
public class TerrainRenderer : MonoBehaviour {

    public Oscillator oscillator;
    public float stepSize = 5.0f;
    public float amplifier = 10.0f;
    public float heightConstant = 10.0f;

    float[] sample;

    // Use this for initialization
    void Start()
    {
        m_meshFilter = GetComponent<MeshFilter>();
        m_collider = GetComponent<EdgeCollider2D>();

        m_mesh = new Mesh();
        /*sample = new float[100];

        for (int i = 0; i < 100; i++)
        {
            sample[i] = (Mathf.Sin((float)i / 5.0f) + 2.0f) * 20.0f;
        }*/

        m_meshFilter.mesh = m_mesh;
    }

    // Update is called once per frame
    void Update()
    {
        if (oscillator == null)
            return;

        int terrainLength = oscillator.surfaceHeights.Length;

        m_vertices = new Vector3[terrainLength * 2];
        m_indices = new int[terrainLength * 6];

        Vector2[] colliderPoints = new Vector2[terrainLength];

        for (int i = 0; i < terrainLength ; ++i)
        {
            colliderPoints[i] = new Vector2(i * stepSize, oscillator.surfaceHeights[i]);

            m_vertices[i * 2 + 0] = new Vector3(i * stepSize, oscillator.surfaceHeights[i] * amplifier + heightConstant, 0.0f);
            m_vertices[i * 2 + 1] = new Vector3(i * stepSize, 0.0f, 0.0f);

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
    }

    Vector3[] m_vertices;
    int[] m_indices;
    Mesh m_mesh;
    MeshFilter m_meshFilter;
    EdgeCollider2D m_collider;
}
