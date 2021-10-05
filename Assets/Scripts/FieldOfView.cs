using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private void Start()
    {
        Mesh mesh = new Mesh();

        LayerMask carlos;

        float fov = 60f;
        Vector3 origin = Vector3.zero;
        int rayCount = 50;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 5f;

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;

        for(int i = 0; i <= rayCount; i++)
        {
            

            Vector3 vertex = origin + GetVectorFromAngle(angle) * viewDistance;

            Ray enemyRay = new Ray(origin, GetVectorFromAngle(angle));
            RaycastHit hit;
            Physics.Raycast(enemyRay, out hit, viewDistance);
            
            if(hit.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = hit.point;
            }

            
            
            //if(raycastHit.)
            //{
                //vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            //}
            //else
            //{
                //vertex = raycast.point;
            //}

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;

        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;

        
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad),0, Mathf.Sin(angleRad));
    }
}
