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


    // 플레이어 추적 및 공격 , 플레이어의 레벨or 시간?에 따라 몬스터가 강해짐 
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
        MonsterCurHp -= 10;  // 플레이어 공격에 연동해야함 
    }

    private void Moddie() 
    {
        // 몬스터 죽을때 아이템 생성(경험치 + 확률적으로 아이템), 킬수 올리기 
        if (MonsterCurHp <= 0)
        {
            Destroy(gameObject);
            PlayerStat.killCount++;

        }
    }

}
