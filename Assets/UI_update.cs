using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_update : MonoBehaviour
{
    [SerializeField] GameObject CubeCount;


    void Update()
    {
        CubeCount.GetComponent<Text>().text = string.Format("you have achieve <color=yellow>{0}</color> cube!", Detected_cube.m_count); 
    }
}
