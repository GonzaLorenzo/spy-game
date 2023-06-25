using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    Enemy thisEnemy;
    public Slider detectionBar;
    private float maxDetection = 100;
    private float currentDetection = 0;
    [SerializeField] private float _detectionRate = 2.4f;
    public float visionRange;
    public float visionAngle;
    public LayerMask visionObstructingLayer;
    public LayerMask enemyLayer;
    public int visionConeResolution = 120;
    [SerializeField] private Mesh _visionConeMesh;
    [SerializeField] private MeshFilter _meshFilter;

    private int playerHitCount = 0;
    //private int objectHitCount = 0;

    void Awake()
    {
        detectionBar.value = currentDetection;
        detectionBar.maxValue = maxDetection;
        thisEnemy = transform.parent.GetComponent<Enemy>();
    }

    void Start()
    {
        _visionConeMesh = new Mesh();
        visionAngle *= Mathf.Deg2Rad;
    }

    
    void Update()
    {
        DrawVisionCone();
    }

    void DrawVisionCone()
    {
	    int[] triangles = new int[(visionConeResolution - 1) * 3];
    	Vector3[] Vertices = new Vector3[visionConeResolution + 1];
        Vertices[0] = Vector3.zero;
        float currentAngle = -visionAngle / 2;
        float angleIncrement = visionAngle / (visionConeResolution - 1);
        float Sine;
        float Cosine;

        playerHitCount = 0;
        //objectHitCount = 0;

        for (int i = 0; i < visionConeResolution; i++)
        {
            
            Sine = Mathf.Sin(currentAngle);
            Cosine = Mathf.Cos(currentAngle);
            Vector3 RaycastDirection = (transform.forward * Cosine) + (transform.right * Sine);
            Vector3 VertForward = (Vector3.forward * Cosine) + (Vector3.right * Sine);

            float meshHitDistance;
            if (Physics.Raycast(transform.position, RaycastDirection, out RaycastHit hit, visionRange, visionObstructingLayer))
            {
                Vertices[i + 1] = VertForward * hit.distance;
                meshHitDistance = hit.distance;
            }
            else
            {
                Vertices[i + 1] = VertForward * visionRange;
                meshHitDistance = visionRange;
            }

            if (Physics.Raycast(transform.position, RaycastDirection, out RaycastHit playerHit, meshHitDistance, enemyLayer))
            {
                //Encontramos el player.
                playerHitCount++;
            }
            else
            {
                //Perdimos al player.
                //objectHitCount++;
            }

            currentAngle += angleIncrement;
        }

        bool IsPlayerFound = playerHitCount > 0;

        Debug.Log("player " + playerHitCount);
        Debug.Log("es " + IsPlayerFound);

        if(IsPlayerFound)
        {
            if (currentDetection < maxDetection)
                {
                    currentDetection += _detectionRate;
                    detectionBar.value = currentDetection;
                }
                else
                {
                    SendDetectPlayer();
                }
        }
        else
        {
            currentDetection = 0f;
            detectionBar.value = currentDetection;
        }


        for (int i = 0, j = 0; i < triangles.Length; i += 3, j++)
        {
            triangles[i] = 0;
            triangles[i + 1] = j + 1;
            triangles[i + 2] = j + 2;
        }
        _visionConeMesh.Clear();
        _visionConeMesh.vertices = Vertices;
        _visionConeMesh.triangles = triangles;
        _meshFilter.mesh = _visionConeMesh;
    }

    public void SendDetectPlayer()
    {
        thisEnemy.DetectPlayer();
    }

    public void EnemyIsDead()
    {
        currentDetection = 0f;
        detectionBar.value = currentDetection;
        Destroy(this.gameObject);
    }
}