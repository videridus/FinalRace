using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerhard : MonoBehaviour
{
    public float speed = 3f;      // скорость игрока

    public GameObject GameOver2;  // ссылка на объект окна с сообщением о проигрыше
    private bool allowMoveLeft = true;  // переменная для разрешения движения влево
    private bool allowMoveRight = true;  // переменная для разрешения движения вправо

    void Update()
    {
        float hor = 0f;

        if (Input.GetKey(KeyCode.A) && allowMoveLeft)
        {
            hor = -1f;
        }
        else if (Input.GetKey(KeyCode.D) && allowMoveRight)
        {
            hor = 1f;
        }

        Vector3 dir = new Vector3(hor, 0, 0);
        transform.Translate(dir.normalized * Time.deltaTime * speed * 35);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver2"); // загрузка сцены с сообщением о проигрыше
        }

        if (collision.gameObject.CompareTag("WallLeft"))  // проверяем столкновение с объектом "wallleft"
        {
            allowMoveLeft = false;  // запрещаем движение влево
        }

        if (collision.gameObject.CompareTag("WallRight"))  // проверяем столкновение с объектом "wallright"
        {
            allowMoveRight = false;  // запрещаем движение вправо
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallLeft"))  // если объект "wallleft" перестал сталкиваться с игроком
        {
            allowMoveLeft = true;  // разрешаем движение влево
        }

        if (collision.gameObject.CompareTag("WallRight"))  // если объект "wallright" перестал сталкиваться с игроком
        {
            allowMoveRight = true;  // разрешаем движение вправо
        }
    }
}