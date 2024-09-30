using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] float MonsterMaxHp;
    [SerializeField] float MonsterCurHp;

    
    [SerializeField] float MonsterMoveSpeed;
    [SerializeField] float droprate;

    [SerializeField] GameObject player;

    [SerializeField] GameObject potion;
    [SerializeField] GameObject Exp;

    [SerializeField] Slider slider;


    // �÷��̾� ���� �� ���� , �÷��̾��� ����or �ð�?�� ���� ���Ͱ� ������ 
    private Transform playerTransform;
    private int drop = 1;
    private PlayerStat playerStat;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        playerStat = player.GetComponent<PlayerStat>();
        MonsterCurHp = MonsterMaxHp;  
        
    }

    private void Update()
    {
        TracePlayer();
        Moddie();

        slider.value = MonsterCurHp / MonsterMaxHp;
    }

    private void TracePlayer() 
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, MonsterMoveSpeed * Time.deltaTime);
    }
    private void AttackPlayer() {}
    public void onHit() 
    {    
        MonsterCurHp -= playerStat.platk; 
    }

    private void Moddie() 
    {
        // ���� ������ ������ ����(����ġ + Ȯ�������� ������), ų�� �ø��� 
        if (MonsterCurHp <= 0)
        {   
            int x = Random.Range(0, 50);
            if (x == drop) 
            {
              Instantiate(potion,transform.position,transform.rotation);  // ����   
            }
            Instantiate(Exp, transform.position, transform.rotation);  // ����ġ
            Destroy(gameObject); // ���� ����
            PlayerStat.killCount++;

        }
    }

}
