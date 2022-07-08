using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class you : MonoBehaviour
{

    public string world;
    float timer = 0f;
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if ( timer >= 3) {
            SceneManager.LoadScene (world);
        }
    }
}
