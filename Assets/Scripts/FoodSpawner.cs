using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    public float spawnInterval = 5f;
    public float spawnRadius = 5f;
    public float desiredZPosition = 3.8f;
    public float foodLifetime = 10f;
    public float spawnHeight = 20f; // Nueva variable: altura desde la cual se tira la comida

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
