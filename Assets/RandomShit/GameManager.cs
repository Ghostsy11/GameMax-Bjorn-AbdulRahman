using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int index;
    public void PlayScene()
    {
        SceneManager.LoadScene(index);

    }
    public void Settings()
    {
        Debug.Log("Event Setting is working");
    }

    public void Quit()
    {
        Debug.Log("Quiting");
        Application.Quit();

    }

    public void GameOver()
    {

    }


}
