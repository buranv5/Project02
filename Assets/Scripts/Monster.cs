using UnityEngine;
using System.Collections;

public class Monster : NonPlayerCharacter
{
    [SerializeField] private float freeRadius;
    [SerializeField] private float delay; // changing the direction of movement max delay
     
    private Vector2 spawnLocation, goingVector;

    private protected void Start() {
        spawnLocation = transform.position;
        StartCoroutine(AnimationControl());
        StartCoroutine(directionDetermining());
    }

    private protected override void Update() { 
        rigidbody.velocity = goingVector * moveSpeed * Time.deltaTime; 
    } 
    
    IEnumerator AnimationControl() {
        while (true) {
            if (rigidbody.velocity != Vector2.zero) {

                animator.SetBool("Running", true);

                if (rigidbody.velocity.y > 0) {
                    animator.SetBool("FaceToCamera", false);
                } else if (rigidbody.velocity.y < 0) {
                   animator.SetBool("FaceToCamera", true);
                }

                if (rigidbody.velocity.x > 0) {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                } else {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }

            } else {
                animator.SetBool("Running", false);
            }

            yield return null;
        }
    }

    IEnumerator directionDetermining() {
        while (true) {
            if (Vector2.Distance(transform.position, spawnLocation) > freeRadius)  {
                Vector2 vector2position = new Vector2(transform.position.x, transform.position.y);
                goingVector = (spawnLocation - vector2position);
            } else {
                goingVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            }
            yield return new WaitForSeconds(Random.Range(0, delay));
        }
    }

    private protected void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            Debug.Log("The player is nearby");
        }
    }
}
