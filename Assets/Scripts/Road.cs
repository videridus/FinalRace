using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

public class moveroad : MonoBehaviour
{

    int f;
    float score = 0, speed = -10f, data;

    void Start()
    {
        // Загружаем рекорд из сохраненных данных
        StreamReader scoredata = new StreamReader(Application.persistentDataPath + "/score.gd");
        data = float.Parse(scoredata.ReadLine());
        scoredata.Close();
    }

    void Update()
    {
        transform.Translate(new Vector3(0f, speed, 0f));
        score = score + (speed * -2);
        if (transform.position.y < -1800f)
        {
            transform.position = new Vector3(0f, 33.4f, 0f);
            if (score > data)
            {
                // Обновляем рекорд
                StreamWriter scoredata = new StreamWriter(Application.persistentDataPath + "/score.gd");
                scoredata.WriteLine(score);
                scoredata.Close();
            }
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height * 0.05f), "Score: " + score);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            // Сохраняем значение "score" в PlayerPrefs
            PlayerPrefs.SetFloat("Score", score);
            // Переходим на новую сцену "GameOver"
            SceneManager.LoadScene("GameOver");
        }
    }
}