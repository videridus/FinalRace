using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public float speed = 3f;      // �������� ������

    public GameObject WinFirst;  // ������ �� ������ ���� � ���������� � ���������
    private bool allowMoveLeft = true;  // ���������� ��� ���������� �������� �����
    private bool allowMoveRight = true;  // ���������� ��� ���������� �������� ������

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
            SceneManager.LoadScene("WinFirst"); // �������� ����� � ���������� � ���������
        }

        if (collision.gameObject.CompareTag("WallRight"))  // ��������� ������������ � �������� "wallright"
        {
            allowMoveLeft = false;  // ��������� �������� ������
        }

        if (collision.gameObject.CompareTag("Wall"))  // ��������� ������������ � �������� "wall"
        {
            allowMoveRight = false;  // ��������� �������� �����
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallRight"))  // ���� ������ "wallright" �������� ������������ � �������
        {
            allowMoveLeft = true;  // ��������� �������� ������
        }

        if (collision.gameObject.CompareTag("Wall"))  // ���� ������ "wall" �������� ������������ � �������
        {
            allowMoveRight = true;  // ��������� �������� �����
        }
    }
}
