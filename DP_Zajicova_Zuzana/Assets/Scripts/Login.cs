using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Login : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;
    public GameObject loginText;

    public Button logoutButton;


    ArrayList credentials;

    public TextMeshProUGUI displayPrihlasen;

    void Start()
    {
        loginButton.onClick.AddListener(login);
        logoutButton.onClick.AddListener(logout);

    }


    void login()
    {
        /*   bool isExists = false;

          credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/Resources/credentials/credentials.txt"));

           foreach (var i in credentials)
           {
               string line = i.ToString();

               if (i.ToString().Substring(0, i.ToString().IndexOf(":")).Equals(usernameInput.text) &&
                   i.ToString().Substring(i.ToString().IndexOf(":") + 1).Equals(passwordInput.text))
               {
                   isExists = true; break;
               }
           }
           if (isExists)
        */
        if (usernameInput.text == "vyucujici" && passwordInput.text == "123")
        {
            Debug.Log($"Logging in '{usernameInput.text}");


            usernameInput.gameObject.SetActive(false);
            passwordInput.gameObject.SetActive(false);
            loginButton.gameObject.SetActive(false);
            loginText.SetActive(false);

            logoutButton.gameObject.SetActive(true);
            displayPrihlasen.gameObject.SetActive(true);
            displayPrihlasen.text = "Pøihlášen uživatel: " + usernameInput.text;

            usernameInput.text = "";
            passwordInput.text = "";

        }
        else
        {
            Debug.Log("Incorrect credentials");
        }
    }


    void logout()
    {

        usernameInput.gameObject.SetActive(true);
        passwordInput.gameObject.SetActive(true);
        loginButton.gameObject.SetActive(true);
        loginText.SetActive(true);

        displayPrihlasen.gameObject.SetActive(false);
        logoutButton.gameObject.SetActive(false);

    }
}
