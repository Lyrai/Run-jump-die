using UnityEngine;

public class PortalsContainer : MonoBehaviour
{
    [SerializeField] private EnterPortal enter;
    [SerializeField] private ExitPortal exit;
    
    public void Enter()
    {
        enter.gameObject.SetActive(true);
    }

    public void Exit()
    {
        exit.gameObject.SetActive(true);
    }
}
