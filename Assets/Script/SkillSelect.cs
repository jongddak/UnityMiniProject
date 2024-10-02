using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillSelect : MonoBehaviour
{

    [SerializeField] List<Sprite> skillSprites;

    [SerializeField] Button imageButton1;
    [SerializeField] TextMeshProUGUI SkillDesc1;

    [SerializeField] Button imageButton2;
    [SerializeField] TextMeshProUGUI SkillDesc2;

    [SerializeField] Button imageButton3;
    [SerializeField] TextMeshProUGUI SkillDesc3;


    [SerializeField] Image imageeq1;
    [SerializeField] Image imageeq2;
    [SerializeField] Image imageeq3;
    [SerializeField] Image imageeq4;
    [SerializeField] Image imageeq5;

    private bool skillSelected = false;
    private List<string> skillDescs = new List<string>
    {
        "���� Ƚ���� �ø��ϴ�.",
        "������ ������ �ſ� Ŀ���ϴ�.",
        "������ ȸ���ϰ� ��Ÿ��� �����մϴ�.",
        "������ �������� �߻��մϴ�.",
        "��� ������ ����մϴ�.",
        "��� �ӵ��� ����ϰ� ������ ���°� �ٲ�ϴ�.",   // ��Ÿ��� �÷�����
        "���������� ü���� ȸ���˴ϴ�",
    };

    public UnityEvent skill1;
    public UnityEvent skill2;
    public UnityEvent skill3;
    public UnityEvent skill4;
    public UnityEvent skill5;
    public UnityEvent skill6;
    public UnityEvent skill7;

    public void SelectSkills()
    {
        if (skillSprites.Count <= 2)
        {
            ClearButtons();
            return;
        }

        List<int> selectedSkillIndices = GetRandomSkills(3);

        // ù ��° ��ų ����
        imageButton1.image.sprite = skillSprites[selectedSkillIndices[0]];
        SkillDesc1.text = skillDescs[selectedSkillIndices[0]];

        // �� ��° ��ų ����
        imageButton2.image.sprite = skillSprites[selectedSkillIndices[1]];
        SkillDesc2.text = skillDescs[selectedSkillIndices[1]];

        // �� ��° ��ų ����
        imageButton3.image.sprite = skillSprites[selectedSkillIndices[2]];
        SkillDesc3.text = skillDescs[selectedSkillIndices[2]];

        // ������ ���� (�ߺ� ����)
        PlayerStat playerStat = FindAnyObjectByType<PlayerStat>();

        imageButton1.onClick.RemoveAllListeners();
        int skillIndex1 = selectedSkillIndices[0];
        imageButton1.onClick.AddListener(() => playerStat.skillList[skillIndex1]());
        imageButton1.onClick.AddListener(() => setImage(skillIndex1));
        

        imageButton2.onClick.RemoveAllListeners();
        int skillIndex2 = selectedSkillIndices[1];
        imageButton2.onClick.AddListener(() => playerStat.skillList[skillIndex2]());
        imageButton2.onClick.AddListener(() => setImage(skillIndex2));
        

        imageButton3.onClick.RemoveAllListeners();
        int skillIndex3 = selectedSkillIndices[2];
        imageButton3.onClick.AddListener(() => playerStat.skillList[skillIndex3]());
        imageButton3.onClick.AddListener(() => setImage(skillIndex3));

    }

    private List<int> GetRandomSkills(int count)
    {
        List<int> indices = new List<int>();
        while (indices.Count < count)
        {
            int randomIndex = Random.Range(0, skillSprites.Count);
            if (!indices.Contains(randomIndex))
            {
                indices.Add(randomIndex);
            }
        }
        return indices;
    }
    

    private void ClearButtons()
    {
        // ���� ��ų�� 2�� ������ ��� �� ��ư�� ǥ��
        imageButton1.image.sprite = null;
        SkillDesc1.text = "";

        imageButton2.image.sprite = null;
        SkillDesc2.text = "";

        imageButton3.image.sprite = null;
        SkillDesc3.text = "";

        // ������ ����
        imageButton1.onClick.RemoveAllListeners();
        imageButton2.onClick.RemoveAllListeners();
        imageButton3.onClick.RemoveAllListeners();
    }

    public void setImage(int skillIndex)
    {
        PlayerStat playerStat = FindAnyObjectByType<PlayerStat>();
       

        
        if (imageeq1.sprite == null)
        {
            imageeq1.sprite = skillSprites[skillIndex];
            imageeq1.color = new Color(255f, 255f, 255f, 255f);
        }
        else if (imageeq2.sprite == null)
        {
            imageeq2.sprite = skillSprites[skillIndex];
            imageeq2.color = new Color(255f, 255f, 255f, 255f);
        }
        else if (imageeq3.sprite == null)
        {
            imageeq3.sprite = skillSprites[skillIndex];
            imageeq3.color = new Color(255f, 255f, 255f, 255f);
        }
        else if (imageeq4.sprite == null)
        {
            imageeq4.sprite = skillSprites[skillIndex];
            imageeq4.color = new Color(255f, 255f, 255f, 255f);
        }
        else if (imageeq5.sprite == null)
        {
            imageeq5.sprite = skillSprites[skillIndex];
            imageeq5.color = new Color(255f, 255f, 255f, 255f);
        }

        // ���õ� ��ų�� �����Ͽ� �ε����� ������ �ʵ��� ��
        skillSprites.RemoveAt(skillIndex);
        skillDescs.RemoveAt(skillIndex);
        playerStat.skillList.RemoveAt(skillIndex);

        skillSelected = true;  // ��ų ���õ�
    }

}
