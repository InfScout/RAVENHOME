using System;
using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
   [SerializeField]  GameObject DeathMenu;
   [SerializeField]private GameObject player;
   [SerializeField] private Transform playerPosition;
   [SerializeField]public Transform spawnPoint;
   [SerializeField] private float spawnDelay = 2f;
   private static GameManager _instance;
   
   private void Start()
   {
      if (_instance == null)
      {
         _instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
      DeathMenu.SetActive(false);
   }

   public void spawnPlayer()
   {
      RespawnPlayer();
   }
   private void RespawnPlayer()
   {
      DeathMenu.SetActive(true);
      Invoke("PlayerDie", spawnDelay);
   }
   
   public static GameManager GetInstance()
   {
      return _instance;
   }
 
   private void PlayerDie()
   {
      player.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z );
      DeathMenu.SetActive(false);
   }
   
}
