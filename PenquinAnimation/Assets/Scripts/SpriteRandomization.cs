using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteRandomization : MonoBehaviour
{
public GameObject LeftFoot;
public GameObject RightFoot;
public GameObject RightEye;
public GameObject LeftEye;
public GameObject Beak;
public GameObject LeftWing;
public GameObject RightWing;

public Text UIText;
public Slider footSlider;
public Slider beakSlider;
public Slider eyesSlider;
public Slider wingSlider;

public CanvasGroup CustomizeCanvas;

public void ChangeFootSize()
{
float newFootValue = footSlider.value *2;
LeftFoot.transform.localScale = new Vector2(newFootValue, newFootValue);
RightFoot.transform.localScale = new Vector2(newFootValue, newFootValue);
Debug.Log(newFootValue);
}
/*public void ChangeBeakRotation()
{
 float newBeakAngle = (beakSlider.value - 0.5f) * 360;
 Beak.transform.rotation =  new Quaternion(0,0,1, newBeakAngle)  ;//new Vector3(0,0,newBeakAngle);
 Debug.Log(newBeakAngle);
}*/
public void ChangeBeakSize()
	{
        float newBeakValue = beakSlider.value * 2;

        Beak.transform.localScale = new Vector2(newBeakValue, newBeakValue);
        Debug.Log(newBeakValue);
	}
public void ChangeEyeSize()
	{
        float newEyeValue = eyesSlider.value * 2;

        RightEye.transform.localScale = new Vector2(newEyeValue, newEyeValue);
        LeftEye.transform.localScale = new Vector2(newEyeValue, newEyeValue);
        Debug.Log(newEyeValue);
    }
public void ChangeWingSize()
	{
        float newWingValue = wingSlider.value * 2;

        LeftWing.transform.localScale = new Vector2(newWingValue, newWingValue);
        RightWing.transform.localScale = new Vector2(newWingValue, newWingValue);
        Debug.Log(newWingValue);
	}
}
