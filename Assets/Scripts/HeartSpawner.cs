using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    public int spawnProbability = 10;
   public GameObject heart;
//    public int firstValue = 25;
//    public int secondValue = 40;
    private void Start() 
    {
        ShowHeart();
    }

   public void ShowHeart()
   {
       int randomNum = Random.Range(0,100);
        
        if(randomNum<=spawnProbability)
        {
            heart.gameObject.SetActive(true);
        }
        // if(firstValue - secondValue)
        // {
        //     Random.Range(0,50);
        // }
   }    
}



//  public GameObject heartPrefab;
//     public float spawnInterval = 10f;

//     private float timer = 0.0f;

//     void Update()
//     {
//         timer += Time.deltaTime;
//         if (timer >= spawnInterval)
//         {
//             timer = 0.0f;
//             Vector3 position = new Vector3(0, 0, 0.0f);
//             Instantiate(heartPrefab, position, Quaternion.identity);
//         } 
//     }
    // void heartSpawn()
    // {
       
    // }