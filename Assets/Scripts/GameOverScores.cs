using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        float score = PlayerPrefs.GetFloat("Score", 0);
        scoreText.text = "Score: " + score.ToString();
    }
}