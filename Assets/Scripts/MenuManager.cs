using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
     public static MenuManager Instance;
    
    void Awake()
{
    //input = GameObject.Find("InputField").GetComponent<InputField>();
    
    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);
   
   
} 
// functional for button "Start" - starting game.
 public void StartNew()
    {
        
        SceneManager.LoadScene(0);
       
    }


    }