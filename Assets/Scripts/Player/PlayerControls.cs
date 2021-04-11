using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private PortalsContainer[] portals;
    [SerializeField] GameObject[] _lvls;
    private enum Levels
    {
        UpLevel,
        MidLevel,
        DownLevel
    }

    private KeyCode _upKey = KeyCode.W;
    private KeyCode _downKey = KeyCode.S;
    private Levels _currentLevel = Levels.UpLevel; 
    private Transform _player;

    private void Start()
    {
        AssignKeys();
        _player = Player.player.transform;
    }

    private void Update()
    {
        if(Input.GetKeyDown(_upKey) && Input.GetKeyDown(_downKey))
        {
            SwitchLvl(_currentLevel);
        }
        else if (Input.GetKeyDown(_upKey) && _currentLevel != Levels.UpLevel)
        {
            //portals[(int)_currentLevel].Enter();
            SwitchLvl(_currentLevel - 1);
        }
        else if (Input.GetKeyDown(_downKey) && _currentLevel != Levels.DownLevel)
        {
            //portals[(int)_currentLevel].Enter();
            SwitchLvl(_currentLevel + 1);
        }
        
    }

    private void AssignKeys()
    {
        //TODO Назначить кнопки управления
    }

    private void SwitchLvl(Levels level)
    {
        Debug.Log($"Level: {level}");
        _currentLevel = level;
        _player.position = _lvls[(int)_currentLevel].transform.position;
        Debug.Log(_lvls[(int)_currentLevel].transform.position.y);
        Debug.Log((int)_currentLevel);
    }

    private IEnumerator Exit()
    {
        throw new NotImplementedException();
    }
}
