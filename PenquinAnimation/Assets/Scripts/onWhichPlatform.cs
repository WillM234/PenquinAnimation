using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onWhichPlatform : MonoBehaviour
{
    DialogTrigger dialogTrigger;//reference to trigger script on the object
    public GameObject dialogPanel;//panel reference so that it can be turned on

    public bool onPlatform = false;//can be set from a movement script, i set from tag detection though 
    public bool beganDialog = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogTrigger = GetComponent<DialogTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
     if(onPlatform == true)
		{
            startTalking();
		}
    }
    void OnCollisionEnter2D(Collision2D other)
	{
        if(other.gameObject.tag == "Player")
		{
            onPlatform = true;
		}
	}
    void startTalking()
	{
        beganDialog = true;
        dialogPanel.SetActive(true);
        dialogTrigger.TriggerDialog();
	}
}
