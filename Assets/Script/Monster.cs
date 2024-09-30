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

    // �÷��̾� ���� �� ���� , �÷��̾��� ������ ���� ���Ͱ� ������ 
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
