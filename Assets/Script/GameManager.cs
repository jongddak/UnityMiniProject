using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Pause;
    [SerializeField] TextMeshProUGUI Timertext;

    [SerializeField] Button startbutton;  

    public static GameManager instance;
    private bool isPaused = false;
    private float sec = 0;
    private int min = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       //Pause = GameObject.FindGameObjectWithTag("pause");
       //GameObject text = GameObject.FindGameObjectWithTag("timer");
       //Timertext = text.GetComponent<TextMeshProUGUI>();
        
    }       
    private void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
                Gamepauseui();
        }
        Timer();
    }
   // public void GameStart()
   // {
   //     SceneManager.LoadScene("Game");
   // }
    private void Timer() 
    {
        if (Timertext != null)
        {
            sec += Time.deltaTime;
            if (sec >= 60f)
            {
                min += 1;
                sec = 0;
            }
            Timertext.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);
        }
    }
    public void Gamepauseui()  // ���߿� �̺�Ʈ�ε� ���Ŵϱ� �ۺ�
    {
        if (isPaused == false)
        {
            isPaused = true;
            // ���� + ui �ѱ�
            Time.timeScale = 0f;
            Pause.SetActive(true);
        }
        else 
        {   

            isPaused = false;
            // �ٽ� ������ ���� �簳 + ui ����
            Time.timeScale = 1f;  
            Pause.SetActive(false);
        }
    }
    public void Gamepause() 
    {
        if (isPaused == false)
        {
            isPaused = true;
            Time.timeScale = 0f;
            
        }
        else
        {
            isPaused = false; 
            Time.timeScale = 1f;
            
        }
    }

    public void Gameover() 
    {   
        
        if (isPaused == false)
        {
            isPaused = true;
            // ���� + ui �ѱ�
            Time.timeScale = 0f;
            Pause.SetActive(true);
        }
        else
        {

            isPaused = false;
            // �ٽ� ������ ���� �簳 + ui ����
            Time.timeScale = 1f;
            Pause.SetActive(false);
        }

       
    }

    public void GameOff() 
    {
        Application.Quit();
    }
    public void Restart() 
    {
        SceneManager.LoadScene("Game");
    }
}
