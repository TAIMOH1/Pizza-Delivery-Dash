using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float timeRemaining = 300f; 
    [SerializeField] int pizzasNeeded = 20;
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text resultText;

    int pizzasDelivered = 0;
    bool gameEnded = false;

   
        void Start()
        {
            Time.timeScale = 1f;
            resultText.text = "";
        }
    

    void Update()
    {
        if (gameEnded) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
            resultText.text = "TIME UP!";
            gameEnded = true;
            Time.timeScale = 0f;
        }

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = minutes + ":" + seconds.ToString("00");
    }

    public void PizzaDelivered()
    {
        if (gameEnded) return;

        pizzasDelivered++;

        if (pizzasDelivered >= pizzasNeeded)
        {
            resultText.text = "YOU WIN!";
            gameEnded = true;
            Time.timeScale = 0f;
        }
    }
}