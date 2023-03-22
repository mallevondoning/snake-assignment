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
        Color.HSVToRGB(H, 1f, 1f);
    }
}
