using System;
using Doozy.Runtime.UIManager.Components;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuView : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Game");
        OnClickSFX();
    }

    public void Quit()
    {
        Application.Quit();
        OnClickSFX();
    }

    void OnClickSFX()
    {
        AudioManager.Instance.PlaySFX("OnClick");
    }
}
