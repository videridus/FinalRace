using UnityEngine;
using System.Collections;

public class SpawnCars1 : MonoBehaviour
{
    public GameObject[] cars;
    private float[] positions = { 46.1f, 151.2f, 258.2f, -56.1f, -157.2f, -258.7f };
    private float lastSpawnedPosition;
    private float cooldownTime = 1.0f; // Время задержки в секундах

    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            float newPosition = GetNewPosition();
            Instantiate(
                cars[Random.Range(0, cars.Length)],
                new Vector3(newPosition, 280f, 0),
                Quaternion.Euler(new Vector3(0, 180, 0)
            ));
            lastSpawnedPosition = newPosition;
            yield return new WaitForSeconds(2.0f);
        }
    }

    float GetNewPosition()
    {
        float newPosition;
        do
        {
            newPosition = positions[Random.Range(0, positions.Length)];
        } while (Mathf.Abs(newPosition - lastSpawnedPosition) < 50); // Проверка на расстояние между последней и новой позицией
        return newPosition;
    }
}
