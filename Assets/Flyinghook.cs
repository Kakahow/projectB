using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyinghook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    const float Move_speed = 2f;
    const float Attach_distance = 2f;

    GameObject m_DetectedObject;
    ConfigurableJoint m_JointForObject;
    ConfigurableJoint m_JointForObject2;
    [SerializeField] LineRenderer m_Cable;
    [SerializeField] LineRenderer m_Cable2;

    // void AttachOrDetachObject(){
    //     if(m_JointForObject == null){
    //         if(m_DetectedObject != null){
    //             var joint = this.gameObject.AddComponent <ConfigurableJoint> ();
    //             joint.xMotion = ConfigurableJointMotion.Limited;
    //             joint.yMotion = ConfigurableJointMotion.Limited;
    //             joint.zMotion = ConfigurableJointMotion.Limited;
    //             joint.angularXMotion = ConfigurableJointMotion.Free;
    //             joint.angularYMotion = ConfigurableJointMotion.Free;
    //             joint.angularZMotion = ConfigurableJointMotion.Free;

    //             var jointlimit = joint.linearLimit;
    //             jointlimit.limit = 4;

    //             joint.linearLimit = jointlimit;

    //             joint.autoConfigureConnectedAnchor = false;
    //             joint.connectedAnchor = new Vector3 (0f,0.5f,0f);
    //             joint.anchor = new Vector3(0f, -2f, 0f);

    //             joint.connectedBody = m_DetectedObject.GetComponent<Rigidbody>();
    //             m_JointForObject = joint;

    //             m_DetectedObject.GetComponent<MeshRenderer>().material.color = Color.red;
    //             m_DetectedObject = null;
    //         }
    //     }else{

    //         m_JointForObject.connectedBody.GetComponent<MeshRenderer>().material.color = Color.white;

    //         GameObject.Destroy(m_JointForObject);

    //         m_JointForObject = null;
    //     }
    // }


  void AttachOrDetachObject(){
        if(m_JointForObject == null){
            if(m_DetectedObject != null){
                var joint1 = this.gameObject.AddComponent <ConfigurableJoint> ();
                joint1.xMotion = ConfigurableJointMotion.Limited;
                joint1.yMotion = ConfigurableJointMotion.Limited;
                joint1.zMotion = ConfigurableJointMotion.Limited;
                joint1.angularXMotion = ConfigurableJointMotion.Free;
                joint1.angularYMotion = ConfigurableJointMotion.Free;
                joint1.angularZMotion = ConfigurableJointMotion.Free;

                var jointlimit = joint1.linearLimit;
                jointlimit.limit = 2;

                joint1.linearLimit = jointlimit;

                joint1.autoConfigureConnectedAnchor = false;
                joint1.connectedAnchor = new Vector3 (0.5f,0.5f,0.5f);
                joint1.anchor = new Vector3(0f, -0.5f, 0f);
                

                joint1.connectedBody = m_DetectedObject.GetComponent<Rigidbody>();
                m_JointForObject = joint1;

                var joint2 = this.gameObject.AddComponent <ConfigurableJoint> ();
                joint2.xMotion = ConfigurableJointMotion.Limited;
                joint2.yMotion = ConfigurableJointMotion.Limited;
                joint2.zMotion = ConfigurableJointMotion.Limited;
                joint2.angularXMotion = ConfigurableJointMotion.Free;
                joint2.angularYMotion = ConfigurableJointMotion.Free;
                joint2.angularZMotion = ConfigurableJointMotion.Free;

                var jointlimit2 = joint2.linearLimit;
                jointlimit2.limit = 2;

                joint2.linearLimit = jointlimit2;

                joint2.autoConfigureConnectedAnchor = false;
                joint2.connectedAnchor = new Vector3 (-0.5f,0.5f,-0.5f);
                joint2.anchor = new Vector3(0f, -0.5f, 0f);

                joint2.connectedBody = m_DetectedObject.GetComponent<Rigidbody>();
                m_JointForObject2 = joint2;

                m_DetectedObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                m_DetectedObject = null;

            }
        }else{

            m_JointForObject.connectedBody.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            GameObject.Destroy(m_JointForObject);
            GameObject.Destroy(m_JointForObject2);
            
        }
    }


    void DetectObjects(){

        Ray ray = new Ray (this.transform.position, Vector3.down);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Attach_distance)){
            if(m_DetectedObject == hit.collider.gameObject){
                return;
            }
            RecoverDetectedObject();
            MeshRenderer renderer = hit.collider.transform.GetChild(0).gameObject.GetComponent <MeshRenderer> ();
            if(renderer != null){
                renderer.material.color = Color.yellow;

                m_DetectedObject = hit.collider.gameObject;
            }
        }else{
            RecoverDetectedObject();
        }
    }

    void RecoverDetectedObject(){
        if(m_DetectedObject != null){
            m_DetectedObject.transform.GetChild(0).gameObject.GetComponent <MeshRenderer> ().material.color = Color.white;
            m_DetectedObject = null;
        }
    }

    // void UpdateCable(){
    //     m_Cable.enabled = m_JointForObject != null;
    //     if(m_Cable.enabled){
    //         m_Cable.SetPosition(0, this.transform.position);
    //         m_Cable.SetPosition(1, m_JointForObject.connectedBody.transform.position);
    //     }
    // }

    //     void UpdateCable(){
    //     m_Cable.enabled = m_JointForObject != null;
    //     m_Cable2.enabled = m_JointForObject2 != null;

    //     Vector3 worpos1;
    //     Vector3 worpos2;
    //     Vector3 rightline = new Vector3(0.5f,0.5f,0.5f);
    //     Vector3 leftline = new Vector3(-0.5f,0.5f,-0.5f);
        
    //     if(m_Cable.enabled){
    //         Vector3 LinePosition1 = m_JointForObject.connectedBody.transform.GetChild(0).gameObject.transform.localPosition;
    //         LinePosition1 += rightline;
    //         worpos1 = transform.TransformPoint(LinePosition1);
    //         m_Cable.SetPosition(0, this.transform.position);
    //         m_Cable.SetPosition(1, worpos1);
    //         Debug.Log(m_JointForObject.connectedBody.transform.GetChild(0).gameObject.transform.localPosition + "local");
    //         Debug.Log(worpos1 + "world");
    //     }
    //     if(m_Cable2.enabled){
    //         Vector3 LinePosition2 = m_JointForObject2.connectedBody.transform.GetChild(0).gameObject.transform.localPosition;
    //         LinePosition2 += leftline;
    //         worpos2 = transform.TransformPoint(LinePosition2);
    //         m_Cable2.SetPosition(0, this.transform.position);
    //         m_Cable2.SetPosition(1, worpos2);
    //     }
    // }

            void UpdateCable(){
        m_Cable.enabled = m_JointForObject != null;
        m_Cable2.enabled = m_JointForObject2 != null;

        Vector3 worpos1;
        Vector3 worpos2;
        Vector3 rightline = new Vector3(0.5f,0.5f,0.5f);
        Vector3 leftline = new Vector3(-0.5f,0.5f,-0.5f);
        
        if(m_Cable.enabled){
            Vector3 LinePosition1 = m_JointForObject.connectedBody.transform.GetChild(0).transform.localPosition;
            LinePosition1 += rightline;
            worpos1 = m_JointForObject.connectedBody.transform.TransformPoint(LinePosition1);
            m_Cable.SetPosition(0, this.transform.position);
            m_Cable.SetPosition(1, worpos1);
            Debug.Log(m_JointForObject.connectedBody.transform.GetChild(0).transform.localPosition + "local");
            Debug.Log(worpos1 + "world");
        }
        if(m_Cable2.enabled){
            Vector3 LinePosition2 = m_JointForObject2.connectedBody.transform.GetChild(0).gameObject.transform.localPosition;
            LinePosition2 += leftline;
            worpos2 = m_JointForObject2.connectedBody.transform.TransformPoint(LinePosition2);
            m_Cable2.SetPosition(0, this.transform.position);
            m_Cable2.SetPosition(1, worpos2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // key control
        if(Input.GetKey(KeyCode.DownArrow)){
            this.transform.Translate(0,0, Move_speed * Time.deltaTime);
        }else if(Input.GetKey(KeyCode.UpArrow)){
            this.transform.Translate(0, 0, -Move_speed * Time.deltaTime);
        }else if(Input.GetKey(KeyCode.LeftArrow)){
            this.transform.Translate(Move_speed * Time.deltaTime, 0, 0);
        }else if(Input.GetKey(KeyCode.RightArrow)){
            this.transform.Translate(-Move_speed * Time.deltaTime, 0, 0);
        }else if(Input.GetKey(KeyCode.Q)){
            this.transform.Translate(0, Move_speed * Time.deltaTime, 0);
        }else if(Input.GetKey(KeyCode.E)){
            this.transform.Translate(0, -Move_speed *Time.deltaTime, 0);
        }

        // endregion
        if(m_JointForObject == null){
            DetectObjects();
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            AttachOrDetachObject();
        }

        UpdateCable();
        
    }
}
