using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackobject : MonoBehaviour
{

    
    private PlayerStat playerStat;
    private float range;
    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerStat = player.GetComponent<PlayerStat>();
        range = playerStat.platkRange;
    }
    private void Start()
    {
        Destroy(gameObject, range);
    }
    private void Update()
    {
        shooting();
        RotateSlash();
    }


    // 추가기능
    private void shooting() 
    {
        if (playerStat.shoot == true)
        {
            transform.Translate(Vector2.right * 10f * (range + 1) * Time.deltaTime);
        }
    }
    private void RotateSlash() 
    {
        if (playerStat.rotateslash == true)
        {
            transform.Rotate(0f, 0f, 2000f * Time.deltaTime);
        }
    }
}
