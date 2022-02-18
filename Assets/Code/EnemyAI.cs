using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Self Navmesh Reference")]
    public NavMeshAgent agent;

    [Header("Player reference")]
    public GameObject player;

    void DrawPath()
    {
        var nav = GetComponent<NavMeshAgent>();
        if(nav == null || nav.path == null)
            return;
    
        var line = this.GetComponent<LineRenderer>();
        if(line == null)
        {
            line = this.gameObject.AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Sprites/Default")) {color = Color.yellow};
            line.startWidth =  0.5f;
            line.startColor = Color.red;
        }
    
        var path = nav.path;
    
        line.positionCount = path.corners.Length;
    
        for( int i = 0; i < path.corners.Length; i++ )
        {
            line.SetPosition( i, path.corners[ i ] );
        }

        /*
        Draws a yellow line from the center of the player to the clicked location with the code in the Update() below
        */
    }

    // Update is called once per frame
    void Update () 
    {

        agent.SetDestination(player.transform.position);

        //agent.SetDestination();
            
        DrawPath();

        /*
        Gets the mouse1 down to any location in screen space, 
        moves player (navmesh agent) to the clicked location on the navmesh surface
        then draws the line for player feedback
        */
        
    }
}
