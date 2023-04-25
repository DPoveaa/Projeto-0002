using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentSceneIndex;

    #region Consultation scripts
    public Player player;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        #region World 1
        if (currentSceneIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.R) || player.dead)
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex);
            }





        }
        #endregion

    }













    #region Main Menu
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //Work with "World 1" and SceneManager.GetActiveScene().buildIndex + 1
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
