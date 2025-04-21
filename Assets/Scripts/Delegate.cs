using UnityEngine;
using System;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class Delegate : MonoBehaviour
{
   private Func<int, int, int> mathFunction;
   private Predicate<int> HealthCheck;
   
   void Start()
   {
      
      HealthCheck = currentHealth => currentHealth <= 0 ;
      
      int randomSelect = Random.Range(0, 2);

      mathFunction = randomSelect == 0 ? Addition : Subtraction;
      
      int result = mathFunction(10, 20);
      
   }

   bool isDead(int Health)
   {
      return Health <= 0;
   }
   
   int Addition(int a, int b)
   {
      return a + b;
   }

   int Subtraction(int a, int b)
   {
      return a - b;
   }
}
