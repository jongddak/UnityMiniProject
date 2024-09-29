using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float atkSpeed;
    [SerializeField] float atkRange;
    [SerializeField] int atkCount;
    [SerializeField] float atk;
    


    public enum AtkType  { Slash, Stap } // ���� ����  �⺻�� slash , ó�� ��ų����(5����) ���� ����(���� + ���ݷ����� �ָ� �ɵ�) or ���� ��ȭ 
    // 
    private AtkType curatktype = AtkType.Slash; 
    private void Start()
    {
        StartCoroutine(Attacking(atkCount,atkRange,curatktype,atkSpeed));
    }
    private void Update()
    {
        Aiming();
    }
    IEnumerator Attacking(int atkcount, float atkrange, AtkType atktype, float atkspeed) // ���ݼӵ��� �°� ����
    {
       WaitForSeconds atkTime =  new WaitForSeconds(atkSpeed);

        while (true) 
        {
            Attack(atkcount,atkrange,atktype);
            yield return atkTime;
        }
    }
    private void Attack(int atkcount,float atkrange ,AtkType atktype ) // �ִϸ��̼� + ���� + ���־� ����Ʈ  �÷��̾��� �������� ���� ��ȭ�ؾ���  �μ��� ����Ƚ�� ���� ���� ? 
    {
        if (atktype == AtkType.Slash)
        {
            for (int i = 0; i < atkcount; i++)
            {
                // ���� Ƚ�� ��ŭ �ݺ��ؼ� ������� 
                Debug.Log("����!");
            }
        }
        else if (atktype == AtkType.Stap)
        {
            for (int i = 0; i < atkcount; i++)
            {
                // ���� Ƚ�� ��ŭ �ݺ��ؼ� ������� 
            }
        }
    }

    private void Aiming() 
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //ȭ��� ���콺 ��ġ 

        Vector2 direction = mousePos - transform.position;   // ���콺 ��ġ�� ȸ���� ������Ʈ ������ �Ÿ� 


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;  // �ƹ�ư ���а������� ���� ���ϰ� ��ȯ 


        transform.rotation = Quaternion.Euler(0, 0, angle); // 2d �� z �ุ�� ȸ����Ű�� �� 
    }
}
