using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{ 
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float offSet;

    private Vector2 startPosition;
    private float newPosition;
    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        newPosition= Mathf.Repeat(Time.time * -moveSpeed, offSet);
        transform.position = startPosition+Vector2.right*newPosition;
    }

}





/*{
    [Range(-1f,2f)] 
    public float scrollSpeed= 0.5f;
    private float offset;
    private Material mat;   
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset +=(Time.deltaTime*scrollSpeed)/10f;
        mat.SetTextureOffset("_MainTex",new Vector2(offset,0));
    }
}   */
