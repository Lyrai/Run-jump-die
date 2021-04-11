using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Dropdown _dropdown;
    private void Start()
    {
        
    }
    public void SetСontrols() 
    {
        PlayerPrefs.SetInt("Controls",_dropdown.value);
        Debug.Log(_dropdown.value);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
