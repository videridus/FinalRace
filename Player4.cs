using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerhard : MonoBehaviour
{
    public float speed = 3f;      // �������� ������

    public GameObject GameOver2;  // ������ �� ������ ���� � ���������� � ���������
    private bool allowMoveLeft = true;  // ���������� ��� ���������� �������� �����
    private bool allowMoveRight = true;  // ���������� ��� ���������� �������� ������

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
            SceneManager.LoadScene("GameOver2"); // �������� ����� � ���������� � ���������
        }

        if (collision.gameObject.CompareTag("WallLeft"))  // ��������� ������������ � �������� "wallleft"
        {
            allowMoveLeft = false;  // ��������� �������� �����
        }

        if (collision.gameObject.CompareTag("WallRight"))  // ��������� ������������ � �������� "wallright"
        {
            allowMoveRight = false;  // ��������� �������� ������
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallLeft"))  // ���� ������ "wallleft" �������� ������������ � �������
        {
            allowMoveLeft = true;  // ��������� �������� �����
        }

        if (collision.gameObject.CompareTag("WallRight"))  // ���� ������ "wallright" �������� ������������ � �������
        {
            allowMoveRight = true;  // ��������� �������� ������
        }
    }
}