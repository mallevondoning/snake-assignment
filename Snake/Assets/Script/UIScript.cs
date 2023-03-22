using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Malle.Util;

public class UIScript: MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ScoreText;

    private void Update()
    {
        ScoreText.text = "Score: " + DataManager.Score;
    }

    public void Restart()
    {
        World.Instance.Init();
        PlayerController.Instance.Init();

        DrawBoard.Draw(PlayerController.Instance.Map,PlayerController.Instance.Tiles,World.Instance.Tiles);
    }
}
