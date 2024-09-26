using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    [HideInInspector] public int _Score;
    [HideInInspector] public int _diffeclty;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI diffeclty;

    private void Awake()
    {
        score.text = _Score.ToString();
        diffeclty.text = _diffeclty.ToString();
    }

    void Update()
    {
        ScoreAndDifficltyHandler();
    }


    public void ScoreAndDifficltyHandler()
    {
        score.text = _Score.ToString();
        diffeclty.text = _diffeclty.ToString();
        if (Input.GetKeyDown(KeyCode.O))
        {
            _Score++;
            _diffeclty++;
        }
    }


    public void ResetScore()
    {
        _Score = 0;
        _diffeclty = 0;
    }

    public void LoadGameOverScreen()
    {
        SceneManager.LoadScene(1);

    }

    public void ResetScene()
    {
        Debug.Log("workign");
        SceneManager.LoadScene(2);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);

    }



}
