using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10f);
    }
}
