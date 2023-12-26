using UnityEngine;
using System.Collections;

// Создаем класс SpawnCars
public class SpawnCars : MonoBehaviour
{
    // Объявляем переменные
    public GameObject[] cars; // Массив машин
    private float[] positions = { 46.1f, 151.2f, 258.2f, -56.1f, -157.2f, -258.7f }; // Массив позиций
    private float lastSpawnedPosition; // Позиция последней созданной машины
    private float cooldownTime = 1.0f; // Время задержки в секундах

    // Функция, вызываемая при запуске игры
    void Start()
    {
        // Запускаем корутину spawn()
        StartCoroutine(spawn());
    }

    // Корутина, которая будет создавать машины
    IEnumerator spawn()
    {
        // В бесконечном цикле
        while (true)
        {
            // Получаем новую позицию для создания машины
            float newPosition = GetNewPosition();

            // Создаем машину на новой позиции
            Instantiate(
                cars[Random.Range(0, cars.Length)], // Случайно выбираем машину из массива
                new Vector3(newPosition, 280f, 0), // Устанавливаем позицию машины
                Quaternion.Euler(new Vector3(0, 180, 0) // Поворачиваем машину на 180 градусов
            ));

            // Обновляем последнюю созданную позицию
            lastSpawnedPosition = newPosition;

            // Ждем определенное время перед созданием следующей машины
            yield return new WaitForSeconds(2.5f);
        }
    }

    // Функция для получения новой позиции машины
    float GetNewPosition()
    {
        float newPosition;

        // Генерируем случайную позицию из массива
        do
        {
            newPosition = positions[Random.Range(0, positions.Length)];
        } while (Mathf.Abs(newPosition - lastSpawnedPosition) < 50); // Проверяем, чтобы между последней и новой позицией было расстояние не менее 50

        // Возвращаем новую позицию
        return newPosition;
    }
}