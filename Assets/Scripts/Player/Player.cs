using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action Died;
    public static Player player;
    [SerializeField] private PlayerControls controls;
    private bool _isInvulnerable;
    
    private void Awake()
    {
        player = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle") && _isInvulnerable == false)
            Died?.Invoke();
    }

    public void Exit()
    {
        Debug.Log("Player exit");
        controls.Exit();
    }

    public void EndCooldown()
    {
        controls.EndCooldown();
    }

    public void SetInvulnerability(bool value)
    {
        _isInvulnerable = value;
    }
}
