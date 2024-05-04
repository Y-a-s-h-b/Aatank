using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsScore : MonoBehaviour
{
    public static int scoreObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore() 
    {
        scoreObject += 100;
    }   
    public void UpdateChild()
    {
        scoreObject += 250;
    }
   
}
