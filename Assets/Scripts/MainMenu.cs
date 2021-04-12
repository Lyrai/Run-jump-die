using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Dropdown dropdown;
    [SerializeField] private Text[] texts;
    private string[] _controls = new string[3];
    private string[] _controlsTexts = {" - Go up", " - Go down", " - Jump"};

    private void Start()
    {
        if(PlayerPrefs.HasKey("Controls"))
            dropdown.value = PlayerPrefs.GetInt("Controls");
    }
    
    public void SetСontrols() 
    {
        Debug.Log("SetControls");
        PlayerPrefs.SetInt("Controls",dropdown.value);
        switch (dropdown.value)
        {
            case 0:
                _controls[0] = "W";
                _controls[1] = "S";
                break;
            case 1:
                _controls[0] = "A";
                _controls[1] = "D";
                break;
            case 2:
                _controls[0] = "Up arrow";
                _controls[1] = "Down arrow";
                break;
            case 3:
                _controls[0] = "Left arrow";
                _controls[1] = "Right arrow";
                break;
        }

        _controls[2] = $"{_controls[0]} + {_controls[1]}";

        for (int i = 0; i < 3; i++)
            texts[i].text = $"{_controls[i]}{_controlsTexts[i]}";
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
