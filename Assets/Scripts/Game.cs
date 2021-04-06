using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject[] spawn;
    public GameObject enemy;
    public GameObject player;
    public PlayerController playerController;

    public float spawnTime = 1f;
    public bool isPlaying = true;

    public GameObject bridge;
    public GameObject bridgeCollider;
    public GameObject buton;
    void Start()
    {
        Transform spawns = GameObject.Find("Spawns").transform;
        spawn = new GameObject[6];
        for(int i = 0; i < spawns.childCount; i++)
        {
            spawn[i] = spawns.Find(i.ToString()).gameObject;
        }

        playerController = player.GetComponent<PlayerController>();

        bridge.SetActive(false);

        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        if(isPlaying)
        {
            int i = UnityEngine.Random.Range(0, 6);
            Instantiate(enemy, spawn[i].transform.position, spawn[i].transform.rotation);
        }
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(Spawner());
    }
}
