using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    GameObject player; 
     void Start()
    {
        player = Managers.Resource.Instantiate("Player"); 

        // Managers.Resource.Destroy(player); 

        Destroy(player, 3.0f);
    }
}
