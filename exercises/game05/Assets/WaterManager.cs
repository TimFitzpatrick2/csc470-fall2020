using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class WaterManager : MonoBehaviour
{

    public GameObject WaterPrefab;
    private MeshFilter meshFilter;


    void Start()
    {
       
    }

    void Update()
    {
        {
            Vector3[] vertices = meshFilter.mesh.vertices;
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].y = WaveManager.instance.GetWaveHeight(transform.position.x + vertices[i].x);
            }

            meshFilter.mesh.vertices = vertices;
            meshFilter.mesh.RecalculateNormals();
        }
    }

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
    }
}
