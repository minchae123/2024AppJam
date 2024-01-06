using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private GameObject player;
    private float speed = 5;

    public float floatSpeed = 1.0f; // �յ� ���ٴϴ� �ӵ�
    public float floatHeight = 1.0f; // �յ� ����

    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

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
        Vector2 currentPosition = transform.position;

        // �յ� ���ٴϴ� �ӵ��� ���� ���ο� ��ġ�� ���
        currentPosition.y = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // ���ο� ��ġ�� ������Ʈ
        transform.position = currentPosition;
    }

    private void Check()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > 18)
        {
            TrashSpawner.instance.spawnCount--;
            Destroy(gameObject);
        }
    }

    public void Eaten()
    {
        Destroy(gameObject);
        player.gameObject.GetComponent<Player>().DecreaseHP(5);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.TryGetComponent(out PlayerEat p))
        {
            if (p.isEatting)
                Eaten();
        }
    }
}
