using UnityEngine;
using TMPro;

public class Box : MonoBehaviour
{
    public int crashCount;
    int crashConst;
    private TextMeshProUGUI crashText;
    Color currentColor = Color.white;
    public Color LowColor;
    public Color HighColor;
    float CVR;
    float CVG;
    float CVB;

    void Start()
    {
        crashConst = crashCount;
        LowColor = Camera.main.GetComponent<SetColorPattern>().currentPattern1_1;
        HighColor = Camera.main.GetComponent<SetColorPattern>().currentPattern1_2;
        SetColor();
        crashText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        crashText.text = crashCount.ToString();
    }

    void Update()
    {
        crashText.text = crashCount.ToString();
        GetComponent<MeshRenderer>().material.color = currentColor;
    }

    void SetColor()
    {
        CVR = (HighColor.r - LowColor.r) / 50;
        CVG = (HighColor.g - LowColor.g) / 50;
        CVB = (HighColor.b - LowColor.b) / 50;
        currentColor = new Color(LowColor.r + (CVR*crashCount), LowColor.g + (CVG * crashCount), LowColor.b + (CVB * crashCount), 1f);
    }

    public void ColorChange()
    {
        currentColor = new Color(currentColor.r - CVR, currentColor.g - CVG, currentColor.b - CVB, 1f);
    }

    public void ResetCrashCount()
    {
        crashCount = crashConst;
    }

}
