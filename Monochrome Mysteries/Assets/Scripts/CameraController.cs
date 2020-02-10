﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
	public float captureDistance = 500;
	public GameObject cameraUI, textUI, rain;

    public Image test;

    public Text body, paperboy, reciept, pinkslip, knife, gun, blood;
    public AudioSource shutter;

	private Flash flash;
    public Texture2D bodyShotTexture;
    public Texture2D paperShotTexture;
    public Texture2D recieptShotTexture;
    public Texture2D pinkShotTexture;
    public Texture2D knifeShotTexture;
    public Texture2D gunShotTexture;
    public Texture2D bloodShotTexture;

    private bool bodyBool = false;
    private bool paperboyBool = false;
    private bool recieptBool = false;
    private bool pinkslipBool = false;
    private bool knifeBool = false;
    private bool gunBool = false;
    private bool bloodBool = false;

    public GameObject winText;

    void Start()
    {
        if (cameraUI != null)
        {
            cameraUI.SetActive(false);
        }
        if (winText != null)
        {
            winText.SetActive(false);
        }
        Invoke("Rain",.1f); // rain method allows rain object to start as raining and going rather than a static image when started without the invoke




	}

	void Update()
    {
		if(Input.GetMouseButton(1))
		{
			Zoom();			
		}
		if (Input.GetMouseButtonDown(1))
        {
			rain.SetActive(true);
            if (cameraUI != null)
            {
                cameraUI.SetActive(true);
            }
            if (textUI != null)
            {
                textUI.SetActive(false);
            }
		}
		if (Input.GetMouseButtonUp(1))
        {
			rain.SetActive(false);
            if (cameraUI != null)
            {
                cameraUI.SetActive(false);
            }
            if (cameraUI != null)
            {
                textUI.SetActive(true);
            }
        }

    }

	private void Zoom()
	{
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0))
		{
			//test comment
			shutter = GetComponent<AudioSource>();
			shutter.Play(0);
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, captureDistance))
			{
                print(hit.collider.gameObject.name);
                GameObject [] objectiveArray = GameObject.FindGameObjectsWithTag("Objective");

                foreach (GameObject obj in objectiveArray)
                {
                    if (hit.collider.gameObject == obj)
                    {
                        name = obj.gameObject.name;
                        print("Object with tag: " + name + " has been captured");
                        if (name.Equals("Practice Body"))
                        {
                            if (bodyShotTexture != null)
                            { bodyShotTexture = null; }

                            body.GetComponent<Text>().color = Color.green;
                            bodyBool = true;
                            bodyShotTexture = ScreenCapture.CaptureScreenshotAsTexture();
                            Rect rec = new Rect(0, 0, bodyShotTexture.width, bodyShotTexture.height);
                            Sprite bodyshot = Sprite.Create(bodyShotTexture, rec, new Vector2(0.5f, 0.5f));
                            test.GetComponent<Image>().sprite = bodyshot;
                        }
                        else if (name.Equals("Practice Paperboy"))
                        {
                            if (paperShotTexture != null)
                            { paperShotTexture = null; }

                            paperboy.GetComponent<Text>().color = Color.green;
                            paperboyBool = true;
                            paperShotTexture = ScreenCapture.CaptureScreenshotAsTexture();
                            Rect rec = new Rect(0, 0, paperShotTexture.width, paperShotTexture.height);
                            Sprite papershot = Sprite.Create(paperShotTexture, rec, new Vector2(0.5f, 0.5f));
                            test.GetComponent<Image>().sprite = papershot;
                        }
                        else if (name.Equals("Practice Reciept"))
                        {
                            if (recieptShotTexture != null)
                            { bodyShotTexture = null; }

                            reciept.GetComponent<Text>().color = Color.green;
                            recieptBool = true;
                            recieptShotTexture = ScreenCapture.CaptureScreenshotAsTexture();
                            Rect rec = new Rect(0, 0, recieptShotTexture.width, recieptShotTexture.height);
                            Sprite recieptshot = Sprite.Create(recieptShotTexture, rec, new Vector2(0.5f, 0.5f));
                            test.GetComponent<Image>().sprite = recieptshot;
                        }
                        else if (name.Equals("Practice Pinkslip"))
                        {
                            if (pinkShotTexture != null)
                            { pinkShotTexture = null; }

                            pinkslip.GetComponent<Text>().color = Color.green;
                            pinkslipBool = true;
                            pinkShotTexture = ScreenCapture.CaptureScreenshotAsTexture();
                            Rect rec = new Rect(0, 0, pinkShotTexture.width, pinkShotTexture.height);
                            Sprite pinkshot = Sprite.Create(pinkShotTexture, rec, new Vector2(0.5f, 0.5f));
                            test.GetComponent<Image>().sprite = pinkshot;
                        }
                        else if (name.Equals("Practice Knife"))
                        {
                            if (knifeShotTexture != null)
                            { knifeShotTexture = null; }

                            knife.GetComponent<Text>().color = Color.green;
                            knifeBool = true;
                            knifeShotTexture = ScreenCapture.CaptureScreenshotAsTexture();
                            Rect rec = new Rect(0, 0, knifeShotTexture.width, knifeShotTexture.height);
                            Sprite knifeshot = Sprite.Create(knifeShotTexture, rec, new Vector2(0.5f, 0.5f));
                            test.GetComponent<Image>().sprite = knifeshot;
                        }
                        else if (name.Equals("Practice Gun"))
                        {
                            if (gunShotTexture != null)
                            { gunShotTexture = null; }

                            gun.GetComponent<Text>().color = Color.green;
                            gunBool = true;
                            gunShotTexture = ScreenCapture.CaptureScreenshotAsTexture();
                            Rect rec = new Rect(0, 0, gunShotTexture.width, gunShotTexture.height);
                            Sprite gunshot = Sprite.Create(gunShotTexture, rec, new Vector2(0.5f, 0.5f));
                            test.GetComponent<Image>().sprite = gunshot;
                        }
                        else if (name.Equals("Practice Bulletholes/Blood"))
                        {
                            if (bloodShotTexture != null)
                            { bloodShotTexture = null; }

                            blood.GetComponent<Text>().color = Color.green;
                            bloodBool = true;
                            bloodShotTexture = ScreenCapture.CaptureScreenshotAsTexture();
                            Rect rec = new Rect(0, 0, bloodShotTexture.width, bloodShotTexture.height);
                            Sprite bloodshot = Sprite.Create(bloodShotTexture, rec, new Vector2(0.5f, 0.5f));
                            test.GetComponent<Image>().sprite = bloodshot;
                        }
                    }
                }
			}
		}
		

	}

	void Rain()
	{
		rain.SetActive(false);

	}

}