using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    public int size = 10;
    Mesh mesh;
    

    // Start is called before the first frame update
    void Start()
    {
        var vertices = new Vector3[(size + 1) * (size + 1)];
        var triangles = new int[size * size * 6];

        var mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++) {
                var y = Mathf.PerlinNoise(i * .3f, j * .3f) * 2f;
                vertices[i * size + j] += new Vector3(i, y, j);
            }


        }

        int vert = 0;
        int tris = 0;
        for (int i = 0; i < size - 1; i++) {
            for (int j = 0; j < size - 1; j++) {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + size + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + size + 1;
                triangles[tris + 5] = vert + size + 2;
                vert++;
                tris += 6;
            }
            vert++;
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        

        

    }

   

  
}
