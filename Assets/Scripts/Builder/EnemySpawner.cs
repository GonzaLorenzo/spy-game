using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    private GameObject parent;
    public Enemy AssaultPref;
    public Enemy TankPref;

    public Vector3 Enemy1Pos;
    public Vector3 Enemy2Pos;
    public Vector3 Enemy3Pos;
    public List<Transform> Enemy1Waypoints;
    public List<Transform> Enemy2Waypoints;
    public List<Transform> Enemy3Waypoints;

    void Start()
    {        
        parent = GameObject.Find("MainGame");

        InstantiateFirstLevel();
    }
    

    private void InstantiateFirstLevel()
    {
        Instantiate(AssaultPref, parent.transform).SetPos(Enemy1Pos).SetWaypoints(Enemy1Waypoints);

        Instantiate(TankPref, parent.transform).SetPos(Enemy2Pos).SetWaypoints(Enemy2Waypoints);

        Instantiate(AssaultPref, parent.transform).SetPos(Enemy3Pos).SetWaypoints(Enemy3Waypoints).SetRotation(new Vector3 (0,180,0));
    }

}
