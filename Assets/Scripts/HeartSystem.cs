using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public static HeartSystem instance;
    public int maxHealth = 5;
    public int currentHealth = 5;
    public GameObject heartPrefab;
    public Transform heartHolder;

    private GameObject[] hearts;

    void Awake()
    {
        instance=this;
    }
    private void Start()
    {
        hearts = new GameObject[maxHealth];
        for (int i = 0; i < maxHealth; i++)
        {
            hearts[i] = Instantiate(heartPrefab, heartHolder);
        }
        UpdateHearts();
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHearts();
        
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHearts();
        if(currentHealth==0)
        {
            GameManager.instance.EndGame();
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }
}


// public class HeartSystem : MonoBehaviour
// {
//     public static HeartSystem instance;

//     // public TextMeshProUGUI lifeCountText;
//     public List<GameObject> hearts = new List<GameObject>();
//     public GameObject prefab;
//     public int life;
//     public int maxHealth;
//     public Transform holder;

//     public void Awake()
//     {
//         instance = this;
//     }

//     private void Start()
//     {
//         life = maxHealth;
//         HeartSpawner();
//     }

//     public void HeartSpawner()
//     {
//         for (int i = 0; i < maxHealth; i++)
//         {
//             GameObject spawnedHeart = Instantiate(prefab, holder);
//             hearts.Add(spawnedHeart);
//             // prefab.gameObject.SetActive(true);
//         }
//     }

//     public void IncreaseHealth()
//     {
//         if (life == maxHealth)
//         {
//             Debug.Log("No Health Increase");
//         }
//         else
//         {
//             life++;
//             Debug.Log("Health Increasing");
//             // lifeCountText.text=life.ToString();
//             hearts[life - 1].gameObject.SetActive(true);
//         }
//     }

//     public void DecreaseHealth()
//     {
//         if (life == 0)
//         {
//             GameManager.instance.EndGame();
//             // lifeCountText.text=life.ToString();
//              hearts[life].gameObject.SetActive(false);
//         }
//         else
//         {
//             Debug.Log("Decrease Health");
//             // lifeCountText.text=life.ToString();
//             hearts[life - 1].gameObject.SetActive(false);
//         }
//         life--;
//     }
// }
