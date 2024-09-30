using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HitEffect : MonoBehaviour
{
    public UnityEvent OnHit;
    [SerializeField] Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Atk")
        {
            animator.SetTrigger("Hit");
            OnHit?.Invoke();
        }

    }
}
