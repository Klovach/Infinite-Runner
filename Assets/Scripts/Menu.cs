using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Start and Stop Menu 
public class Menu : MonoBehaviour
{
   
        public void StartGame()
        {
            SceneManager.LoadScene("Infinite Runner");
        }

        public void ExitGame()
        {
            // Quit the application
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    
}
