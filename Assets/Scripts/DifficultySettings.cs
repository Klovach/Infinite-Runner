using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Start and Stop Menu 
public class DifficultySettings : MonoBehaviour
{
    public float speed;

    public void ChooseDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "Easy":
                speed = 0.5f; break;
            case "Normal":
                speed = 1f; break;
            case "Hard":
                speed = 2f; break;
            case "Impossible":
                speed = 4f; break;
        }

    }
}
   