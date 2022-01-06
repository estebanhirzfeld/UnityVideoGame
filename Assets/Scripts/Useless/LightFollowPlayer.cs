using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollowPlayer : MonoBehaviour
{
    Vector3 distance = new Vector3(0, 1.9f, 0);
    [SerializeField] private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + distance;
    }
}
