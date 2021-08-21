using UnityEngine;

/* Class used for all stats where we want to be able to add/remove modifiers */

[System.Serializable]
public class Stat
{

	[SerializeField]
	private float m_BaseValue;  // Starting value

	// Get the final value after applying modifiers
	public float GetValue()
	{
		return m_BaseValue;
	}

	// Add new modifier
	public void AddModifier(float i_Modifier)
	{
		m_BaseValue += i_Modifier;
	}

	// Remove a modifier
	public void SubtractModifier(float i_Modifier)
	{
		m_BaseValue -= i_Modifier;
	}

	// Divide a modifier
	public void DivideModifier(float i_Modifier)
	{
		m_BaseValue /= i_Modifier;
	}

}