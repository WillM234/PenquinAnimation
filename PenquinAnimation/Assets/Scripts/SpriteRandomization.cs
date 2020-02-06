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

public Text UIText;
public Slider footSlider;
public Slider beakSlider;
public Slider eyesSlider;

public CanvasGroup CustomizeCanvas;

public void ChangeFootSize()
{
float newFootValue = footSlider.value *2;
LeftFoot.transform.localScale = new Vector2(newFootValue, newFootValue);
RightFoot.transform.localScale = new Vector2(newFootValue, newFootValue);
Debug.Log(newFootValue);
}
public void ChangeBeakRotation()
{
 float newBeakAngle = (beakSlider.value - 0.5f) * 360;
 Beak.transform.rotation =  Quaternion.Euler(0f,0f, (newBeakAngle * 360)) ;//new Vector3(0,0,newBeakAngle);
 Debug.Log(newBeakAngle);
}
}
