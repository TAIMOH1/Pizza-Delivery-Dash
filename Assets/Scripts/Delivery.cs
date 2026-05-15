using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float delay = 0.1f;
    [SerializeField] GameTimer gameTimer;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && hasPackage == false)
        {
            Debug.Log("Picked up Package");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, delay);
        }

        if (collision.CompareTag("Customer") && hasPackage == true)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();

            gameTimer.PizzaDelivered();
        }
    }
}