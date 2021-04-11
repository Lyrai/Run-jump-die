using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortal : PortalBase
{
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Portal trigger exit");
        Player.player.EndCooldown();
        gameObject.SetActive(false);
    }
}
