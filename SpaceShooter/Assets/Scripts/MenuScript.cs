using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    void Start()
    {
        Screen.SetResolution(Screen.currentResolution.height * 2 / 3,
                             Screen.currentResolution.height, true);
    }
    // Update is called once per frame
    void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Spaaaaace");
        }
	}
}
