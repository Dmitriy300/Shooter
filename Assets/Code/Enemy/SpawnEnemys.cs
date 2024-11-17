using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab; // Префаб врага
    [SerializeField] private float _spawnInterval = 2.0f; // Интервал спавна врагов
    [SerializeField] private int _maxEnemies = 10; // Максимальное количество врагов на сцене
    [SerializeField] private int _currentEnemyCount = 0; // Текущее количество врагов

    // Определяем точки спавна в виде массива
    public Vector3[] spawnPoints;

    void Start()
    {
        // Проверяем, чтобы было не менее 5 заданных точек
        if (spawnPoints.Length < 5)
        {
            Debug.LogError("Необходимо задать как минимум 5 точек спавна!");
            return;
        }

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (_currentEnemyCount < _maxEnemies)
            {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        // Выбираем случайную точку спавна из заданных
        Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Создаем врага и увеличиваем счетчик
        Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
        _currentEnemyCount++;
    }

    public void OnEnemyDestroyed()
    {
        _currentEnemyCount--;
    }
}
