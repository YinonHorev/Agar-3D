using UnityEngine;
using UnityEngine.InputSystem;

public class MainPlayer : CharecterController
{

    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    private new void Start()
    {
        base.Start();
    }


    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private new void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        m_Rigidbody.AddForce(movement * m_BlobStat.Speed);

        base.FixedUpdate();
    }
}
