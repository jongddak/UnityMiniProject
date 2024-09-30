using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        
    }

    private void Update()
    {
        TracePlayer();
    }

    private void TracePlayer() 
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, MonsterMoveSpeed * Time.deltaTime);
    }
    private void AttackPlayer() {}
}
