using UnityEngine;

public class MainCharecterController : MonoBehaviour
{
    [SerializeField]
    private Transform m_TargetPrefab;
    [SerializeField]
    private Rigidbody m_SphereRig;
    [SerializeField]
    private float rotationSensetivity = 0.025f;
    [SerializeField]
    private float movmentSensetivity = 0.01f;
    [SerializeField]
    private float jumpSensetivity = 10f;

    private const float k_SensetivityYRotation = 10f;

    private Vector3 lastMousePosition;
    private Vector3 startPos;
    private Quaternion startRot;
    
    // Start is called before the first frame update
    void Start()
    {
        lastMousePosition = Input.mousePosition;
        startPos = transform.position;
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaPos = lastMousePosition - Input.mousePosition;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            m_SphereRig.AddForce( movmentSensetivity * (transform.forward));
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            m_SphereRig.AddForce(  - movmentSensetivity * (transform.forward));
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            m_SphereRig.AddForce( - movmentSensetivity * (transform.right));
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            m_SphereRig.AddForce(movmentSensetivity * (transform.right));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_SphereRig.AddForce(jumpSensetivity * (transform.up));
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPos;
            transform.rotation = startRot;
        }

        if (deltaPos.x != 0)
        {
            transform.Rotate(transform.up, deltaPos.x * rotationSensetivity);
            transform.Rotate(transform.right, deltaPos.y * rotationSensetivity * k_SensetivityYRotation);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(m_TargetPrefab, new Vector3(Random.Range(-10f, 10f), 1.5f, Random.Range(-10f, 10f)), Quaternion.identity);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody != null && hit.rigidbody.GetComponent<enemy_hp>())
                {
                    hit.rigidbody.GetComponent<enemy_hp>().hitMe();
                }
            }
        }
        lastMousePosition = Input.mousePosition;
    }
}
