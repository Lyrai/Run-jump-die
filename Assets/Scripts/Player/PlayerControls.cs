using System;
using System.Collections;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private PortalsContainer[] portals;
    [SerializeField] GameObject[] _lvls;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private PlayerAnimator animator;
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
    private bool _isCooldown;
    private int _deltaLevel;
    private bool _isGrounded;

    private void Start()
    {
        AssignKeys();
        _player = Player.player.transform;
    }

    private void Update()
    {
        if (_isCooldown)
            return;
        
        
        if (Input.GetKeyDown(_upKey))
        {
            StartCoroutine(AwaitInput(_downKey, () => 
                {  
                    if(_currentLevel != Levels.UpLevel && _isGrounded)
                    {
                        _isCooldown = true;
                        portals[(int) _currentLevel].Enter();
                        _deltaLevel = -1;
                    }
                }));
        }
        else if (Input.GetKeyDown(_downKey))
        {
            StartCoroutine(AwaitInput(_upKey, () =>
            {
                if(_currentLevel != Levels.DownLevel && _isGrounded)
                {
                    _isCooldown = true;
                    portals[(int) _currentLevel].Enter();
                    _deltaLevel = 1;
                }
            }));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _isGrounded = true;
        animator.SetJumpState(false);
    }

    public void Exit()
    {
        SwitchLvl(_currentLevel + _deltaLevel);
        portals[(int)_currentLevel].Exit();
    }

    public void EndCooldown()
    {
        _isCooldown = false;
    }

    private void AssignKeys()
    {
        int c = PlayerPrefs.GetInt("Controls");

        switch (c)
        {
            case 0:
                break;
            case 1:
                _upKey = KeyCode.A;
                _downKey = KeyCode.D;
                break;
            case 2:
                _upKey = KeyCode.UpArrow;
                _downKey = KeyCode.DownArrow;
                break;
            case 3:
                _upKey = KeyCode.LeftArrow;
                _downKey = KeyCode.RightArrow;
                break;
        }
    }

    private void SwitchLvl(Levels level)
    {
        _currentLevel = level;
        _player.position = _lvls[(int)_currentLevel].transform.position;
    }

    private void Jump()
    {
        _isGrounded = false;
        animator.SetJumpState(true);
        
        rigidbody.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
    }

    private IEnumerator AwaitInput(KeyCode code, Action action)
    {
        float t = 0;
        while (t < 0.1f)
        {
            if (Input.GetKey(code))
            {
                if (_isGrounded)
                    Jump();
                yield break;
            }
            
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        action.Invoke();
    }
}
