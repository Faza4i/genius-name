using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawPlayers : MonoBehaviour
{
    public GameObject player;
    public float minX, minZ, maxX, maxZ;

    void Start()
    {
        Vector3 ramdomPosition = new Vector3 (Random.Range(minX, minZ), 10, Random.Range (maxX, maxZ));
        PhotonNetwork.Instantiate (player.name, ramdomPosition, Quaternion.identity);
    }
}
