using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Pause;   
    
    public static GameManager instance;
    private bool isPaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = new GameManager(); // this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
                Gamepauseui();
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
}
