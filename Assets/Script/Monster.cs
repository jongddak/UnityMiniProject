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


    // �÷��̾� ���� �� ���� , �÷��̾��� ������ ���� ���Ͱ� ������ 
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
        // ���� ������ ������ ����(����ġ + Ȯ�������� ������), ų�� �ø��� 
        if (MonsterHp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
