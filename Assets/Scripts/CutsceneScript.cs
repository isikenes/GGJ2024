using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
    private void OnEnable()
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        
    }
}
