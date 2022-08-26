using UnityEngine;

public class MoveHead : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public int tailLength = 1;
    private TailMove TailScript;
    float screenDistance;
    Vector3 mousePos;
    Vector3 screenTouch;
    bool mouseMoved = false;
    bool screenTouched = false;
    float changePos=0;

    float damp = 0.01f;


    bool SnakeStopped = false;
    float deltaTimer = 0;

    public bool TouchedLeft = false;
    public bool TouchedRight = false;
    Vector3 StartPos = Vector3.zero;

    public GameController GameController;
    private void Awake()
    {
        TailScript = GetComponent<TailMove>();
    }
    void Start()
    {
        StartPos = transform.position;
        GetComponent<MeshRenderer>().material.color = Camera.main.GetComponent<SetColorPattern>().SnakeColor;
    }

    void Update()
    {
        screenDistance = Camera.main.WorldToScreenPoint(transform.position).z;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenDistance));
        if (Input.GetMouseButtonDown(0))
        {
            screenTouch = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenDistance));
            screenTouched = true;
        }
        if (screenTouched)
        {
            changePos = Mathf.Abs(mousePos.x - screenTouch.x);
            if (changePos > 1f)
            {
                mouseMoved = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseMoved = false;
            screenTouched = false;
        }
        if (Input.GetMouseButton(0) && mouseMoved && !GameController.GamePaused)
        {

            Vector3 direction = new Vector3(mousePos.x, transform.position.y, transform.position.z);
            if (TouchedLeft)
            {
                if (direction.x > 0)
                {
                    direction.x = 0;
                }
            }
            if (TouchedRight)
            {
                if (direction.x < 0)
                {
                    direction.x = 0;
                }
            }
            if (!(transform.position.x < StartPos.x - 7 && direction.x < 0) && !(transform.position.x > StartPos.x + 7 && direction.x > 0))
            {
                transform.position = Vector3.Lerp(transform.position, direction, damp);
            }
        }

        if (!SnakeStopped)
        {
            transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            tailLength++;
            TailScript.AddCircle();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            tailLength--;
            TailScript.RemoveCircle();
        }
        deltaTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bonus"))
        {
            int bonusCount = other.gameObject.GetComponent<Bonus>().bonusCount;
            tailLength += bonusCount;
            for(int i = 0; i < bonusCount; i++)
            {
                TailScript.AddCircle();
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("CrashLeft"))
        {
            TouchedLeft = true;
        }
        if (other.gameObject.CompareTag("CrashRight"))
        {
            TouchedRight = true;
        }
        if (other.gameObject.CompareTag("EndTrigger"))
        {
            GameController.LevelCompleted();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CrashBox"))
        {
            var crashBox = other.gameObject.GetComponent<Box>();
            SnakeStopped = true;
            int crashCount = crashBox.crashCount;

            if (tailLength > 0)
            {
                if (deltaTimer < 0 && crashCount > 0)
                {
                    crashCount = crashBox.crashCount -= 1;
                    crashBox.ColorChange();
                    TailScript.RemoveCircle();
                    tailLength--;
                    deltaTimer = 0.05f;
                }
                else if (crashCount < 1)
                {
                    other.gameObject.SetActive(false);
                    other.gameObject.GetComponent<Box>().ResetCrashCount();
                    SnakeStopped = false;
                }
            }
            else
            {
                GameController.SnakeCrashed();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CrashBox"))
        {
            SnakeStopped = false;
        }
        if (other.gameObject.CompareTag("CrashLeft"))
        {
            TouchedLeft = false;
        }
        if (other.gameObject.CompareTag("CrashRight"))
        {
            TouchedRight = false;
        }
    }

    public void StartReturn()
    {
        TailScript.ClearTail();
        tailLength = 5;
        transform.position = new Vector3(0, transform.position.y, 0);
        for (int i = 0; i < tailLength; i++) TailScript.AddCircle();
        SnakeStopped = false;
    }
}
