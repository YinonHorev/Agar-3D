using UnityEngine;
using UnityEngine.InputSystem;

public class MainCharecterController : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private BlobStat m_BlobStat;

    private float movementX;
    private float movementY;

    [SerializeField]
    private GameObject m_Candy;

    [SerializeField]
    private GameObject m_Enemy;

    [SerializeField]
    private GameObject m_GameOverImage;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<BlobStat>();
        m_BlobStat = gameObject.GetComponent<BlobStat>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void updateSize()
    {
        transform.localScale = Vector3.one * m_BlobStat.Size;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject == m_Candy)
        {
            Destroy(gameObject, .5f);
            m_BlobStat.AddSize(10.1f);

        }

        if (otherObj.gameObject == m_Enemy)
        {
            float enemySize = otherObj.gameObject.transform.localScale.x;
            bool ShouldIDie = m_BlobStat.TryToKill(enemySize); // it doesnt matter which axis we take it represents size
            if (!ShouldIDie)
            {
                m_BlobStat.AddSize(enemySize);
            }
            else
            {
                m_GameOverImage.SetActive(true);
                //SceneManager.LoadScene("MainMenu");
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        m_Rigidbody.AddForce(movement * m_BlobStat.Speed);

        updateSize();
    }
}
