using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] float MonsterHp;
    [SerializeField] float MonsterAtk;
    [SerializeField] float MonsterMoveSpeed;
    [SerializeField] float droprate;

    [SerializeField] GameObject player;


    // 플레이어 추적 및 공격 , 플레이어의 레벨에 따라 몬스터가 강해짐 
    private Transform playerTransform;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
    }

    private void Update()
    {
        TracePlayer();
        Moddie();
    }

    private void TracePlayer() 
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, MonsterMoveSpeed * Time.deltaTime);
    }
    private void AttackPlayer() {}
    public void onHit() 
    {    
        MonsterHp -= 10;
    }

    private void Moddie() 
    {
        // 몬스터 죽을때 아이템 생성(경험치 + 확률적으로 아이템), 킬수 올리기 
        if (MonsterHp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
