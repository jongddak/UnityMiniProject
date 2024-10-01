using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] public float platkSpeed;
    [SerializeField] public float platkRange;
    [SerializeField] public float platkSize;
    [SerializeField] public int platkCount;
    [SerializeField] public float platk;
    [SerializeField] public float plmoveSpeed;

    [SerializeField] public bool shoot;
    [SerializeField] public bool rotateslash;
    

    [SerializeField] float plCurHp;
    [SerializeField] float plMaxHp;
    [SerializeField] float plCurExp;
    [SerializeField] float plMaxExp;

    [SerializeField] float plLevel;

    [SerializeField] GameObject weapon;
    [SerializeField] GameObject mover;

    [SerializeField] Slider hpSlider;
    [SerializeField] Slider expSlider;

    [SerializeField] TextMeshProUGUI atktext;
    [SerializeField] TextMeshProUGUI atkspeedtext;
    [SerializeField] TextMeshProUGUI atkcounttext;
    [SerializeField] TextMeshProUGUI atksizetext;
    [SerializeField] TextMeshProUGUI atkrangeext;
    [SerializeField] TextMeshProUGUI killcounttext;
    [SerializeField] TextMeshProUGUI movespeedtext;
    [SerializeField] TextMeshProUGUI leveltext;
    [SerializeField] TextMeshProUGUI curhptext;
    [SerializeField] TextMeshProUGUI maxhptext;

    [SerializeField] GameObject buff;
    [SerializeField] GameObject spark;  

    public enum AtkType { Slash, Spark }
   
    public AtkType atktype = AtkType.Slash;

    public static int killCount = 0;
    private bool canTakeDamage = true;
     
    public UnityEvent Ondied;  // 나중에 죽으면 이벤트 달아줄거

    private void Awake()
    {
        shoot = false;
        rotateslash = false;
        
    }
    private void Update()
    {
        Die();
        plCurHp = Mathf.Clamp(plCurHp, float.MinValue, plMaxHp);
        hpSlider.value = plCurHp/plMaxHp;
        expSlider.value = plCurExp / plMaxExp;
        leveltext.text = plLevel.ToString();
        killcounttext.text = killCount.ToString();

        curhptext.text = "/" + plMaxHp.ToString();
        maxhptext.text = plCurHp.ToString();

        movespeedtext.text = plmoveSpeed.ToString("F2");
        atkspeedtext.text = platkSpeed.ToString("F2");
        atkcounttext.text = platkCount.ToString();
        atkrangeext.text = platkRange.ToString("F2");
        atktext.text = platk.ToString("F2");
        atksizetext.text = platkSize.ToString("F2");



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mob" && canTakeDamage)
        {
            StartCoroutine(takeHit());
        }
    }

    IEnumerator takeHit()
    {

        canTakeDamage = false;
        Debug.Log("충돌, 체력 감소");
        plCurHp -= 10;
        yield return new WaitForSeconds(0.2f);
        canTakeDamage = true;
    }
    private void Die() 
    {
        if (plCurHp <= 0) 
        {
            Ondied.Invoke();
            Destroy(gameObject);

        }
    }

    public void LevelUp() 
    {
        plCurExp += 10;
        if (plCurExp >= plMaxExp) 
        {
            plCurExp = 0;
            plMaxExp = plMaxExp*1.3f;
            Debug.Log("레벨업");
            plLevel++;
        }

        if (plLevel % 3 == 0) 
        {
            // 3의 배수마다 스킬선택 ui 등장 이벤트처리 + 게임 일시정지 
        }
    }
    public void heal() 
    {
        plCurHp += 30;
    }
    public void Regen()  // 이거도 이벤트로 
    {
        StartCoroutine(regenarator());
    }
    IEnumerator regenarator() 
    {
        WaitForSeconds time = new WaitForSeconds(3f);
        while (true) 
        {
            yield return time;
            plCurHp++;
        }
    }
    public void Buff() // 이벤트로 처리하자 , 해당 스킬 버튼 누르면 바뀌게 
    {
        // 플레이어 파티클 오브젝트 on  + 스탯 증가 
        buff.SetActive(true);
    }  
    public void SparkOn() 
    {
        // 플레이어 파티클 오브젝트 on  + 스탯 증가 
        spark.SetActive(true);
        atktype = AtkType.Spark;
    }
}
