using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private GameObject player;
    private float speed = 8;

    private void Update()
    {
        Move();
        Check();
    }

    public void SetPlayer(GameObject p)
    {
        player = p;
    }

    private void Move() 
    {
        transform.position += new Vector3((GetComponent<SpriteRenderer>().flipX ? 1 : -1) * speed * Time.deltaTime, 0, 0);
    }

    private void Check()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > 18)
        {
            FishSpawner.instance.spawnCount--;
            Destroy(gameObject);
        }
    }
}
