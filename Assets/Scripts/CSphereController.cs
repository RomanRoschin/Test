using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSphereController : MonoBehaviour
{
    private Vector3[] m_dirList;
    private CMove m_move;
    private Transform m_transform;

    /////////////////
    // Start
    void Start()
    {
        m_dirList = new Vector3[6];
        m_dirList[0] = new Vector3(1, 0, 0);
        m_dirList[1] = new Vector3(-1, 0, 0);
        m_dirList[2] = new Vector3(0, 1, 0);
        m_dirList[3] = new Vector3(0, -1, 0);
        m_dirList[4] = new Vector3(0, 0, 1);
        m_dirList[5] = new Vector3(0, 0, -1);
        m_transform = GetComponent<Transform>(); ;

        m_move = new CMove();
    }

    private int CheckBounds()
    {
        if (m_transform.position.x < -13) return 0;
        if (m_transform.position.x > 13) return 1;
        if (m_transform.position.y < 1) return 2;
        if (m_transform.position.y > 7) return 3;
        if (m_transform.position.z < -13) return 4;
        if (m_transform.position.z > 13) return 5;

        return -1;
    }

    /////////////////////////////////
    // Update
    void Update()
    {
        if (!m_move.IsActive())
        {
         int n;
            n = CheckBounds();
            if(n<0) n = Random.Range(0,6);
            m_move.SetPositions(m_transform.position,m_transform.position+m_dirList[n]);
            m_move.StartAction();
        }
        m_move.UpdatePosition();
        m_transform.position = m_move.GetCurrentPosition();
    }
}
