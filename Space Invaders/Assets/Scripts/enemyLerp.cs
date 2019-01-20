using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLerp : MonoBehaviour
{
    //// Transforms to act as start and end markers for the journey.
    //public Transform startMarker;
    //public Transform endMarker;

    //private static  GameObject openSpot = null;
    //private static GameObject targetAlien= null;

    //// Movement speed in units/sec.
    //public float speed = 1.0F;

    //// Time when the movement started.
    //private float startTime;

    //// Total distance between the markers.
    //private float journeyLength;

    //private static bool beginLerping = false;

    //void Start()
    //{
    //    // Keep a note of the time the movement started.
    //    startTime = Time.time;

    //    // Calculate the journey length.
    //    //journeyLength = Vector3.Distance(targetAlien.transform.position, endMarker.position);
    //}

    //// Follows the target position like with a spring
    //void Update()
    //{

    //    if (beginLerping == true)
    //    {
    //        journeyLength = Vector3.Distance(targetAlien.transform.position, openSpot.transform.position);

    //        // Distance moved = time * speed.
    //        float distCovered = (Time.time - startTime) * speed;

    //        // Fraction of journey completed = current distance divided by total distance.
    //        float fracJourney = distCovered / journeyLength;

    //        // Set our position as a fraction of the distance between the markers.
    //        transform.position = Vector3.Lerp(targetAlien.transform.position, openSpot.transform.position, fracJourney);
    //    }
    //}

    //public static void moveAlien(GameObject targetSpot,GameObject startingSpot)
    //{
    //    openSpot = targetSpot;
    //    targetAlien = startingSpot;

    //    beginLerping = true;
    //}


    private static Transform openSpot;
    private static Transform targetAlien;


    // Movement speed in units/sec.
    public float lerpSpeed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private static bool beginLerping = false;

    private void Update()
    {


        if (beginLerping == true)
        {
            //journeyLength = Vector3.Distance(transform.position, openSpot.transform.position);

            //// Distance moved = time * speed.
            //float distCovered = (Time.time - startTime) * speed;

            //// Fraction of journey completed = current distance divided by total distance.
            //float fracJourney = distCovered / journeyLength;

            //// Set our position as a fraction of the distance between the markers.
            //transform.position = Vector3.Lerp(transform.position, openSpot.transform.position, fracJourney);

            //if(transform.position == openSpot.transform.position)
            //{
            //    beginLerping = false;
            //}

            // The step size is equal to speed times frame time.
            float step = lerpSpeed * Time.deltaTime;

            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, openSpot.position, step);

            if (transform.position == openSpot.position)
            {
                beginLerping = false;
            }
        }
    }

    public static void moveAlien(GameObject targetSpot, GameObject startingSpot)
    {
        openSpot = targetSpot.transform;
        targetAlien = startingSpot.transform;

        beginLerping = true;
    }
}
