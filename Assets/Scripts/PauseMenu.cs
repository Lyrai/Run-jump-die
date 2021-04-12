using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool _isOpen;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _isOpen = !_isOpen;
            Time.timeScale = _isOpen ? 0 : 1;
            pauseMenu.SetActive(_isOpen);
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
