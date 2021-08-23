using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject m_Enemy;
    [SerializeField] private GameObject m_Candy;

    private int m_numOfCallsForUpdate = 0;
    private int m_numOfCandys = 0;

    private const int k_SencePeriod = 50;
    private const int k_SencePeriodCandy = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_numOfCallsForUpdate == k_SencePeriod)
        {
            if (m_numOfCandys == k_SencePeriodCandy)
            {
                Instantiate(m_Enemy, new Vector3(Random.Range(-40, 40), 1.5f, Random.Range(-40, 40)), Quaternion.identity);
                m_numOfCandys = 0;
            }
                
            Instantiate(m_Candy, new Vector3(Random.Range(-40, 40), 0.4f, Random.Range(-40, 40)), Quaternion.identity);
            m_numOfCandys++;
            m_numOfCallsForUpdate = 0;
        }
        else
        {
            m_numOfCallsForUpdate++;
        }
    }
}
