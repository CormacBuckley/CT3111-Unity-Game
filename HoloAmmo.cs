using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoloAmmo : MonoBehaviour {

    public GameObject pistol;

    public Text ammoText;

    void Awake()
    {
        ammoText = GetComponent<Text>();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ammoText.text = pistol.GetComponent<GunFire>().ammo.ToString();
	}
}
