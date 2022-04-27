using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detected_cube : MonoBehaviour
{
    [SerializeField] GameObject first_cube;
    GameObject top_cube = null;
    static public int m_count = 0;

    void first_cube_detect(){
        Debug.Log("first_cube_detect has been called");
        Ray ray = new Ray (first_cube.transform.position, new Vector3(0,1,0));

        RaycastHit raycastResult;

        if(Physics.Raycast (ray, out raycastResult, 0.6f)){
            Debug.Log("fjkldfsfsalfjlsaj");
            MeshRenderer renderer = raycastResult.collider.transform.GetChild(0).GetComponent<MeshRenderer>();

            if(renderer != null){
                renderer.material.color = Color.red;
                top_cube = raycastResult.collider.gameObject;

                m_count += 1;
                Debug.Log(string.Format("you have achieve <color=yellow>{0}</color> cube!",m_count));  
            }
        }
        
    }

    void top_cube_detect(){
        
        Ray ray = new Ray (top_cube.transform.position , new Vector3(0,1,0));

        RaycastHit raycastResult;

        if(Physics.Raycast (ray, out raycastResult, 0.5f)){
              
            MeshRenderer renderer = raycastResult.collider.transform.GetChild(0).GetComponent<MeshRenderer>();

            if(renderer != null){
                renderer.material.color = Color.red;
                top_cube = raycastResult.collider.gameObject;

                m_count += 1;
                Debug.Log(string.Format("you have achieve <color=yellow>{0}</color> cube!",m_count));  
            }
        }
    }

    public int check1 = 0;

    void first_cube_detect_conti(){
        if(check1 == 0){
            Ray ray = new Ray (first_cube.transform.position, new Vector3(0,1,0));

            RaycastHit raycastResult;

            if(Physics.Raycast (ray, out raycastResult, 0.5f)){
                Invoke("first_cube_detect",1f);
                check1 = 1;
            }
        }
        
    }

    void top_cube_detect_conti(){
        
        Ray ray = new Ray (top_cube.transform.position, new Vector3(0,1,0));

        RaycastHit raycastResult;

        if(Physics.Raycast (ray, out raycastResult, 0.5f)){
            Invoke("top_cube_detect",1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(top_cube == null){
            first_cube_detect_conti();
        }else{
            top_cube_detect_conti();
        }
    }
}
