using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneEntity : MonoBehaviour
{
    
    
    [SerializeField] GameObject m_Jib;

    const float JIB_ANGULAR_VELOCITY = 5f;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_Jib.transform.Rotate(0, 0, -JIB_ANGULAR_VELOCITY * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            m_Jib.transform.Rotate(0, 0, JIB_ANGULAR_VELOCITY * Time.deltaTime);
        }
        

    }

}
