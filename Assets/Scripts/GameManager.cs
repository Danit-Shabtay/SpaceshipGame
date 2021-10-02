using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform GameOverPanel;

    public float scoreFactor;
    public float Score;

    public Text GameOverScore;
    public Text LivesText;
    public Text ScoreText;

    public PlayerController ourPlayer;

    // Start is called before the first frame update
    void Start()
    {
        ourPlayer = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        LivesText.text = "x " + ourPlayer.Lives;
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.text = "x " + ourPlayer.Lives;

        if(ourPlayer.Lives == 0 && ourPlayer)
        {
            Destroy(ourPlayer);

            ShowGameOverPanel();
        }

        UpdateScore();
    }

    void ShowGameOverPanel()
    {
        Time.timeScale = 0;
        GameOverScore.text += Score.ToString("F0");
        GameOverPanel.gameObject.SetActive(enabled);
    }

    void UpdateScore()
    {
        Score += Time.deltaTime * scoreFactor;
        ScoreText.text = "Score : " + Score.ToString("F0");
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
