﻿using UnityEngine;
using System.Collections;

public class bubble : MonoBehaviour {

    bool seen = false;
    Renderer rend;
    public int type = 1;
    float timer = 3.0f;
    GameObject pl;
	private AudioSource audio;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
		audio = gameObject.GetComponent<AudioSource> ();
 
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (rend.isVisible)
            seen = true;

        if (seen && !rend.isVisible) {
			audio.Play ();
			Destroy (gameObject);
		}

		if (timer <= 0) {
			audio.Play ();
			Destroy(gameObject);
		}

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag != "Player" && c.collider.tag != "bubblebox") {
			audio.Play ();
			Destroy (gameObject);
		}
        else if (c.collider.tag == "Player" || c.collider.tag == "bubblebox")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), c.gameObject.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), c.gameObject.GetComponent<CircleCollider2D>());
        }
    }
}
