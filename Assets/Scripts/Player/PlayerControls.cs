using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private bool _isCooldown;
    private int _deltaLevel;

    private void Start()
    {
        AssignKeys();
        _player = Player.player.transform;
    }

    private void Update()
    {
        if (_isCooldown)
            return;
        
        if(Input.GetKeyDown(_upKey) && Input.GetKeyDown(_downKey))
        {
            SwitchLvl(_currentLevel);
        }
        else if (Input.GetKeyDown(_upKey) && _currentLevel != Levels.UpLevel)
        {
            Debug.Log("Controls enter");
            _isCooldown = true;
            portals[(int)_currentLevel].Enter();
            _deltaLevel = -1;
        }
        else if (Input.GetKeyDown(_downKey) && _currentLevel != Levels.DownLevel)
        {
            Debug.Log("Controls enter");
            _isCooldown = true;
            portals[(int)_currentLevel].Enter();
            _deltaLevel = 1;
        }
        
    }
    
    public void Exit()
    {
        Debug.Log("Controls exit");
        SwitchLvl(_currentLevel + _deltaLevel);
        portals[(int)_currentLevel].Exit();
    }

    public void EndCooldown()
    {
        _isCooldown = false;
    }

    private void AssignKeys()
    {
        //TODO Назначить кнопки управления
    }

    private void SwitchLvl(Levels level)
    {
        Debug.Log("Switch level");
        _currentLevel = level;
        _player.position = _lvls[(int)_currentLevel].transform.position;
    }
}
