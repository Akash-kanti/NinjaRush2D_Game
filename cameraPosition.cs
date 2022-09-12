using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPosition : MonoBehaviour
{
    [SerializeField] private Transform frog;

    // Update is called once per frame
    void Update()
    {
	transform.position = new Vector3((frog.position.x + 4), frog.position.y, transform.position.z);        
    }
}
