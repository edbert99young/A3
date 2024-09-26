using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacstudent : MonoBehaviour
{
    // array to store references to the objects that will move
    [SerializeField]
    Transform[] transformArray;

    int lastTime;      // Variable to track the last time (in seconds) an event occurred
    int lastMoveTime;  // Variable to track the last time the object moved
    float timer;       // Timer to keep track of time elapsed

    public float speed = 0.01f;  // The speed at which the object moves

    public Animator animatorController;  // Reference to the Animator component for handling animations
    public AudioClip noPellet;           // Audio clip to be played when there's no pellet

    const float moveWait = 0.02f;  // The minimum time to wait before moving the object again

    // These vectors represent four points the object will move between in a loop
    private Vector3 destination;
    Vector3 firstPoint = new Vector3(-12.5f, 13.5f, 0f);
    Vector3 secondPoint = new Vector3(-7.5f, 13.5f, 0f);
    Vector3 thirdPoint = new Vector3(-7.5f, 9.5f, 0f);
    Vector3 fourthPoint = new Vector3(-12.5f, 9.5f, 0f);

    // Called when the script first runs
    void Start()
    {
        ResetTime();  // Reset the timers

        // Set the camera to orthographic view and adjust its size
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = 16.0f;

        SetDestination(secondPoint);  // Set the first destination to the second point

        // Set the audio clip to be played when there's no pellet
        GetComponent<AudioSource>().clip = noPellet;
    }

    // Called once per frame
    void Update()
    {
        timer += Time.deltaTime;  // Increase the timer by the time that has passed since the last frame

        // If one second has passed, play the audio clip
        if ((int)timer > lastTime)
        {
            lastTime = (int)timer;
            Debug.Log(lastTime);
            GetComponent<AudioSource>().Play();
        }

        // If the timer has passed the last move time by more than moveWait, move the objects
        if (timer > lastMoveTime + (int)moveWait)
        {
            lastMoveTime = (int)timer;
            MoveObjects();
        }
    }

    // Reset the time tracking variables
    private void ResetTime()
    {
        lastTime = -1;  // Set the lastTime to -1, so the audio plays immediately in the first second
        lastMoveTime = 0;  // Reset the last move time to 0
        timer = 0.0f;  // Reset the timer
    }

    // This function handles moving the objects between the four points
    private void MoveObjects()
    {
        // Check the destination is the second point
        if (destination == secondPoint)
        {
            // If reached the second point, set the destination to the third point
            if (transformArray[0].position.x > -7.55f)
            {
                SetDestination(thirdPoint);
            }
            else
            {
                // else, move towards the second point and update the animation state
                animatorController.SetBool("MoveRight", true);
                animatorController.SetBool("MoveUp", false);
                transformArray[0].transform.position = Vector3.Lerp(transformArray[0].position, destination, speed);
                print("First To Second");
            }
        }

        // Similar logic for moving from the second point to the third point
        if (destination == thirdPoint)
        {
            if (transformArray[0].position.y < 9.55f)
            {
                SetDestination(fourthPoint);
            }
            else
            {
                animatorController.SetBool("MoveDown", true);
                animatorController.SetBool("MoveRight", false);
                transformArray[0].transform.position = Vector3.Lerp(transformArray[0].position, destination, speed);
                print("Second To Third");
            }
        }

        // Similar logic for moving from the third point to the fourth point
        if (destination == fourthPoint)
        {
            if (transformArray[0].position.x < -12.45f)
            {
                SetDestination(firstPoint);
            }
            else
            {
                animatorController.SetBool("MoveLeft", true);
                animatorController.SetBool("MoveDown", false);
                transformArray[0].transform.position = Vector3.Lerp(transformArray[0].position, destination, speed);
                print("Third To Fourth");
            }
        }

        // Similar logic for moving from the fourth point back to the first point
        if (destination == firstPoint)
        {
            if (transformArray[0].position.y > 13.45f)
            {
                SetDestination(secondPoint);
            }
            else
            {
                animatorController.SetBool("MoveUp", true);
                animatorController.SetBool("MoveLeft", false);
                transformArray[0].transform.position = Vector3.Lerp(transformArray[0].position, destination, speed);
                print("Fourth To First");
            }
        }
    }

    // Set the new destination point for the object
    public void SetDestination(Vector3 newPos)
    {
        destination = newPos;
    }
}

