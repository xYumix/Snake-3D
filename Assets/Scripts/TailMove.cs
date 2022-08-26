using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TailMove : MonoBehaviour
{
    GameObject SnakeHead;
    public GameObject TailPrefab;
    float TailElementSize = 0;
    List<GameObject> Tail = new List<GameObject>();
    List<Vector3> positions = new List<Vector3>();
    float headSpeed = 10f;

    int TailCount = 0;
    private TextMeshProUGUI TailCountText;
    void Start()
    {
        ClearTail();
        SnakeHead = gameObject;
        TailElementSize = 0.5f;
        headSpeed = SnakeHead.GetComponent<MoveHead>().forwardSpeed;
        TailCountText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(Tail.Count > 0)
        {
            UpdateTail();
        }
        TailCountText.text = TailCount.ToString();
    }


    void UpdateTail()
    {
        float distance = ((Vector3)SnakeHead.transform.position - Tail[0].transform.position).magnitude;
        
        if (distance > TailElementSize)
        {   positions.Clear();
            positions.Add(SnakeHead.transform.position);
            foreach (GameObject element in Tail)
            {
                positions.Add(element.transform.position);
            }

            for (int i = 0; i < Tail.Count; i++)
            {
                    if (Tail[i].GetComponent<TouchingCrash>().TouchedLeft || Tail[i].GetComponent<TouchingCrash>().TouchedRight)
                    {
                        Tail[i].transform.position += Vector3.forward * Time.deltaTime * headSpeed;
                    }
                    else
                    {
                        Tail[i].transform.position = Vector3.Lerp(positions[i + 1], positions[i], distance / TailElementSize * Time.deltaTime * (headSpeed + 5f));
                    }
            }
           
        }
        
    }

    public void AddCircle()
    {
        GameObject TailElement;
        if (Tail.Count > 0)
        {
            TailElement = Instantiate(TailPrefab, Tail[Tail.Count-1].transform.position, Quaternion.identity);
        }
        else
        {
            TailElement = Instantiate(TailPrefab, SnakeHead.transform.position, Quaternion.identity);
        }
        Tail.Add(TailElement);
        TailElement.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().material.color;
        TailCount++;
    }

    public void RemoveCircle()
    {
        Tail[Tail.Count - 1].GetComponent<TouchingCrash>().Destruction = true;
        Tail.RemoveAt(Tail.Count - 1);
        TailCount--;
    }

    public void ClearTail()
    {
        if(Tail.Count > 0)
        {
            foreach (GameObject TailElement in Tail)
            {
                Destroy(TailElement.gameObject);
            }
        }
        TailCount = 0;
        Tail.Clear();
        positions.Clear();
    }
}
