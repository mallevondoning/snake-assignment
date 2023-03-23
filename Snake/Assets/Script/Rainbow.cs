using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rainbow : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highscoreText;
    [SerializeField]
    private float scrollTimeInSec = 1.5f;

    private float H;

    private void Update()
    {
        H += Time.deltaTime;

        highscoreText.color = Color.HSVToRGB(H / scrollTimeInSec % 1, 1f, 1f);
    }
}
