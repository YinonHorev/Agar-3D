using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject m_Enemy;
    [SerializeField] private GameObject m_Candy;

    private int m_numOfCallsForUpdate = 0;

    private const int k_SencePeriod = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_numOfCallsForUpdate == k_SencePeriod)
        {
            Instantiate(m_Enemy, new Vector3(Random.Range(-10, 10), 1.5f, Random.Range(-10, 10)), Quaternion.identity);
            Instantiate(m_Candy, new Vector3(Random.Range(-10, 10), 1.5f, Random.Range(-10, 10)), Quaternion.identity);
            m_numOfCallsForUpdate = 0;
        }
        else
        {
            m_numOfCallsForUpdate++;
        }
    }
}
