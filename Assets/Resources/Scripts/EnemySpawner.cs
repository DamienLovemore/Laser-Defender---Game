using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;

    void Start()
    {
        SpawnEnemies();
    }

    //Gets the wave that the game is currently playing
    public WaveConfigSO GetCurrentWave()
    {
        WaveConfigSO returnValue;

        returnValue = this.currentWave;

        return returnValue;
    }

    //Spawn all the enemies of this wave
    private void SpawnEnemies()
    {
        for(int index = 0; index < currentWave.GetEnemyCount(); index++)
        {
            //Creates a game object from a prefab, in that position, with that rotation, and the specified parent
            Instantiate(currentWave.GetEnemyPrefab(index), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
        }        
    }
}
