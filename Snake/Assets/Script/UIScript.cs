using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Malle.Util;
using UnityEngine.UI;

public class UIScript: MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI highscoreText;
    [SerializeField]
    private GameObject gameOverObj;
    [SerializeField]
    private GameObject newHighscoreObj;
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button restartButton;

    private void Awake()
    {
        restartButton.interactable = false;
    }

    private void Update()
    {
        scoreText.text = "Score: " + DataManager.Score;
        highscoreText.text = "Highscore: " + DataManager.Highscore;

        if (DataManager.IsPlayerDead)
        {
            gameOverObj.SetActive(true);

            if (DataManager.Score > DataManager.Highscore)
            {
                newHighscoreObj.SetActive(true);
                DataManager.Highscore = DataManager.Score;
            }
        }
        else
        {
            gameOverObj.SetActive(false);
            newHighscoreObj.SetActive(false);
        }
    }

    public void Starting()
    {
        DataManager.IsStarted = true;

        startButton.interactable = false;
        restartButton.interactable = true;
    }

    public void Restart()
    {
        World.Instance.Init();
        PlayerController.Instance.Init();

        DataManager.IsStarted = false;

        startButton.interactable = true;
        restartButton.interactable = false;

        DrawBoard.Draw(PlayerController.Instance.Map,PlayerController.Instance.Tiles,World.Instance.Tiles);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Exited the program");
    }
}
