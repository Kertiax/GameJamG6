using UnityEngine;

public enum FoodType
{
    Positive, // Incrementa el crecimiento
    Negative // Decrementa el crecimiento
}

public class FoodController : MonoBehaviour
{
    public FoodType foodType = FoodType.Positive;
    public float growthAmount = 1.5f;
    public float fallSpeed = 2f; // Velocidad de ca�da
    Sounds sound;
    private void Start()
    {
        sound = GetComponent<Sounds>();
        // Aseg�rate de que la comida tenga un Rigidbody
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false; // Desactiva la gravedad por ahora
        }

        
    }

    private void Update()
    {
        // Simula la ca�da de la comida
        transform.Translate(Vector3.down * fallSpeed 
            * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        FishController fishController = 
            other.GetComponent<FishController>();

        if (fishController != null)
        {
            ApplyFoodEffect(fishController);
            Destroy(gameObject);
        }
    }

    private void ApplyFoodEffect(FishController fishController)
    {
        switch (foodType)
        {
            case FoodType.Positive:
                fishController.Feed(growthAmount);              
                break;

            case FoodType.Negative:
                fishController.Feed(-growthAmount);
                break;
        }
    }
}
