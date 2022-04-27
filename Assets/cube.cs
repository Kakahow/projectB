using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.localPosition + "local");
        var wor = transform.TransformPoint(this.transform.localPosition);
        Debug.Log(this.transform.position+ "world1");
        Debug.Log(wor + "world2");
    }
}
