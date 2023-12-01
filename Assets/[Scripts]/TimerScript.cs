using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float totalTime = 60f; // Total time in seconds
    private float currentTime;

    public TMP_Text timerText; // Use TMP_Text instead of Text

    private void Start()
    {
        currentTime = totalTime;
        UpdateUIText();
    }

    private void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            UpdateUIText();
        }
        else
        {
            // Time has run out, handle game loss
            HandleGameLoss();
        }
    }

    void UpdateUIText()
    {
        // Convert the time to minutes and seconds
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        // Update the UI text with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void HandleGameLoss()
    {
        // Perform actions when the game is lost due to running out of time
        Debug.Log("Game Over - Time Ran Out!");
        UIController.Instance.Moricion();
        UIController.
        // Add additional game loss logic here, like showing a game over screen or restarting the level.
    }
}

