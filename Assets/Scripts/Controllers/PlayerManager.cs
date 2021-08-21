/* Keeps track of the player */
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

	#region Singleton

	public static PlayerManager instance;

	void Awake()
	{
		instance = this;
	}

	#endregion

	public GameObject Player;

}