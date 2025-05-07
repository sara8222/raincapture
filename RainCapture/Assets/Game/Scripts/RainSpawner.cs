using UnityEngine;

public class RainSpawner : MonoBehaviour
{
    [Header("Rain Settings")]
    [SerializeField] private GameObject rainDropPrefab;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float xRange = 8f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRainDrop), 1f, spawnInterval);
    }

    private void SpawnRainDrop()
    {
        float randomX = Random.Range(-xRange, xRange);
        Vector3 spawnPosition = new Vector3(randomX, 6f, 0f);

        Instantiate(rainDropPrefab, spawnPosition, Quaternion.identity);
    }
}
