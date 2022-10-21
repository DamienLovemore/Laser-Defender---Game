using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 1f;
    [SerializeField] private float shakeMagnitude = 0.5f;

    private Vector3 initialPosition;

    void Start()
    {
        //Gets the entity position when the game started
        initialPosition = transform.position;
    }

    //Plays the shake animation
    public void Play()
    {
        StartCoroutine(Shake());
    }

    //Shakes the game screen
    IEnumerator Shake()
    {
        //Starts with zero seconds
        float elapsedTime = 0;
        while (elapsedTime < shakeDuration)
        {
            //Change the position to be a random position of the inside
            //of a circle, multiplied by the shake strenght (magnitude)
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            //Increases the time passed
            elapsedTime += Time.deltaTime;

            //Waits after the frame is rendered to see if it still
            //has to do something
            yield return new WaitForEndOfFrame();
        }        

        //Brings the camera position to its original position
        transform.position = initialPosition;
    }
}
