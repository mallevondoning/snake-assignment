using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyScript : MonoBehaviour
{
    private int gridPosX;
    private int gridPosY;
    private int _lengthPos;

    private void Awake()
    {
        for (int i = 0; i < GameManager.snakeBodyPartList.Count; i++)
        {
            if (GameManager.snakeBodyPartList[i] == this)
            {
                _lengthPos = i;
                break;
            }
        }
    }

    void Update()
    {
        if (_lengthPos == 0)
        {

        }
        else
        {

        }
    }
}
