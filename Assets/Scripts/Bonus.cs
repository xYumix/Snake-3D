using UnityEngine;
using TMPro;

public class Bonus : MonoBehaviour
{
    public int bonusCount; //какой-то коммент
    private TextMeshProUGUI bonusText;

    void Start()
    {
        bonusText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        bonusText.text = bonusCount.ToString();
    }
}
