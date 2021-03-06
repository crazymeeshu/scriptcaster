﻿using UnityEngine;
using System.Collections;

public class Boss1_Manager : MonoBehaviour {

    public GameObject healthbar;
    public float health; //base value 150
    public float maxhealth;
    public bool stunned;
    public bool isattacking;
    public bool canbreakwall;
    public bool attackStarted;
    

    void Start(){
        maxhealth = 150f;
        health = 150f;
        stunned = false;
        canbreakwall = false;
        attackStarted = false;
    }
    
    void Update(){
        if (health <= 0){
            Destroy(GameObject.Find("Boss1"));
			StartCoroutine(Win ());
        }
        
        SetHealth(health/maxhealth);
    }
    
    void SetHealth(float newhealth){
        if(healthbar != null){
            healthbar.transform.localScale = new Vector3(newhealth, healthbar.transform.localScale.y, healthbar.transform.localScale.x);
        }
    }

	IEnumerator Win()
	{
		Debug.Log("Victory!");
		yield return new WaitForSeconds(1.0f);
		Application.LoadLevel ("win");
	}
}
