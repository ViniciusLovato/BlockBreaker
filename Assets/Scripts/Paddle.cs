using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float minimumXClamp = 1f; 
    [SerializeField] private float maximumXClamp = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var newXPosition = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        var newXClampedPosition = Mathf.Clamp(newXPosition, minimumXClamp, maximumXClamp);
        
        transform.position = new Vector2(newXClampedPosition, transform.position.y);
    }
}
