using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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


    [SerializeField] GameObject selectUi;
    [SerializeField] GameObject buff;
    [SerializeField] GameObject spark;  
    [SerializeField] CircleCollider2D circleCollider;

    public enum AtkType { Slash, Spark }
   
    public AtkType atktype = AtkType.Slash;

    public static int killCount = 0;
    private bool canTakeDamage = true;
     
    public UnityEvent Ondied;  // ���߿� ������ �̺�Ʈ �޾��ٰ�
    public UnityEvent Onskill;
    public UnityEvent OnskillUi;

    public delegate void SkillAction();
    [SerializeField] public List<SkillAction> skillList = new List<SkillAction>();

    private bool LevelUpch = false;
    private void Awake()
    {
        shoot = false;
        rotateslash = false;

        skillList.Add(AddaktCount);
        skillList.Add(BiggerSize);
        skillList.Add(RotateSlash);
        skillList.Add(Onshooting);
        skillList.Add(Buff);
        skillList.Add(SparkOn);
        skillList.Add(Regen);

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
        atktext.text = platk.ToString();
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
        Debug.Log("�浹, ü�� ����");
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
        plCurExp += 20;
        if (plCurExp >= plMaxExp) 
        {
            plCurExp = 0;
            plMaxExp = plMaxExp*1.3f;
            Debug.Log("������");
            plLevel++;
            LevelUpch = false;
        }

        if (plLevel % 3 == 0) 
        {
            if (plLevel < 16)
            {
                if (LevelUpch == false)
                {
                    LevelUpch = true;
                    // 3�� ������� ��ų���� ui ���� �̺�Ʈó�� + ���� �Ͻ����� 
                    selectUi.SetActive(true);
                    OnskillUi?.Invoke();
                    Onskill?.Invoke();
                }
            }
            
        }
    }
    public void heal() 
    {
        plCurHp += 50;
    }
    public void getMagnet() 
    {
        StartCoroutine(magnetic());
    }
    IEnumerator magnetic() 
    {
        WaitForSeconds time = new WaitForSeconds(5f);
        while (true)
        {
            circleCollider.radius += 200f;
            yield return time;
            break;
        }
        circleCollider.radius = 2.7f;
    }

    public void AddaktCount()  //0��
    {
        platkCount+=2;
        selectUi.SetActive(false);
        Onskill?.Invoke();
        Time.timeScale = 1f;
    }
    public void BiggerSize()  // 1��
    {
        platkSize+=3;
        selectUi.SetActive(false);
        Time.timeScale = 1f;

    }
    public void RotateSlash() //2
    {
        rotateslash = true;
        platkRange += 3;
        selectUi.SetActive(false);
        Time.timeScale = 1f;

    }
    public void Onshooting() //3
    {
        shoot = true;
        platkRange += 3;
        selectUi.SetActive(false);
        Time.timeScale = 1f;

    }

    public void Buff() // �̺�Ʈ�� ó������ , �ش� ��ų ��ư ������ �ٲ�� 4��
    {
        // �÷��̾� ��ƼŬ ������Ʈ on  + ���� ���� 
        buff.SetActive(true);
        

        platk += 20;
        platkCount += 1;
        platkRange += 1;
        platkSize += 1;
        platkSpeed *= 0.7f;
        plMaxHp += 30;
        plCurHp += 30;
        plmoveSpeed += 1;
        selectUi.SetActive(false);
        Time.timeScale = 1f;
    }  
    public void SparkOn()// 5�� 
    {
        // �÷��̾� ��ƼŬ ������Ʈ on  + ���� ���� 
        spark.SetActive(true);
        atktype = AtkType.Spark;
        platkCount += 1;
        platkRange += 1;
        platkSpeed *= 0.7f;
        plmoveSpeed += 1;
        selectUi.SetActive(false);
        Time.timeScale = 1f;

    }
    public void Regen()  // �̰ŵ� �̺�Ʈ��  6��
    {
        StartCoroutine(regenarator());
        selectUi.SetActive(false);
        Time.timeScale = 1f;
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

}
