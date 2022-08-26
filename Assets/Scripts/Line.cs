using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public int pattern = -1;
    
    void Awake()
    {
        if(pattern==-1)
        pattern = Random.Range(0, 3);
        SetCrashCounts(pattern);
    }

    void SetCrashCounts(int pattern)
    {
        List<GameObject> boxes = new List<GameObject>();
        foreach (Transform child in transform)
        {
            boxes.Add(child.GetChild(0).gameObject);
        }
        switch (pattern)
        {
            case 0://3 ящика от 1 до 4, 2 ящика от 3 до 9
                for(int i = 0; i < 3; i++)
                {
                    int selected = Random.Range(0, boxes.Count);
                    boxes[selected].GetComponent<Box>().crashCount = Random.Range(1, 4);
                    boxes.RemoveAt(selected);
                }
                for (int i = 0; i < 2; i++)
                {
                    int selected = Random.Range(0, boxes.Count);
                    boxes[selected].GetComponent<Box>().crashCount = Random.Range(3, 9);
                    boxes.RemoveAt(selected);
                }
                break;
            case 1: //2 ящика от 1 до 5, 2 ящика от 5 до 12, 1 ящик от 12 до 30
                for (int i = 0; i < 2; i++)
                {
                    int selected = Random.Range(0, boxes.Count);
                    boxes[selected].GetComponent<Box>().crashCount = Random.Range(1, 5);
                    boxes.RemoveAt(selected);
                }
                for (int i = 0; i < 2; i++)
                {
                    int selected = Random.Range(0, boxes.Count);
                    boxes[selected].GetComponent<Box>().crashCount = Random.Range(5, 11);
                    boxes.RemoveAt(selected);
                }
                {
                    int selected = Random.Range(0, boxes.Count);
                    boxes[selected].GetComponent<Box>().crashCount = Random.Range(5, 30);
                    boxes.RemoveAt(selected);
                }
                break;
            case 2: // 2 ящика от 8 до 15, 2 ящика от 15 до 50, 1 ящик от 1 до 7
                for (int i = 0; i < 2; i++)
                {
                    int selected = Random.Range(0, boxes.Count);
                    boxes[selected].GetComponent<Box>().crashCount = Random.Range(8, 15);
                    boxes.RemoveAt(selected);
                }
                for (int i = 0; i < 2; i++)
                {
                    int selected = Random.Range(0, boxes.Count);
                    boxes[selected].GetComponent<Box>().crashCount = Random.Range(15, 50);
                    boxes.RemoveAt(selected);
                }
                {
                    int selected = Random.Range(0, boxes.Count);
                    boxes[selected].GetComponent<Box>().crashCount = Random.Range(1, 7);
                    boxes.RemoveAt(selected);
                }
                break;
        }
    }
}
