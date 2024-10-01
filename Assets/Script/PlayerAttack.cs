using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float atkSpeed;
    [SerializeField] float atkSize;
    [SerializeField] int atkCount;



    [SerializeField] GameObject slashprefab;
    [SerializeField] GameObject slashprefab2;

    [SerializeField] Transform atkPoint;

    [SerializeField] GameObject player;


     // ���� ����  �⺻�� slash , ó�� ��ų����(5����)  ���� ��ȭ 

    
    private Coroutine atkroutine;
    private float curSize = 1;
    private float curSpeed = 1;
    private int curCount = 1;

    private PlayerStat.AtkType atkType; 
    private PlayerStat.AtkType curatktype = PlayerStat.AtkType.Slash;

    private PlayerStat playerStat;
    private void Awake()
    {
        playerStat = player.GetComponent<PlayerStat>();
        atkSize = playerStat.platkSize;
        atkCount = playerStat.platkCount;
        atkSpeed = playerStat.platkSpeed;
        atkType = playerStat.atktype;
    }
    private void Start()
    {
        atkroutine = StartCoroutine(Attacking(atkCount, atkSize, curatktype, atkSpeed));
    }
    private void Update()
    {
        atkSize = playerStat.platkSize;
        atkCount = playerStat.platkCount;
        atkSpeed = playerStat.platkSpeed;
        atkType = playerStat.atktype;
        Aiming();
        if (curSize != atkSize || curCount != atkCount || curSpeed != atkSpeed || curatktype != atkType)
        {
            if (atkroutine != null)
            {
                StopCoroutine(atkroutine);
            }


            curSize = atkSize;
            curCount = atkCount;
            curSpeed = atkSpeed;
            curatktype = atkType;
            //Ÿ���� �̱���


            atkroutine = StartCoroutine(Attacking(atkCount, atkSize, atkType, atkSpeed));
        }
    }
    IEnumerator Attacking(int atkcount, float atkSize, PlayerStat.AtkType atktype, float atkspeed) // ���ݼӵ��� �°� ����
    {
        WaitForSeconds atkTime = new WaitForSeconds(atkSpeed);
        WaitForSeconds minTime = new WaitForSeconds(0.1f);

        while (true)
        {
            for (int i = 0; i < atkcount; i++)
            {
                Attack(atkcount, atkSize, atktype);
                yield return minTime;
            }
            yield return atkTime;
        }
    }
    private void Attack(int atkcount, float atkSize, PlayerStat.AtkType atktype) // �ִϸ��̼� + ���� + ���־� ����Ʈ  �÷��̾��� �������� ���� ��ȭ�ؾ���  �μ��� ����Ƚ�� ���� ���� ? 
    {
        if (atktype == PlayerStat.AtkType.Slash)
        {
            GameObject atk = Instantiate(slashprefab, atkPoint.position, transform.rotation);
            atk.transform.localScale = new Vector3(atkSize, atkSize, atkSize);
            Transform atkchild = atk.transform.GetChild(0);
            atkchild.localScale = new Vector3(atkSize, atkSize, atkSize);

        }
        else if (atktype == PlayerStat.AtkType.Spark)
        {
            GameObject atk = Instantiate(slashprefab2, atkPoint.position, transform.rotation);
            atk.transform.localScale = new Vector3(atkSize, atkSize, atkSize);
            Transform atkchild = atk.transform.GetChild(0);
            atkchild.localScale = new Vector3(atkSize, atkSize, atkSize);
        }
    }

    private void Aiming()  // Į �ٶ󺸰� 
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePos - transform.position;


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
