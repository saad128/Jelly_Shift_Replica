using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    [SerializeField] Vector3 offset = new Vector3(-11, 3, 0);
  
    private void LateUpdate()
    {
        // camera follow the player by add the offset
        transform.position = player.transform.position + offset;
    }
}
