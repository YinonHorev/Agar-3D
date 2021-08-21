using UnityEngine;
using UnityEngine.SceneManagement;

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

    private const float k_SensetivityYRotation = 10f;

    private Vector3 lastMousePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        lastMousePosition = Input.mousePosition;
        gameObject.AddComponent<BlobStat>();
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

        if (deltaPos.x != 0)
        {
            transform.Rotate(transform.up, deltaPos.x * rotationSensetivity);
            transform.Rotate(transform.right, deltaPos.y * rotationSensetivity * k_SensetivityYRotation);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(m_TargetPrefab, new Vector3(Random.Range(1f, 20f), Random.Range(1f, 20f), Random.Range(1f, 20f)), Quaternion.identity);
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

        updateSize();
    }

    private void updateSize()
    {
        transform.localScale = Vector3.one * gameObject.GetComponent<BlobStat>().GetSize();
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Coin")
        {
            Destroy(gameObject, .5f);
            gameObject.GetComponent<BlobStat>().AddSize(0.1f);

        }

        if (otherObj.gameObject.tag == "Enemy")
        {
            float enemySize = otherObj.gameObject.transform.localScale.x;
            bool ShouldIDie = gameObject.GetComponent<BlobStat>().TryToKill(enemySize); // it doesnt matter which axis we take it represents size
            if (!ShouldIDie)
            {
                gameObject.GetComponent<BlobStat>().AddSize(enemySize);
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
