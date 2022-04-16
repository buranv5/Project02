using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NonPlayerCharacter : MonoBehaviour
{
    [SerializeField] private protected float moveSpeed;

    private protected Rigidbody2D rigidbody;
    private protected Animator animator;

    private protected void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
    }

    private protected virtual void Update() {
        if (rigidbody.velocity != Vector2.zero) {
            animator.SetBool("Running", true);
        } else {
            animator.SetBool("Running", false);
        }
    }
}
