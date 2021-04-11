using UnityEngine;

public class PortalsContainer : MonoBehaviour
{
    [SerializeField] private EnterPortal enter;
    [SerializeField] private ExitPortal exit;
    
    public void Enter()
    {
        Debug.Log("Container enter");
        enter.gameObject.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("Container exit");
        exit.gameObject.SetActive(true);
    }
}