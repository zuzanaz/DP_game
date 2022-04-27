using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    public bool mouseOverButton;
    public static MouseOver mouseOver;

    private void Start()
    {
        mouseOver = this;
        //  mouseOverButton=false;
    }
    public void OnMouseOver()
    {

        mouseOverButton = true;
        // Debug.Log(mouseOverButton);

    }
    public void OnMouseExit()
    {
        mouseOverButton = false;
        //   Debug.Log(mouseOverButton);
    }
}
