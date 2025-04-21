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
   public static GameManager GetInstance()
   {
      return _instance;
   }
   public void spawnPlayer()
   {
      RespawnPlayer();
   }
   private void RespawnPlayer()
   {
      AUDIO.GetInstance().PlaySound(AUDIO.GetInstance().death);
      DeathMenu.SetActive(true);
      Invoke("PlayerDie", spawnDelay);
   }
   
 
   private void PlayerDie()
   {
      player.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z );
      DeathMenu.SetActive(false);
   }
   
}
