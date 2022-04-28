using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyEntity : MonoBehaviour
{
    [SerializeField] GameObject m_Trolley;
    [SerializeField] LineRenderer m_Cable1;
    [SerializeField] LineRenderer m_Cable2;
    [SerializeField] GameObject m_Jib;
    public const float TROLLEY_VELOCITY = 0.5f;
    public GameObject m_Hook;
    float InitialJointLimit = 1f;
    float FinalJointLimit;
    ConfigurableJoint m_Joint1;
    ConfigurableJoint m_Joint2;
    float counter = 1;
    // Start is called before the first frame update
    void Start()
    {
        var joint1 = m_Trolley.gameObject.AddComponent<ConfigurableJoint>();
        joint1.xMotion = ConfigurableJointMotion.Limited;
        joint1.yMotion = ConfigurableJointMotion.Limited;
        joint1.zMotion = ConfigurableJointMotion.Limited;
        joint1.angularXMotion = ConfigurableJointMotion.Free;
        joint1.angularYMotion = ConfigurableJointMotion.Limited;
        joint1.angularZMotion = ConfigurableJointMotion.Limited;

        var joint1Limit = joint1.linearLimit;
        var joint1AngXLimit = joint1.angularXLimitSpring;
        var joint1AngYLimit = joint1.angularYLimit;
        var joint1AngZLimit = joint1.angularZLimit;
        joint1AngXLimit.damper = 0f;
        joint1AngYLimit.limit = 10f;
        joint1AngZLimit.limit = 10f;
        joint1Limit.limit = InitialJointLimit;
        joint1.linearLimit = joint1Limit;
        joint1.angularXLimitSpring = joint1AngXLimit;
        joint1.angularYLimit = joint1AngYLimit;
        joint1.angularZLimit = joint1AngZLimit;

        joint1.autoConfigureConnectedAnchor = false;
        joint1.connectedAnchor = new Vector3(0, -0.02f, 0.1f);
        joint1.anchor = new Vector3(0, 0.005f, 0);
        joint1.connectedBody = m_Hook.GetComponent<Rigidbody>();

        m_Joint1 = joint1;
        var joint2 = m_Trolley.gameObject.AddComponent<ConfigurableJoint>();
        joint2.xMotion = ConfigurableJointMotion.Limited;
        joint2.yMotion = ConfigurableJointMotion.Limited;
        joint2.zMotion = ConfigurableJointMotion.Limited;
        joint2.angularXMotion = ConfigurableJointMotion.Free;
        joint2.angularYMotion = ConfigurableJointMotion.Limited;
        joint2.angularZMotion = ConfigurableJointMotion.Limited;

        var joint2Limit = joint2.linearLimit;
        var joint2AngXLimit = joint2.angularXLimitSpring;
        var joint2AngYLimit = joint2.angularYLimit;
        var joint2AngZLimit = joint2.angularZLimit;
        joint2AngYLimit.limit = 10f;
        joint2AngZLimit.limit = 10f;
        joint2AngXLimit.damper = 0f;
        joint2Limit.limit = InitialJointLimit;
        joint2.linearLimit = joint2Limit;
        joint2.angularYLimit = joint2AngYLimit;
        joint2.angularZLimit = joint2AngZLimit;
        joint2.angularXLimitSpring = joint2AngXLimit;

        joint2.autoConfigureConnectedAnchor = false;
        joint2.connectedAnchor = new Vector3(0, -0.02f, -0.1f);
        joint2.anchor = new Vector3(0, -0.005f, 0);
        joint2.connectedBody = m_Hook.GetComponent<Rigidbody>();

        m_Joint2 = joint2;

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(counter > 0 && counter < 1000f)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                m_Trolley.transform.Translate(0, -TROLLEY_VELOCITY * Time.fixedDeltaTime, 0);
                counter+=1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                m_Trolley.transform.Translate(0, TROLLEY_VELOCITY * Time.fixedDeltaTime, 0);
                counter -=1;
            }
        }else if (counter == 0)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                m_Trolley.transform.Translate(0, -TROLLEY_VELOCITY * Time.fixedDeltaTime, 0);
                counter += 1;
            }
        }
        else if (counter == 1000f)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                m_Trolley.transform.Translate(0, TROLLEY_VELOCITY * Time.fixedDeltaTime, 0);
                counter -= 1;
            }
        }
        Debug.Log(counter);
    
        UpdateJoint();
        UpdateCable1();
        UpdateCable2();
    }
    void UpdateJoint()
    {
        var m_Joint1Limit = m_Joint1.linearLimit;
        var m_Joint2Limit = m_Joint2.linearLimit;

        if (Input.GetKey(KeyCode.Q))
        {
            FinalJointLimit = Mathf.Min(15f, m_Joint1Limit.limit + Time.fixedDeltaTime * 1f);
            m_Joint1Limit.limit = FinalJointLimit;
            m_Joint2Limit.limit = FinalJointLimit;
            m_Joint1.linearLimit = m_Joint1Limit;
            m_Joint2.linearLimit =  m_Joint2Limit;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            FinalJointLimit = Mathf.Max(1f, m_Joint1Limit.limit - Time.fixedDeltaTime * 1f);
            m_Joint1Limit.limit = FinalJointLimit;
            m_Joint2Limit.limit = FinalJointLimit;
            m_Joint1.linearLimit = m_Joint1Limit;
            m_Joint2.linearLimit = m_Joint2Limit;
        }
    }
    void UpdateCable1()
    {
        m_Cable1.SetPosition(0, m_Trolley.transform.TransformPoint(0, -0.0032f , -0.001f));
        m_Cable1.SetPosition(1, m_Joint1.connectedBody.transform.TransformPoint(0, -0.1f, -0.1f));
    }
    void UpdateCable2()
    {
        m_Cable2.SetPosition(0, m_Trolley.transform.TransformPoint(0, 0.0032f, -0.001f));
        m_Cable2.SetPosition(1, m_Joint1.connectedBody.transform.TransformPoint(0, -0.1f, 0.1f));
    }

}
