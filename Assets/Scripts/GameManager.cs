using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float scoreFactor;
    public float Score;

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

        if(ourPlayer.Lives == 0)
        {
            Destroy(ourPlayer);
        }

        UpdateScore();
    }

    void UpdateScore()
    {
        Score += Time.deltaTime * scoreFactor;
        ScoreText.text = "Score : " + Score.ToString("F0");
    }
}
