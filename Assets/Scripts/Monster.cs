using UnityEngine;
using System.Collections;

public class Monster : NonPlayerCharacter
{
    [SerializeField] private protected float freeRadius;
    [SerializeField] private protected float delay; //changing the direction of movement delay

    private protected Vector2 spawnLocation;
    private Vector2 waypoint;
    private Vector2[] waypoints = new Vector2[5];

    private protected override void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private protected void Start() {
        spawnLocation = transform.position;
        waypoints[0] = spawnLocation;
        waypoints[1] = new Vector2(spawnLocation.x, spawnLocation.y + freeRadius);
        waypoints[2] = new Vector2(spawnLocation.x, spawnLocation.y - freeRadius);
        waypoints[3] = new Vector2(spawnLocation.x + freeRadius, spawnLocation.y);
        waypoints[4] = new Vector2(spawnLocation.x - freeRadius, spawnLocation.y);
        
        StartCoroutine(directionDetermining());
    }

    private protected override void Update() {
        Vector2 vector2position = new Vector2(transform.position.x , transform.position.y);
        rigidbody.velocity = (waypoint - vector2position) * moveSpeed * Time.deltaTime;

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

    }

    IEnumerator directionDetermining() {
        while (true) {
            waypoint = waypoints[Random.Range(0, 5)];
            Debug.Log(waypoint);
            yield return new WaitForSeconds(delay);
        }
    }

    private protected void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            Debug.Log("The player is nearby");
        }
    }
}
