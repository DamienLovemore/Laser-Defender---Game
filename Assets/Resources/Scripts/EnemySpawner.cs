using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigSO> waveConfigs;
    [SerializeField] private float timeBetweenWaves = 0f;
    private WaveConfigSO currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    //Gets the wave that the game is currently playing
    public WaveConfigSO GetCurrentWave()
    {
        WaveConfigSO returnValue;

        returnValue = this.currentWave;

        return returnValue;
    }

    //Spawn all the enemies of this wave
    private IEnumerator SpawnEnemies()
    {
        foreach (WaveConfigSO wave in waveConfigs)
        {
            //Sets the current wave that we are playing
            currentWave = wave;

            //Spawns all the enemies in that wave
            for (int index = 0; index < currentWave.GetEnemyCount(); index++)
            {
                //Creates a game object from a prefab, in that position, with that rotation, and the specified parent
                Instantiate(currentWave.GetEnemyPrefab(index), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
                //Waits for a random new spawn time before, instantiating another ship
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }

            //Time before starting a new wave
            yield return new WaitForSeconds(timeBetweenWaves);
        }         
    }
}
