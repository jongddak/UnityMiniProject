using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    // �÷��̾� �̵���� , ��������Ʈ �ø�, 
    // ���콺��ġ�� ���� �÷��̾ �� ���Ⱑ ���콺�� �ٶ󺸰�(+���� ��ġ ����)

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
