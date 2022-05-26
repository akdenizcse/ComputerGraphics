using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject Survival;
    public GameObject Creative;
    public GameObject Menu;
    public int isMenuOpen;

    public void SurvivalButton() 
    {
        Survival.SetActive(true);
        Creative.SetActive(false);
        Menu.SetActive(false);
        isMenuOpen = 1;
    }
    public void CreativeButton()
    {
        Creative.SetActive(true);
        Survival.SetActive(false);
        Menu.SetActive(false);
        isMenuOpen = 1;
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    void Start()
    {
        Survival.SetActive(false);
        Creative.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) //If pressed ESC
        {
            if (isMenuOpen == 1)
            {
                isMenuOpen = 0;
            }
            else
            {
                isMenuOpen = 1;
            }
            StartCoroutine(MenuChange());
        }
    }
    IEnumerator MenuChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (isMenuOpen == 0)
        {
            Survival.SetActive(false);
            Creative.SetActive(false);
            Menu.SetActive(true);
        }
        if (isMenuOpen == 1)
        {
            
        }
    }
}
