using UnityEngine;

public class FishController : MonoBehaviour
{
    public float growthRate, maxGrowth, minYPosition,
        moveSpeed, maxYPosition, shrinkRate, timeToStarve;
    private float lastMealTime, currentGrowth = 0f;
    public GameObject[] fishPrefabs; // Lista de prefabs de peces
    private int childCount = 0;
   
    public GameObject menu;
    public Transform[] childSpawnPoints; // Nuevos: Puntos de spawn para las cr�as

    private void Start()
    {
        lastMealTime = Time.time;
        
        
    }

    private void Update()
    {
        HandleMovementInput();
        HandleFeeding();
        CheckStarvation();
    }

    private void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 
            verticalInput, 0f).normalized;

        if (moveDirection.magnitude >= 0.2f)
        {
            Vector3 newPosition = transform.position + moveDirection 
                * moveSpeed * Time.deltaTime;
            newPosition.y = Mathf.Clamp(newPosition.y, minYPosition,
                maxYPosition);
            transform.position = Vector3.Lerp(transform.position, 
                newPosition, 0.5f);
        }
    }

    public void Feed(float amount)
    {
        currentGrowth += amount;
        lastMealTime = Time.time;

        if (currentGrowth >= maxGrowth)
        {
            Grow();
            if (++childCount % 5 == 0)
            {
                SpawnChild();
            }
        }
    }

    private void Grow()
    {
        // Solo permite el crecimiento del pez principal si no tiene cr�as
        if (transform.childCount == 0)
        {
            transform.localScale = new Vector3(currentGrowth
                / maxGrowth, currentGrowth / maxGrowth, 1f);
        }
    }

    private void Shrink()
    {
        transform.localScale = new Vector3(currentGrowth 
            / maxGrowth, currentGrowth / maxGrowth, 1f);
    }

    private void HandleFeeding()
    {
        if (Time.time - lastMealTime < timeToStarve && currentGrowth < maxGrowth)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Feed(growthRate);
            }
        }
    }

    private void CheckStarvation()
    {
        if (Time.time - lastMealTime > timeToStarve && currentGrowth > 0)
        {
            currentGrowth -= shrinkRate * Time.deltaTime;
            currentGrowth = Mathf.Clamp(currentGrowth, 0f, maxGrowth);
            Shrink();
            if (currentGrowth < 0f)
            {
                Destroy(gameObject);
                
            }
        }
    }

    private void SpawnChild()
    {
        if (fishPrefabs.Length > 0 && childSpawnPoints.Length > 0)
        {
            GameObject childPrefab = fishPrefabs[Random.Range(0, 
                fishPrefabs.Length)];

            if (childPrefab != null)
            {
                // Selecciona aleatoriamente un punto de spawn para las cr�as
                Transform spawnPoint = childSpawnPoints[
                    Random.Range(0, childSpawnPoints.Length)];

                // Instancia una nueva cr�a de pez en un punto de spawn
                GameObject child = Instantiate(childPrefab, 
                    spawnPoint.position,
                    Quaternion.Euler(0,90,0), spawnPoint);
                FishController childController = 
                    child.GetComponent<FishController>();

                if (childController != null)
                {
                    childController.childCount = 0;
                    currentGrowth = 0; // Detiene el crecimiento del pez principal
                }
            }
        }
    }




}
