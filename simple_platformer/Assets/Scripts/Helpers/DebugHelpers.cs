using UnityEngine;
using System.Collections;

public class DebugHelpers
{

    public static void TeleportPlayerToSpawn()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
    }
}
