using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject m_Player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - m_Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = new Vector3(0,1,-1) * PlayerManager.instance.Player.GetComponent<Transform>().localScale.y;
        transform.position = m_Player.transform.position + offset + p;
    }
}