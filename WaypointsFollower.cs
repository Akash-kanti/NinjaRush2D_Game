using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int curwpindex=0;
    
	[SerializeField] private float speed=2f;
    
   
    
    private void Update()
    {
    	if(Vector2.Distance(waypoints[curwpindex].transform.position, transform.position)<0.1f)
    	{
    		curwpindex++;
    		if(curwpindex>= waypoints.Length)
    		{
    			curwpindex=0;
			}
		}
		transform.position= Vector2.MoveTowards(transform.position, waypoints[curwpindex].transform.position, Time.deltaTime*speed);

    }
}
