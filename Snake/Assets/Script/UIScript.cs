using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Malle.Util;

public class UIScript: MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    [SerializeField]
    private GameObject GameOverObj;
    [SerializeField]
    private GameObject HighscoreObj;

    private void Update()
    {
        ScoreText.text = "Score: " + DataManager.Score;

        if (DataManager.IsPlayerDead)
            GameOverObj.SetActive(true);
        else
            GameOverObj.SetActive(false);
    }

    public void Starting()
    {
        DataManager.IsStarted = true;
    }

    public void Restart()
    {
        World.Instance.Init();
        PlayerController.Instance.Init();

        DrawBoard.Draw(PlayerController.Instance.Map,PlayerController.Instance.Tiles,World.Instance.Tiles);
    }
}
