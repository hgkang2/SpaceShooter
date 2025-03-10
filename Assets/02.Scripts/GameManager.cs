using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public Transform[] points;
    public List<Transform> points = new List<Transform>();
    void Start()
    {
       // Transform spawnPointGroup = GameObject.Find("SpawnPointGroup")?.transform;
       // points = spawnPointGroup?.GetComponentsInChildren<Transform>();
       Transform spawnPointGroup = GameObject.Find("SpawnPointGroup")?.transform;
       //points = spawnPointGroup?.GetComponentsInChildren<Transform>();
       //spawnPointGroup?.GetComponentsInChildren<Transform>(points);
       foreach (Transform point in spawnPointGroup)
       {
        points.Add(point);
       }
    }
}
