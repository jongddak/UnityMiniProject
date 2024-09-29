using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    // �÷��̾� �̵���� , ��������Ʈ �ø�, 
    // ���콺��ġ�� ���� �÷��̾ �� ���Ⱑ ���콺�� �ٶ󺸰�(+���� ��ġ ����)

    [SerializeField] float moveSpeed;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Collider2D bound;


    private Bounds bounds;

    private void Start()
    {
        bounds = bound.bounds;
    }


    private void Update()  // fixed? 
    {
        Move();


    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


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

        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, bounds.min.x,bounds.max.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, bounds.min.y, bounds.max.y);


        transform.position = clampedPosition;
    }




}
