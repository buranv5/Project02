using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{ 
    [SerializeField] private float moveSpeed;
    [SerializeField] private FixedJoystick joystick;
    private Animator animator;
    private Rigidbody2D rigidbody;

    void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        rigidbody.velocity = new Vector2(joystick.Horizontal, joystick.Vertical) * moveSpeed * Time.deltaTime;
        if (rigidbody.velocity != Vector2.zero) { 
            animator.SetBool("Running", true); 
        } else { 
            animator.SetBool("Running", false);
        }

        if (rigidbody.velocity.x < 0) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
