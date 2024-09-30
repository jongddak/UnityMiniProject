using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exp : MonoBehaviour
{
    public UnityEvent getExp;

    private void Awake()
    {
        PlayerStat playerStat = FindAnyObjectByType<PlayerStat>();
        getExp.AddListener(playerStat.LevelUp);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {   
            getExp?.Invoke();
            Destroy(gameObject);
        }
    }
}
