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
    [SerializeField] float atk;


    [SerializeField] GameObject slashprefab;
    [SerializeField] Transform atkPoint;
    

    
    public enum AtkType  { Slash, Stap } // 공격 형태  기본은 slash , 처음 스킬에선(5레벨) 찌르기로 변경(변경 + 공격력정도 주면 될듯) or 베기 강화 
    
    private AtkType curatktype = AtkType.Slash;
    private Coroutine atkroutine;
    private float curSize = 1;
    private float curRange = 1;
    private float curSpeed = 1;
    private int curCount = 1;
    private void Start()
    {
        atkroutine = StartCoroutine(Attacking(atkCount,atkSize,atkRange,curatktype,atkSpeed));
    }
    private void Update()
    {
        Aiming();
        if (curSize != atkSize || curRange != atkRange || curCount != atkCount || curSpeed != atkSpeed)
        {
            if (atkroutine != null)
            {
                StopCoroutine(atkroutine); // 실행 중인 코루틴을 멈춤
            }

            // 업데이트된 값 반영
            curSize = atkSize;
            curRange = atkRange;
            curCount = atkCount;
            curSpeed = atkSpeed;

            // 새로운 코루틴 시작
            atkroutine = StartCoroutine(Attacking(atkCount, atkSize, atkRange, curatktype, atkSpeed));
        }
    }
    IEnumerator Attacking(int atkcount,float atkSize, float atkrange, AtkType atktype, float atkspeed) // 공격속도에 맞게 공격
    {
       WaitForSeconds atkTime =  new WaitForSeconds(atkSpeed);

        while (true) 
        {
            Attack(atkcount,atkrange,atkSize,atktype);
            yield return atkTime;
        }
    }
    private void Attack(int atkcount,float atkrange ,float atkSize,AtkType atktype ) // 애니메이션 + 사운드 + 비주얼 이펙트  플레이어의 선택지에 따라 변화해야함  인수로 공격횟수 범위 형태 ? 
    {
        if (atktype == AtkType.Slash)
        {
            for (int i = 0; i < atkcount; i++)
            {
                // 공격 횟수 만큼 반복해서 공격재생 
                Debug.Log("베기!");
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
                // 공격 횟수 만큼 반복해서 공격재생 
                Debug.Log("찌르기!");
            }
        }
    }

    private void Aiming() 
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 

        Vector2 direction = mousePos - transform.position;


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
