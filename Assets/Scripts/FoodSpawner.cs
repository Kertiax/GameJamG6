using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    public float spawnInterval;
    public float spawnRadius;
    public float desiredZPosition;
    public float foodLifetime;
    public float spawnHeight;

    private float timeSinceLastSpawn;

    private void Start()
    {
        timeSinceLastSpawn = 0f;
    }

    private void Update()
    {
        if (Time.time - timeSinceLastSpawn > spawnInterval)
        {
            SpawnFood();
            timeSinceLastSpawn = Time.time;
        }
    }

    private void SpawnFood()
    {
        GameObject selectedFoodPrefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];

        // Calcula una posición aleatoria dentro del radio especificado y establece la altura y profundidad deseadas
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + spawnHeight, desiredZPosition) + Random.insideUnitSphere * spawnRadius;
        spawnPosition.z = desiredZPosition; // Mantiene la coordenada Z constante

        GameObject spawnedFood = Instantiate(selectedFoodPrefab, spawnPosition, Quaternion.identity);

        // Destruye la comida después de un tiempo determinado
        Destroy(spawnedFood, foodLifetime);
    }
}
