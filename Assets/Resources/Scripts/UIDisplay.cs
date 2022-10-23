using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Slider healthSlider;
    //Because enemies also have health, so its
    //easier to set it in the editor
    [SerializeField] private Health playerHealth;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper playerScore;
        
    void Awake()
    {        
        playerScore = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        //Sets the slider maximum value to be the player
        //initial (max) health
        healthSlider.maxValue = playerHealth.GetHealthPoints();
    }
        
    void Update()
    {
        //Updates the health value based on the current
        //health of the player (if it has changed)
        healthSlider.value = playerHealth.GetHealthPoints();
        //Need to convert to string, because text only accepts
        //string values (the zeros if the is not that amount
        //of characters then it fills it with zeros)
        scoreText.text = playerScore.GetScore().ToString("000000000");
    }
}
