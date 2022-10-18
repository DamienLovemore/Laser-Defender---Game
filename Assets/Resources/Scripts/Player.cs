using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 rawInput;

    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingBottom;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    //Sets the bounds that which the player cannot move past it
    private void InitBounds()
    {
        //Gets the main camera of this game
        Camera mainCamera = Camera.main;

        //Gets the world position of the bottom left part of the scenario
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        //Gets the world position of the top right part of the scenario
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    //Responsible for making the player moves in the game scenario
    private void Move()
    {
        //First multiply by the move speed to allow the speed to
        //be adjustable, and then multiply by Time.deltaTime to
        //make the movement framerate independent.
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;

        //Creates a variable so we can edit the values before
        //applying it to the player
        Vector2 newPos = new Vector2();
        //If the actual position of the player plus the new one, passes the boundaries
        //then return a value that does not pass.
        //(The paddings are for the player ship a part of it does not pass the borders)
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
