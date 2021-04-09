using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private enum Levels
    {
        UpLevel,
        MidLevel,
        DownLevel
    }
    
    private KeyCode _upKey = KeyCode.W;
    private KeyCode _downKey = KeyCode.S;
    private Levels _currentLevel = Levels.UpLevel;

    private void Start()
    {
        AssignKeys();
    }

    private void Update()
    {
        if(Input.GetKeyDown(_upKey) && Input.GetKeyDown(_downKey))
            Jump(_currentLevel);
        else if (Input.GetKeyDown(_upKey) && _currentLevel != Levels.UpLevel)
            Jump(_currentLevel - 1);
        else if (Input.GetKeyDown(_downKey) && _currentLevel != Levels.DownLevel)
            Jump(_currentLevel + 1);
    }

    private void AssignKeys()
    {
        //TODO Назначить кнопки управления
    }

    private void Jump(Levels level)
    {
        Debug.Log($"Level: {level}");
        _currentLevel = level;
        //TODO Логика прыжка
    }
}
