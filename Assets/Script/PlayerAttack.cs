using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float atkSpeed;
    [SerializeField] float atkRange;
    [SerializeField] float atkSize;
    [SerializeField] int atkCount;
    


    [SerializeField] GameObject slashprefab;
    [SerializeField] Transform atkPoint;

    [SerializeField] GameObject player;


    public enum AtkType  { Slash, Stap } // ���� ����  �⺻�� slash , ó�� ��ų����(5����)  ���� ��ȭ 
    
    private AtkType curatktype = AtkType.Slash;
    private Coroutine atkroutine;
    private float curSize = 1;
    private float curRange = 1;
    private float curSpeed = 1;
    private int curCount = 1;
    private PlayerStat playerStat;
    private void Awake()
    {
        playerStat = player.GetComponent<PlayerStat>();
        atkSize = playerStat.platkSize;
        atkCount = playerStat.platkCount;
        atkRange = playerStat.platkRange;
        atkSpeed = playerStat.platkSpeed;   
    }
    private void Start()
    {
        atkroutine = StartCoroutine(Attacking(atkCount,atkSize,atkRange,curatktype,atkSpeed));
    }
    private void Update()
    {
        atkSize = playerStat.platkSize;
        atkCount = playerStat.platkCount;
        atkRange = playerStat.platkRange;
        atkSpeed = playerStat.platkSpeed;

        Aiming();
        if (curSize != atkSize || curRange != atkRange || curCount != atkCount || curSpeed != atkSpeed)
        {
            if (atkroutine != null)
            {
                StopCoroutine(atkroutine); 
            }

           
            curSize = atkSize;
            curRange = atkRange;
            curCount = atkCount;
            curSpeed = atkSpeed;

           
            atkroutine = StartCoroutine(Attacking(atkCount, atkSize, atkRange, curatktype, atkSpeed));
        }
    }
    IEnumerator Attacking(int atkcount,float atkSize, float atkrange, AtkType atktype, float atkspeed) // ���ݼӵ��� �°� ����
    {
       WaitForSeconds atkTime =  new WaitForSeconds(atkSpeed);

        while (true) 
        {
            Attack(atkcount,atkrange,atkSize,atktype);
            yield return atkTime;
        }
    }
    private void Attack(int atkcount,float atkrange ,float atkSize,AtkType atktype ) // �ִϸ��̼� + ���� + ���־� ����Ʈ  �÷��̾��� �������� ���� ��ȭ�ؾ���  �μ��� ����Ƚ�� ���� ���� ? 
    {
        if (atktype == AtkType.Slash)
        {
            for (int i = 0; i < atkcount; i++)
            {
                // ���� Ƚ�� ��ŭ �ݺ��ؼ� ������� 
                Debug.Log("����!");
                GameObject atk = Instantiate(slashprefab, atkPoint.position, transform.rotation);
                atk.transform.localScale = new Vector3(atkSize, atkSize, atkSize);
                BoxCollider2D slashCollider = atk.GetComponent<BoxCollider2D>();
                slashCollider.size = new Vector3(atkSize, atkSize, atkSize);
            }
        }
        else if (atktype == AtkType.Stap)
        {
            for (int i = 0; i < atkcount; i++)
            {
                // ���� �̱���
                Debug.Log("���!");
            }
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
