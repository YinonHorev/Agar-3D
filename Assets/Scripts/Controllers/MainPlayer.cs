using UnityEngine;
using UnityEngine.InputSystem;

public class MainPlayer : CharecterController
{

    private float m_MovementX;
    private float m_MovementY;

    // Start is called before the first frame update
    private new void Start()
    {
        base.Start();
    }


    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        m_MovementX = movementVector.x;
        m_MovementY = movementVector.y;
    }

    private new void FixedUpdate()
    {
        Vector3 movement = new Vector3(m_MovementX, 0.0f, m_MovementY);

        m_Rigidbody.AddForce(movement * m_BlobStat.Speed);

        base.FixedUpdate();
    }
}
