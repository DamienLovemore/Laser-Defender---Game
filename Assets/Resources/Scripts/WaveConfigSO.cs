using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Wave Config", fileName="New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float moveSpeed = 5f;

    //Gets how much enemies are being instantiated in 
    //currently in this wave
    public int GetEnemyCount()
    {
        int returnValue;

        returnValue = this.enemyPrefabs.Count;

        return returnValue;
    }

    //Gets an enemy of this wave in a specified position
    public GameObject GetEnemyPrefab(int index)
    {
        GameObject returnValue;

        returnValue = this.enemyPrefabs[index];

        return returnValue;
    }

    //Gets the first waypoint of this path
    public Transform GetStartingWaypoint()
    {
        Transform returnValue;

        returnValue = pathPrefab.GetChild(0);

        return returnValue;
    }

    //Gets all the waypoints associated with this path
    public List<Transform> GetWaypoints()
    {
        List<Transform> returnValue = new List<Transform>();

        //Looks for all the the child elements of the parent element
        //that is pathPrefab (Constains all the waypoints)
        foreach (Transform child in pathPrefab)
        {
            returnValue.Add(child);
        }

        return returnValue;
    }

    //Gets the moving speed of enemies ships in this wave
    public float GetMoveSpeed()
    {
        float moveSpeed;

        moveSpeed = this.moveSpeed;

        return moveSpeed;
    }
}
