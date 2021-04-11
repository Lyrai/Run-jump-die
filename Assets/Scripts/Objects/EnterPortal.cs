using UnityEngine;

public class EnterPortal : PortalBase
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Portal trigger enter");
            Player.player.Exit();
            gameObject.SetActive(false);
        }
    }
}
