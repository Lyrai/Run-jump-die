using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortal : PortalBase
{
    private void OnTriggerExit2D(Collider2D other)
    {
        Player.player.SetInvulnerability(false);
        Player.player.EndCooldown();
        gameObject.SetActive(false);
    }
}
