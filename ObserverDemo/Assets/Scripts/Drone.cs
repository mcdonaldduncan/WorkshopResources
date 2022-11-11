using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Observer
{
    private Player player;
    

    public override void Notify(Subject subject)
    {
        if (player == null)
        {
            player = subject.GetComponent<Player>();
        }
        // Test again because the return of GetComponent could return null.
        if (player != null)
        {
            AngleOperation(player.transform.right);
         
        }

    }

    public override void Notify(Vector3 playervec)
    {
        AngleOperation(playervec);
    }

    private void AngleOperation(Vector3 playervec)
    {
        float dotProduct = Vector3.Dot(Vector3.right, playervec);
        // Use the Dot product between the one of the drones and the players to determine the similiarity of the vectors
        float playerAngleRadians = Mathf.Acos(dotProduct);


        float playerAngleDegrees = playerAngleRadians * Mathf.Rad2Deg;
        // This may need rounding. Unity does not provide a function to round to a certain 
        // number of decimal points. To do this use the .NET Math library (Microsoft)
        // Unity displays 2 decimal points of precision in the inspector
        float playerAngleDegreesRounded = (float)System.Math.Round(playerAngleDegrees, 2);

        Debug.LogFormat("Player Angle in radians:{0}, degrees(unrounded):{1}, degrees(rounded):{2}",
            playerAngleRadians, playerAngleDegrees, playerAngleDegreesRounded);

        // Move the angle of the drones
        Quaternion nextDroneAngle = Quaternion.Euler(0, playerAngleDegrees, 0);

        StartCoroutine(RotateDrone(nextDroneAngle));
    }

    IEnumerator RotateDrone(Quaternion nextDroneAngle)
    {
        while (transform.rotation != nextDroneAngle)
        {
            var slightRotation = Quaternion.Slerp(transform.rotation, nextDroneAngle, .1f);
            transform.rotation = slightRotation;

            yield return new WaitForSeconds(.2f);
        }

        yield return null;
    }

    
}
