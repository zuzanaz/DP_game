using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{

    public GameObject panel;
    public void Start()
    {
        panel.SetActive(false);
    }
    public void OnMouseOver()
    {
        panel.SetActive(true);
    }
    public void OnMouseExit()
    {
        panel.SetActive(false);
    }
}
