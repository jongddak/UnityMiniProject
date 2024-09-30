using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] Mobs;
    [SerializeField] Transform[] SpawnPoints;

    [SerializeField] float SpawnTime;



    private void Start()
    {
        SpawnTime = 0.1f;
        StartCoroutine(spawnRoutine());
    }
    IEnumerator spawnRoutine() 
    {
        WaitForSeconds time = new WaitForSeconds(SpawnTime);
        while (true) 
        {
            yield return time;
            Spawning();
        }
    }

    private void Spawning() 
    {
       int x =  Random.Range(0, Mobs.Length);
       int y = Random.Range(0, SpawnPoints.Length);

       Instantiate(Mobs[x], SpawnPoints[y].position, SpawnPoints[y].rotation);
    }
}
