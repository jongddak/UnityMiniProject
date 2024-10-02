using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] Mobs;
    [SerializeField] Transform[] SpawnPoints;

    [SerializeField] float SpawnTime;

   
    private float curSpawnTime;
    private Coroutine sproutine;
    
    private void Start()
    {
       SpawnTime = 0.5f;
       StartCoroutine(spawnRoutine());
       curSpawnTime = SpawnTime;
       
    }
    IEnumerator spawnRoutine() 
    {
      // WaitForSeconds time = new WaitForSeconds(SpawnTime);
        while (true) 
        {
            yield return new WaitForSeconds(SpawnTime);
           // WaitForSeconds time = new WaitForSeconds(SpawnTime);
            Spawning();
        }
    }
    private void Update()
    {
      SpawnTime = Mathf.Clamp(0.5f - (0.001f * PlayerStat.killCount), 0.01f, 0.5f);

    }

    private void Spawning() 
    {
       int x =  Random.Range(0, Mobs.Length);
       int y = Random.Range(0, SpawnPoints.Length);

       Instantiate(Mobs[x], SpawnPoints[y].position, SpawnPoints[y].rotation);
    }
}
