using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject creditUI;
    //[SerializeField] private GameObject deadUI;

    private CharacterControl characterControl;
    private bool characterDead;
    public bool CharacterDead => characterDead;

    private void Start()
    {
        
    }

    private void Update()
    {
        //if (characterControl == null)
        //{
        //    if (characterDead == false)
        //    {
        //        GameObject character = GameObject.FindGameObjectWithTag("Player");
        //        characterControl = character.GetComponent<CharacterControl>();
        //    }
        //}

        //if (characterControl.health <= 0)
        //{
        //    characterDead = true;
        //    deadUI.SetActive(true);
        //}
    }

    public void gotoLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

    public void gotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void OpenCredits()
    {
        creditUI.SetActive(true);
    }

    public void CloseCredits()
    {
        creditUI.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
