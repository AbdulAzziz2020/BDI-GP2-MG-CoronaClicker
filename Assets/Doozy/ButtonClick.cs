using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using Doozy;
using Doozy.Runtime.UIManager.Containers;

public class ButtonClick : MonoBehaviour
{
    public bool isHide = false;

    public UIContainer simpleContainer;

    public void ShowAndHide()
    {
        isHide = !isHide;
        
        if(isHide) simpleContainer.Show();
        else simpleContainer.Hide();
    }
    
}
