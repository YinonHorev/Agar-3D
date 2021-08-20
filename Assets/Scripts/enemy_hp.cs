using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hp : MonoBehaviour
{
    [SerializeField]
    private Material himMat;
    [SerializeField]
    private MeshRenderer motiRenderer;

    private int hp = 1;
    // Start is called before the first frame update
    void Start()
    {
        hp = (int)Random.Range(1.0f,2.5f);
    }

    public void hitMe()
    {
        if (hp > 1)
        {
            hp--;
            GetComponent<MeshRenderer>().material.color = new Color(1f,0f,0f);
            //motiRenderer.material = himMat;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
