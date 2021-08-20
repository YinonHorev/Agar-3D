using UnityEngine;

public class BlobStat : MonoBehaviour
{
	[SerializeField]
	private readonly float r_SlowDivider;

	[SerializeField]
	private Stat m_Size;

	[SerializeField]
	private Stat m_Speed;

	public void AddSize(float i_Size)
    {
		m_Size.AddModifier(i_Size);
		m_Speed.DivideModifier(r_SlowDivider);
	}

	public float GetSize()
	{
		return m_Size.GetValue();
	}

	public void AddSpeed(float i_Size)
	{
		m_Size.AddModifier(i_Size);
	}

	public float GetSpeed()
	{
		return m_Size.GetValue();
	}

	public bool TryToKill(float i_Damage)
	{
        // If Blob has more damage reaches zero
        if (m_Size.GetValue() - i_Damage <= 0)
		{
			return true;
		}

		return false;
	}

	public virtual void Die()
	{
		// Die in some way
		Debug.Log(transform.name + " died.");
	}
}
