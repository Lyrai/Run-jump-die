using System;
using UnityEngine;

public class EnterPortal : PortalBase
{
    [SerializeField] private AudioSource sound;
    
    protected override void OnEnable()
    {
        base.OnEnable();
        sound.Play();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Portal trigger enter");
            Player.player.Exit();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
            Player.player.SetInvulnerability(true);
    }
}
