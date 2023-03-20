using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnterNewRoom : MonoBehaviour
{
    public GameObject teleportTo;
    public GameObject Player;
    //Gameobjects transform som man teleportar till
   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Player.transform.position = teleportTo.transform.position;
    }
}
