using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject[] Levels;
    public static bool GamePaused=false;
    public int currentLevel;
    public MoveHead Snake;
    public GL GL;
    public UIController UIController;

    private void Awake()
    {
        currentLevel = PlayerPrefs.GetInt("Level");
        HideLevels();
    }

    void Update()
    {
        if (GamePaused)
        {
            Time.timeScale=0;
        }
        else
        {
            Time.timeScale=1;
        }
    }

    void HideLevels()
    {
        foreach (GameObject level in Levels)
        {
            level.SetActive(false);
        }
    }
    public void StartLevel(int selected)
    {
        HideLevels();
        Levels[selected].SetActive(true);
        UIController.LevelPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (selected+1).ToString();
        foreach (Transform child in Levels[selected].transform)
        {
            if (child.childCount > 0)
            {
                foreach (Transform child2 in child.transform)
                {
                    child2.GetChild(0).gameObject.SetActive(true);
                }
            }
        }
        GamePaused = false;
        Snake.StartReturn();
        GL.CreateUtility();
    }

    public void StopLevel()
    {
        GL.DeleteUtility();
        Levels[currentLevel].SetActive(false);
    }

    public void LevelCompleted()
    {
        var nextLevel = ++currentLevel;
        if(nextLevel >= Levels.Length)
        {
            PlayerPrefs.SetInt("Level", Levels.Length-1);
            currentLevel = Levels.Length - 1;
        }
        else
        {
            PlayerPrefs.SetInt("Level", currentLevel);
        }
        UIController.CompletedMenu.SetActive(true);
    }

    public void SnakeCrashed()
    {
        UIController.RestartPanel.SetActive(true);
        StopLevel();
    }
}
