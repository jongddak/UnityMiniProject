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

    public static int killCount = 0;
    private bool canTakeDamage = true;
     
    public UnityEvent Ondied;  // 나중에 죽으면 이벤트 달아줄거

  
    private void Update()
    {
        Die();

        hpSlider.value = plCurHp/plMaxHp;
        expSlider.value = plCurExp / plMaxExp;
        leveltext.text = plLevel.ToString();
        killcounttext.text = killCount.ToString();
        maxhptext.text = plMaxHp.ToString();
        curhptext.text = "/" + plCurHp.ToString();

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
        plCurExp += 5;
        if (plCurExp >= plMaxExp) 
        {
            plCurExp = 0;
            plMaxExp = plMaxExp*1.3f;
            Debug.Log("레벨업");
            plLevel++;
        }
    }
    public void heal() 
    {
        plCurHp += 30;
    }
}
