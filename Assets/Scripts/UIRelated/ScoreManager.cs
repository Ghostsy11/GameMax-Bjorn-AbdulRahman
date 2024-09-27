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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;


    }

    void Update()
    {
        test();
    }

    public void test()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            _Score++;
            score.text = _Score.ToString();
            diffeclty.text = _diffeclty.ToString();

            if (_Score >= 3)
            {
                _diffeclty++;
            }
            else if (_Score >= 5)
            {
                _diffeclty++;
            }
            else if (_Score >= 7)
            {
                _diffeclty++;
            }
        }
    }

    public void ScoreAndDifficltyHandler()
    {
        _Score++;

        score.text = _Score.ToString();
        diffeclty.text = _diffeclty.ToString();



        if (_Score >= 3)
        {
            _diffeclty++;
        }
        else if (_Score >= 5)
        {
            _diffeclty++;
        }
        else if (_Score >= 7)
        {
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
        SceneManager.LoadScene(3);

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
