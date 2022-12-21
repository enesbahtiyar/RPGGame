using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] playerPrefabs;
    [SerializeField] Transform playerStart;

    private void Start()
    {
        Instantiate(playerPrefabs[SaveScript.pChar], playerStart.position, playerStart.rotation);
    }
}
