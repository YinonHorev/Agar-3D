using UnityEngine;

public class CharecterController : MonoBehaviour
{
    protected Rigidbody m_Rigidbody;
    protected BlobStat m_BlobStat;

    //[SerializeField]
    //private GameObject m_GameOverImage;
    
    // Start is called before the first frame update
    protected void Start()
    {
        gameObject.AddComponent<BlobStat>();
        m_BlobStat = gameObject.GetComponent<BlobStat>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void updateSize()
    {
        transform.localScale = Vector3.one * m_BlobStat.Size;
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.CompareTag("Candy"))
        {
            otherObj.gameObject.SetActive(false);
            m_BlobStat.AddSize(0.1f);
        }

        if (otherObj.gameObject.CompareTag("Enemy"))
        {
            float enemySize = otherObj.gameObject.transform.localScale.x;
            bool ShouldIDie = m_BlobStat.TryToKill(enemySize); // it doesnt matter which axis we take it represents size
            if (!ShouldIDie)
            {
                m_BlobStat.AddSize(enemySize);
            }
            else
            {
                gameObject.SetActive(false);
                //m_GameOverImage.SetActive(true);
                //SceneManager.LoadScene("MainMenu");
            }
        }
    }

    protected void FixedUpdate()
    {
        updateSize();
    }


    //private void OnMove(InputValue movementValue)
    //{
    //    Vector2 movementVector = movementValue.Get<Vector2>();

    //    movementX = movementVector.x;
    //    movementY = movementVector.y;
    //}
}
