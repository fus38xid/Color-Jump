using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player.position.y > transform.position.y) //follow player only upwards
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z); //follow player
        }
    }
}
