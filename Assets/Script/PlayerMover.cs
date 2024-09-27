using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    // 플레이어 이동기능 , 스프라이트 플립, 
    // 마우스위치에 따라 플레이어가 든 무기가 마우스를 바라보게(+공격 위치 조정)

    [SerializeField] float moveSpeed;
    [SerializeField] SpriteRenderer spriteRenderer;


    private void Update()
    {
        Move();

    }

    private void Move() 
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        transform.Translate(Vector2.right * moveSpeed * x * Time.deltaTime);
        transform.Translate(Vector2.up * moveSpeed * y * Time.deltaTime);


        if (x < 0) 
        {

            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }


}
