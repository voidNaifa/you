using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class you : MonoBehaviour
{

    public string world;
    public Animator youAnim;
    //float timer = 0f;
    void Start()
    {
        Cursor.visible = false;        
        youAnim.Play("you");

    }
    /*void Update()
    {
        timer += 1 * Time.deltaTime;
        if ( timer >= 3) {
            SceneManager.LoadScene (world);
        }
    }
    */

    public void Begin()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
