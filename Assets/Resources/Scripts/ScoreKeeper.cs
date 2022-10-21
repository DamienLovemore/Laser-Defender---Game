using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score;

    //Method responsible for getting the actual
    //score of the game
    public int GetScore()
    {
        int returnValue;

        returnValue = score;

        return returnValue;
    }

    //Method responsible for updating the game
    //score value
    public void AddScore(int newScore)
    {
        int treatedScore;

        //Makes sure the score does not get a negative value
        treatedScore = Mathf.Clamp(this.score + newScore, 0, int.MaxValue);

        this.score = treatedScore;
    }

    //Resets the game score back to zero
    public void ResetScore()
    {
        this.score = 0;
    }
}
