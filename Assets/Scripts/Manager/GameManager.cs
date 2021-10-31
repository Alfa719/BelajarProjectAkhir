using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TimeManager TimeManager;
    public Text conditionText;
    public GameObject gameOver, condition;
    void Start()
    {
        gameOver.SetActive(false);
        condition.SetActive(false);
    }
    private void Update()
    {
        RestartGame();
    }
    public void GameOver(bool win)
    {
        gameOver.SetActive(true);
        condition.SetActive(true);
        if (win)
        {
            conditionText.text = "You Win !!!";
        }else
        {
            conditionText.text = "You Lose";
            Time.timeScale = 0;
        }
    }
    void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Restart");
            Time.timeScale = 1;
            SceneManager.LoadScene("Gameplay");
        }
    }
}
