using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] Slider Slider;

    public static int killCount = 0;
    private bool canTakeDamage = true;

    public UnityEvent Ondied;

    private void Awake()
    {
        plCurHp = 100;
        plMaxHp = 100;

        plCurExp = 0;
        plMaxExp = 0;

        plLevel = 1;

        platk = 10;
        
    }
    private void Update()
    {
        Die();
        Debug.Log(killCount);
        Slider.value = plCurHp/plMaxHp;
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
