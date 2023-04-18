using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    //public float spawnRate =2;
    //private float timer=0;
    //Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchPipe",0f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
      
        
    }
    void LaunchPipe()
    {
        
    GameObject spawnPipe=   Instantiate(pipe,Vector3.zero,Quaternion.identity);
    spawnPipe.transform.localPosition  = new Vector3(2,Random.Range(-1f, 2.5f),0);
    
         
    }
}
