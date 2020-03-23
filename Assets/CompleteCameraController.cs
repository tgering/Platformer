using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteCameraController : MonoBehaviour
{
    [SerializeField] public GameObject player;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(0, 0, -10);
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        position.x = player.transform.position.x;
        position.y = player.transform.position.y;
        transform.position = position;
    }
}
