using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        new GridSystem(10, 10,2f);
        Debug.Log(new GridPosition(5,7));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
