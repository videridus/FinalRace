using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public float speed = 3f;      // скорость игрока

    public GameObject WinFirst;  // ссылка на объект окна с сообщением о проигрыше
    private bool allowMoveLeft = true;  // переменная для разрешения движения влево
    private bool allowMoveRight = true;  // переменная для разрешения движения вправо

    void Update()
    {
        float hor = 0f;

        if (Input.GetKey(KeyCode.RightArrow) && allowMoveLeft)
        {
            hor = -1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && allowMoveRight)
        {
            hor = 1f;
        }

        Vector3 dir = new Vector3(0, hor, 0);
        transform.Translate(dir.normalized * Time.deltaTime * speed* 55);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("WinFirst"); // загрузка сцены с сообщением о проигрыше
        }

        if (collision.gameObject.CompareTag("WallRight"))  // проверяем столкновение с объектом "wallright"
        {
            allowMoveLeft = false;  // запрещаем движение вправо
        }

        if (collision.gameObject.CompareTag("Wall"))  // проверяем столкновение с объектом "wall"
        {
            allowMoveRight = false;  // запрещаем движение влево
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallRight"))  // если объект "wallright" перестал сталкиваться с игроком
        {
            allowMoveLeft = true;  // разрешаем движение вправо
        }

        if (collision.gameObject.CompareTag("Wall"))  // если объект "wall" перестал сталкиваться с игроком
        {
            allowMoveRight = true;  // разрешаем движение влево
        }
    }
}
