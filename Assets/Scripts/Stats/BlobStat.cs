using UnityEngine;

public class BlobStat : MonoBehaviour
{
	[SerializeField]
	private readonly float r_SlowDivider = 0.05f;

	[SerializeField]
	private Stat m_Size;

	[SerializeField]
	private Stat m_Speed;

    public float Speed { get => m_Speed.BaseValue;}
    public float Size { get => m_Size.BaseValue;}

    public void AddSize(float i_Size)
    {
		m_Size.AddModifier(i_Size);
		m_Speed.DivideModifier(i_Size * r_SlowDivider + 1);
	}

	public void AddSpeed(float i_Size)
	{
		m_Size.AddModifier(i_Size);
	}

	public bool TryToKill(float i_Damage)
	{
        // If Blob has more damage reaches zero
        if (Size - i_Damage <= 0)
		{
			return true;
		}

		return false;
	}

}
