using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject YToggle;

    private Toggle invertToggleElement;
    private bool isInverted = false;

    void Start()
    {
        invertToggleElement = YToggle.GetComponent<Toggle>();
        invertToggleElement.isOn = (PlayerPrefs.GetInt("isInverted", 0) == 1 ? true : false);
    }

    public void Back()
    {
        if (PlayerPrefs.HasKey("lastlevel"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("lastlevel"));
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void SetYInvert()
    {
        isInverted = invertToggleElement.isOn;
    }

    public void Apply()
    {
        PlayerPrefs.SetInt("isInverted", (isInverted ? 1 : 0));
    }
}
