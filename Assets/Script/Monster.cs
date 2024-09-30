using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] float MonsterMaxHp;
    [SerializeField] float MonsterCurHp;

    [SerializeField] float MonsterAtk;
    [SerializeField] float MonsterMoveSpeed;
    [SerializeField] float droprate;

    [SerializeField] GameObject player;

    [SerializeField] Slider slider;


    // �÷��̾� ���� �� ���� , �÷��̾��� ����or �ð�?�� ���� ���Ͱ� ������ 
    private Transform playerTransform;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();

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
        MonsterCurHp -= 10;  // �÷��̾� ���ݿ� �����ؾ��� 
    }

    private void Moddie() 
    {
        // ���� ������ ������ ����(����ġ + Ȯ�������� ������), ų�� �ø��� 
        if (MonsterCurHp <= 0)
        {
            Destroy(gameObject);
            PlayerStat.killCount++;

        }
    }

}
