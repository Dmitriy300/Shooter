using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab; // ������ �����
    [SerializeField] private float _spawnInterval = 2.0f; // �������� ������ ������
    [SerializeField] private int _maxEnemies = 10; // ������������ ���������� ������ �� �����
    [SerializeField] private int _currentEnemyCount = 0; // ������� ���������� ������

    // ���������� ����� ������ � ���� �������
    public Vector3[] spawnPoints;

    void Start()
    {
        // ���������, ����� ���� �� ����� 5 �������� �����
        if (spawnPoints.Length < 5)
        {
            Debug.LogError("���������� ������ ��� ������� 5 ����� ������!");
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
        // �������� ��������� ����� ������ �� ��������
        Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // ������� ����� � ����������� �������
        Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
        _currentEnemyCount++;
    }

    public void OnEnemyDestroyed()
    {
        _currentEnemyCount--;
    }
}
