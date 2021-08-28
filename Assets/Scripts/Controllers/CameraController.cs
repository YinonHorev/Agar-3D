using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerScale = new Vector3(0,1,-1) * PlayerManager.instance.Player.GetComponent<Transform>().localScale.y;
        transform.position = player.transform.position + offset +  playerScale;
    }
}