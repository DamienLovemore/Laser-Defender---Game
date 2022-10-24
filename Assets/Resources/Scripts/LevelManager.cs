using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float loadDelay = 2f;

    //Loads the first scene where the user decides to play
    //or exit the game
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Loads the scene where the player plays the game
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    //Loads the scene where it shows the player score after
    //it has died
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", loadDelay));
    }

    //Closes the game (with all of its scenes)
    public void QuitGame()
    {
        Application.Quit();
    }

    //Waits for an amount of seconds before loading the other
    //scene (screen)
    private IEnumerator WaitAndLoad(string sceneName, float delayAmount)
    {
        yield return new WaitForSeconds(delayAmount);
        SceneManager.LoadScene(sceneName);
    }
}
