using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class FieldOfView : MonoBehaviour
    {
        private Mesh mesh;
        public float vision_angle = 30f;
        public float vision_range = 5f;
        public LayerMask obstacle_mask = ~(0);
        public int precision = 60;
        private float timer = 0f;
        private float refresh_rate = 0f;

        private void Start()
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
            InitMesh();
        }

        private void InitMesh()//MeshFilter. mesh)
        {
            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();
            //List<Vector3> normals = new List<Vector3>();
            List<Vector2> uv = new List<Vector2>();

            //int minmax = Mathf.RoundToInt(vision_angle / 2f);

            int tri_index = 0;
            //float step_jump = Mathf.Clamp(vision_angle / precision, 0.01f, minmax);

            for (float i = 0; i <= precision; i ++)
            {
                float angle = (float)(i + 180f) * Mathf.Deg2Rad;
                Vector3 dir = new Vector3(Mathf.Cos(angle) * vision_range, 0f, Mathf.Sin(angle) * vision_range);

                vertices.Add(dir);
                //normals.Add(Vector2.up);
                uv.Add(Vector2.zero);

                if (tri_index > 0)
                {
                    triangles.Add(0);
                    triangles.Add(tri_index + 1);
                    triangles.Add(tri_index);
                }
            }

            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
            //mesh.normals = normals.ToArray();
            mesh.uv = uv.ToArray();

        }

    //timer += Time.deltaTime;

    //transform.position = target.eye.transform.position;
    //transform.rotation = target.transform.rotation;

    //if (timer > refresh_rate)
    //{
    //    timer = 0f;

    //    float range = vision_range;
    //
    //    UpdateMainLevel(mesh, range);
    //}
    //}

        private void Update()
        {
            //private void UpdateMainLevel(MeshFilter mesh, float range)
            //{
            List<Vector3> vertices = new List<Vector3>();
            vertices.Add(new Vector3(0f, 0f, 0f));

            int minmax = Mathf.RoundToInt(vision_angle / 2f);
            float step_jump = Mathf.Clamp(vision_angle / precision, 0.01f, minmax);
            for (float i = -minmax; i <= minmax; i += step_jump)
            {
            float angle = (float)(i + 90f) * Mathf.Deg2Rad;
            Vector3 dir = new Vector3(Mathf.Cos(angle) * vision_range, 0f, Mathf.Sin(angle) * vision_range);

            RaycastHit hit;
            Vector3 pos_world = transform.TransformPoint(Vector3.zero);
            Vector3 dir_world = transform.TransformDirection(dir.normalized);
            bool ishit = Physics.Raycast(new Ray(pos_world, dir_world), out hit, vision_range, obstacle_mask.value);
            if (ishit)
                dir = dir.normalized * hit.distance;
            Debug.DrawRay(pos_world, dir_world * (ishit ? hit.distance : vision_range));

            vertices.Add(dir);
            }

            mesh.vertices = vertices.ToArray();
            mesh.RecalculateBounds();
            //}
        }

    }

