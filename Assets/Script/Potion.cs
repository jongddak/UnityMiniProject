using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Potion : MonoBehaviour
{
    public UnityEvent getPotion;

    private void Awake()
    {
        PlayerStat playerStat = FindAnyObjectByType<PlayerStat>();
        getPotion.AddListener(playerStat.heal);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            getPotion?.Invoke();
            Destroy(gameObject);
        }
    }
}
