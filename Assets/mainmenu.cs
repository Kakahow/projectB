using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject Panel;
   public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OpenRule()
    {
        if(Panel != null)
        {
            Panel.SetActive(true);
        }
    }
    public void CloseRule()
    {
        Panel.SetActive(false);
    }
}
