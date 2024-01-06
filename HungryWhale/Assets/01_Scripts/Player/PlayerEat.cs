using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEat : MonoBehaviour
{
	private bool isEatting = false;

	private Player player;

	private void Awake()
	{
		player = GetComponent<Player>();
	}


	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			isEatting = true;
			player.playerAnimator.SetAttack(isEatting);
		}
		if (Input.GetMouseButtonUp(0))
		{
			isEatting = false;
			player.playerAnimator.SetAttack(isEatting);
		}

	}
}
