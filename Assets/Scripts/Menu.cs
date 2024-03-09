using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Start and Stop Menu 
public class Menu : MonoBehaviour
{
       public float speed;
       public GameObject Panel;
       bool isMenuActive;
       bool isDifficultySettingsActive;
       bool isCreditsActive; 


    public void Start()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }

    public void StartGame()
        {
            SceneManager.LoadScene("Infinite Runner");
        }

        public void TogglePanel()
        {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
        }
     
        public void activeButtons()
    {
        if (!isMenuActive)
        {

        }

    }


        public void ExitGame()
        {
            // Quit the application
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    
}
