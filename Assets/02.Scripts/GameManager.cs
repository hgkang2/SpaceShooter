using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public Transform[] points;
    public List<Transform> points = new List<Transform>();
    public GameObject monster;
    public float createTime = 3.0f;
    private bool isGameOver;
    public bool IsGameOver
    {
        get{return isGameOver;}
        set{
            isGameOver = value;
            if (isGameOver)
            {
                CancelInvoke("Create<onster");
            }
        }
    }
    void Start()
    {
        //GameObject spawnPointGroupObject = GameObject.Find("SpawnPointGroup");
        //if (spawnPointGroupObject != null)
        //{
        //    Transform spawnPointGroup = spawnPointGroupObject.GetComponent<Transform>();
        //    points = spawnPointGroup.GetComponentsInChildren<Transform>();
        //}
        Transform spawnPointGroup = GameObject.Find("SpawnPointGroup")?.transform;

        //points = spawnPointGroup?.GetComponentsInChildren<Transform>();
        //spawnPointGroup?.GetComponentsInChildren<Transform>(points);
        foreach (Transform point in spawnPointGroup)
        {
            points.Add(point);
        }
        InvokeRepeating("CreateMonster",2.0f,createTime);
    }
}