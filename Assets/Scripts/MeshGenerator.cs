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
        var triangles = new int[(size) * (size) * 6];

        var mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++) {
                //hight of sin wave
                float y = Mathf.Sin((float)i / size * 2 * Mathf.PI) + Mathf.Sin((float)j / size * 2 * Mathf.PI);
                vertices[i * size + j] = new Vector3(i, y, j);
            }


        }

        
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                    
                    int squareIndex = y * size + x;
                    int triOffset = squareIndex * 6;
                    triangles[triOffset + 0] = squareIndex + 0;
                    triangles[triOffset + 1] = squareIndex + size + 1;
                    triangles[triOffset + 2] = squareIndex + 1;
                    triangles[triOffset + 3] = squareIndex + 1;
                    triangles[triOffset + 4] = squareIndex + size + 1;
                    triangles[triOffset + 5] = squareIndex + size + 2;
    
            }
            
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();
        

    }

   

  
}
