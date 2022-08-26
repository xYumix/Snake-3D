using UnityEngine;

public class TouchingCrash : MonoBehaviour
{

    public bool TouchedLeft = false;
    public bool TouchedRight = false;


    public bool Destruction = false;
    float destroySpeed = 0.05f;

    private void Update()
    {
        if (Destruction)
        {
            if (transform.localScale.x>0)
            {
                transform.localScale = new Vector3(transform.localScale.x - destroySpeed, transform.localScale.y - destroySpeed, transform.localScale.z - destroySpeed);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CrashLeft") && other.gameObject.transform.position.x > transform.position.x)
        {
            TouchedLeft = true;
        }
        if (other.gameObject.CompareTag("CrashRight") && other.gameObject.transform.position.x < transform.position.x)
        {
            TouchedRight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CrashLeft"))
        {
            TouchedLeft = false;
        }
        if (other.gameObject.CompareTag("CrashRight"))
        {
            TouchedRight = false;
        }
    }
}
