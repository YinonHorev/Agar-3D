using UnityEngine;

/* Class used for all stats where we want to be able to add/remove modifiers */

[System.Serializable]
public class Stat
{

	[SerializeField]
	private int baseValue;  // Starting value

	// Get the final value after applying modifiers
	public int GetValue()
	{
		return baseValue;
	}

	// Add new modifier
	public void AddModifier(int i_Modifier)
	{
		baseValue += i_Modifier;
	}

	// Remove a modifier
	public void RemoveModifier(int i_Modifier)
	{
		baseValue -= i_Modifier;
	}

}