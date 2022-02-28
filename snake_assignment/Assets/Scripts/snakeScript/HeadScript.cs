using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{
    private int _gridPosX;
    private int _gridPosY;

    private float _tick;
    private float _tickAdd;
    private float _tickGoTo;

    private Direction _localDirection;
    private Direction _currentDirection;

    private void Awake()
    {
        _gridPosX = GameManager.gridMaxX / 2;
        _gridPosY = GameManager.gridMaxY / 2;

        _tick = 0;
        _tickAdd = 1;
        _tickGoTo = 256;

        _currentDirection = _localDirection = Direction.up;
    }

    void Update()
    {
        //<Start> make movement code nicer
        if (Input.GetKeyDown(KeyCode.UpArrow) && _currentDirection != Direction.down)
        {
            _localDirection = Direction.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && _currentDirection != Direction.up)
        {
            _localDirection = Direction.down;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && _currentDirection != Direction.left)
        {
            _localDirection = Direction.right;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && _currentDirection != Direction.right)
        {
            _localDirection = Direction.left;
        }
        //<End>

        if (_tick >= _tickGoTo)
        {
            MoveHeadTo();
            _tick = 0;
        }
        else
        {
            _tick += _tickAdd;
        }
    }

    public void MoveHeadTo()
    {
        switch (_localDirection)
        {
            case Direction.up:
                _gridPosY++;
                gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                gameObject.transform.position = new Vector3(1f + _gridPosX * 2.5f, 1f, 1f + _gridPosY * 2.5f);
                break;
            case Direction.left:
                _gridPosX--; 
                gameObject.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
                gameObject.transform.position = new Vector3(2f + _gridPosX * 2.5f, 1f, 1f + _gridPosY * 2.5f);
                break;
            case Direction.down:
                _gridPosY--;
                gameObject.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                gameObject.transform.position = new Vector3(2f + _gridPosX * 2.5f, 1f, 2f + _gridPosY * 2.5f);
                break;
            case Direction.right:
                _gridPosX++;
                gameObject.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                gameObject.transform.position = new Vector3(1f + _gridPosX * 2.5f, 1f, 2f + _gridPosY * 2.5f);
                break;
            default:
                Debug.Log("Direction never set");
                break;
        }

        _currentDirection = _localDirection;
    }
}
