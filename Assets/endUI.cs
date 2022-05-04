using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endUI : MonoBehaviour
{
    public int cubecount;
    [SerializeField] GameObject CubeCount;
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    // Start is called before the first frame update
    void Start()
    {
        cubecount = PlayerPrefs.GetInt("CubeCount");
    }

    // Update is called once per frame
    void Update()
    {
        CubeCount.GetComponent<Text>().text = string.Format("You have achieve <color=yellow>{0}</color> cube!", cubecount);
    }
}
