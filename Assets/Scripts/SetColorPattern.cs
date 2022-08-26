using UnityEngine;

public class SetColorPattern : MonoBehaviour
{
    public Color currentPattern1_1 = Color.white;
    public Color currentPattern1_2 = Color.white;

    public Color Pattern1_Low;
    public Color Pattern1_High;

    public Color Pattern2_Low;
    public Color Pattern2_High;
    
    public Color Pattern3_Low;
    public Color Pattern3_High;

    public Color SnakeColor;
    public Color BonusColor;
    public Color RoadColor;
    public Color SideColor;

    private void Awake()
    {
        ChangePattern();
    }
    public void ChangePattern()
    {
        int choose = Random.Range(1, 4);
        switch (choose)
        {
            case 1:
                currentPattern1_1 = Pattern1_Low;
                currentPattern1_2 = Pattern1_High;
                SnakeColor = Color.black;
                SideColor = SnakeColor;
                BonusColor = SnakeColor;
                RoadColor = new Color(0.95f, 0.75f, 0f, 1f);
                break;
            case 2:
                currentPattern1_1 = Pattern2_Low;
                currentPattern1_2 = Pattern2_High;
                RoadColor = Color.black;
                SideColor = new Color(0.88f, 0.75f, 0f, 1f);
                SnakeColor = Color.yellow;
                BonusColor = SnakeColor;
                break;
            case 3:
                currentPattern1_1 = Pattern3_Low;
                currentPattern1_2 = Pattern3_High;
                RoadColor = Color.black;
                SideColor = new Color(0.25f, 1f, 0.95f, 1f);
                SnakeColor = Color.yellow;
                BonusColor = SnakeColor;
                break;
        }

        transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material.color = RoadColor;
        transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().material.color = SideColor;
        transform.GetChild(0).GetChild(2).GetComponent<MeshRenderer>().material.color = SideColor;

    }

}
