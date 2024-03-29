using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
	private GameObject player;

	public float floatSpeed = 1.0f; // 둥둥 떠다니는 속도
	public float floatHeight = 1.0f; // 둥둥 높이

	private Vector2 startPosition;

	private void Start()
	{
		startPosition = transform.position;

		floatSpeed = Random.Range(0.8f, 1.5f);
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

		// 둥둥 떠다니는 속도를 더해 새로운 위치를 계산
		currentPosition.y = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

		// 새로운 위치로 업데이트
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
		UIManager.Instance.FishCountText(++GameManager.Instance.FishCount);
		TrashSpawner.instance.spawnCount--;
		player.gameObject.GetComponent<Player>().DecreaseHP(5);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out PlayerEat p))
		{
			if (p.isEatting)
			{
				Eaten();
			}
		}
	}
}
