using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(GameManager.instance.currentCharacter.Character,transform.position,Quaternion.identity);
    }

}
