using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float atkSpeed;
    [SerializeField] float atkRange;
    [SerializeField] int atkCount;
    [SerializeField] float atk;
    


    public enum AtkType  { Slash, Stap } // 공격 형태  기본은 slash , 처음 스킬에선(5레벨) 찌르기로 변경(변경 + 공격력정도 주면 될듯) or 베기 강화 
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
    IEnumerator Attacking(int atkcount, float atkrange, AtkType atktype, float atkspeed) // 공격속도에 맞게 공격
    {
       WaitForSeconds atkTime =  new WaitForSeconds(atkSpeed);

        while (true) 
        {
            Attack(atkcount,atkrange,atktype);
            yield return atkTime;
        }
    }
    private void Attack(int atkcount,float atkrange ,AtkType atktype ) // 애니메이션 + 사운드 + 비주얼 이펙트  플레이어의 선택지에 따라 변화해야함  인수로 공격횟수 범위 형태 ? 
    {
        if (atktype == AtkType.Slash)
        {
            for (int i = 0; i < atkcount; i++)
            {
                // 공격 횟수 만큼 반복해서 공격재생 
                Debug.Log("베기!");
            }
        }
        else if (atktype == AtkType.Stap)
        {
            for (int i = 0; i < atkcount; i++)
            {
                // 공격 횟수 만큼 반복해서 공격재생 
            }
        }
    }

    private void Aiming() 
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //화면상 마우스 위치 

        Vector2 direction = mousePos - transform.position;   // 마우스 위치와 회전할 오브젝트 사이의 거리 


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;  // 아무튼 수학공식으로 각도 구하고 변환 


        transform.rotation = Quaternion.Euler(0, 0, angle); // 2d 는 z 축만ㅁ 회전시키면 됨 
    }
}
