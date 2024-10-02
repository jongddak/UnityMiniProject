using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Magnet : MonoBehaviour
{
    public UnityEvent getMagnet;

    private void Awake()
    {
        PlayerStat playerStat = FindAnyObjectByType<PlayerStat>();
        getMagnet.AddListener(playerStat.getMagnet);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            getMagnet?.Invoke();
            Destroy(gameObject);
        }
    }
}
