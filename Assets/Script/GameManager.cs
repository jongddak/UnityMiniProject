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

    public void Gamepauseui()  // 나중에 이벤트로도 쓸거니까 퍼블릭
    {
        if (isPaused == false)
        {
            isPaused = true;
            // 정지 + ui 켜기
            Time.timeScale = 0f;
            Pause.SetActive(true);
        }
        else 
        {   

            isPaused = false;
            // 다시 누르면 게임 재개 + ui 끄기
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
            // 정지 + ui 켜기
            Time.timeScale = 0f;
            Pause.SetActive(true);
        }
        else
        {

            isPaused = false;
            // 다시 누르면 게임 재개 + ui 끄기
            Time.timeScale = 1f;
            Pause.SetActive(false);
        }
    }
}
