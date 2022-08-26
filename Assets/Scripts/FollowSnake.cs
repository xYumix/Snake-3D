using UnityEngine;

public class FollowSnake : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    
    void Update()
    {
        transform.position = new Vector3(transform.position.x, target.position.y + offset.y, target.position.z + offset.z); ;
    }
}
