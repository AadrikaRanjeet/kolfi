using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthbar : MonoBehaviour
{
   Slider slider;
   void Start()
   {
    slider=GetComponent<Slider>();
   }
   public void SetmaxHealth(int maxHealth)
   {
    slider.maxValue= maxHealth;
    slider.value=maxHealth;
   }
   public void SetHealth(int Health)
   {
    slider.value=Health;
   }   
}
