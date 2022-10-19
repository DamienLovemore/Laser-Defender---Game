using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private WaveConfigSO waveConfig;
    private List<Transform> waypoints;
    private int waypointIndex = 0;
    
    //Gets the list of waypoints of this path, and set the position of
    //the gameobject attached to this script to be first waypoint of the path.
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }
    
    //For every frame keeps following the waypoints, "the path" that the enemies
    //should move
    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        //If we are within the first and the last index it should keep moving forward
        //(Index is between zero and count-1)
        if(waypointIndex < waypoints.Count)
        {
            //The new position
            Vector3 targetPosition = waypoints[waypointIndex].position;
            //How fast we are moving (framerate independent(Time.deltaTime))
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;

            //Move the enemy towards the new position, with the specified time
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        //Once the enemy has reached the end of the path it will destroy it
        else
        {
            Destroy(gameObject);
        }
    }
}
