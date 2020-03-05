using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
	public float captureDistance = 500;
	public GameObject cameraUI, textUI, rain;

    public Image bodyImage, paperboyImage, recieptImage, pinkImage, knifeImage, gunImage, bloodImage;

    public Text body, paperboy, reciept, pinkslip, knife, gun, blood;
    public AudioSource shutter;
    public AudioClip photo;

    public GameObject canvas;
    public GameObject journalUI;

    private Flash flash;
    private Texture2D bodyShotTexture;
    private Texture2D paperShotTexture;
    private Texture2D recieptShotTexture;
    private Texture2D pinkShotTexture;
    private Texture2D knifeShotTexture;
    private Texture2D gunShotTexture;
    private Texture2D bloodShotTexture;

    private bool bodyBool = false;
    private bool paperboyBool = false;
    private bool recieptBool = false;
    private bool pinkslipBool = false;
    private bool knifeBool = false;
    private bool gunBool = false;
    private bool bloodBool = false;
    private bool uiEnable = false;

    private bool pictureTaken = false;

    public Camera camera;

    public GameObject playerObject;
    public PlayerController playerController;

    public GameObject winText;

    void Start()
    {
        playerController = playerObject.GetComponent<PlayerController>();

        if (cameraUI != null)
        {
            cameraUI.SetActive(false);
        }
        if (winText != null)
        {
            winText.SetActive(false);
        }
        Invoke("Rain",.1f); // rain method allows rain object to start as raining and going rather than a static image when started without the invoke
        uiEnable = false;
        journalUI.SetActive(false);

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

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (journalUI != null)
            {
                if (uiEnable == false)
                {
                    playerController.canmove = false;
                    journalUI.SetActive(true);
                    uiEnable = true;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else if (uiEnable == true)
                {
                    playerController.canmove = true;
                    journalUI.SetActive(false);
                    uiEnable = false;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
    }

	private void Zoom()
	{
        int oldMask = camera.cullingMask;
		RaycastHit hit;
		if (Input.GetKeyDown(KeyCode.LeftShift) && pictureTaken == false)
		{
			//test comment
			shutter = GetComponent<AudioSource>();
            shutter.PlayOneShot(photo);
            pictureTaken = true;
            StartCoroutine(nextPicture());

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

                            canvas.SetActive(false);
                            cameraUI.SetActive(false);
                            WaitBeforeScreenshotRoutine();
                            body.GetComponent<Text>().color = Color.green;
                            bodyBool = true;
                            bodyShotTexture = ScreenCapture.CaptureScreenshotAsTexture();
                            Rect rec = new Rect(0, 0, bodyShotTexture.width, bodyShotTexture.height);
                            Sprite bodyshot = Sprite.Create(bodyShotTexture, rec, new Vector2(0.5f, 0.5f));
                            bodyImage.GetComponent<Image>().sprite = bodyshot;
                            StartCoroutine(WaitRoutine());

                        }
                        else if (name.Equals("Paperboy"))
                        {
                            if (paperShotTexture != null)
                            { paperShotTexture = null; }

                            canvas.SetActive(false);
                            cameraUI.SetActive(false);
                            WaitBeforeScreenshotRoutine();
                            paperboy.GetComponent<Text>().color = Color.green;
                            paperboyBool = true;
                            paperShotTexture = ScreenCapture.CaptureScreenshotAsTexture();
                            Rect rec = new Rect(0, 0, paperShotTexture.width, paperShotTexture.height);
                            Sprite papershot = Sprite.Create(paperShotTexture, rec, new Vector2(0.5f, 0.5f));
                            paperboyImage.GetComponent<Image>().sprite = papershot;
                            StartCoroutine(WaitRoutine());
                        }
                        else if (name.Equals("Practice Reciept"))
                        {
                            if (recieptShotTexture != null)
                            { bodyShotTexture = null; }

                            canvas.SetActive(false);
                            cameraUI.SetActive(false);
                            WaitBeforeScreenshotRoutine();
                            reciept.GetComponent<Text>().color = Color.green;
                            recieptBool = true;
                            recieptShotTexture = ScreenCapture.CaptureScreenshotAsTexture();
                            Rect rec = new Rect(0, 0, recieptShotTexture.width, recieptShotTexture.height);
                            Sprite recieptshot = Sprite.Create(recieptShotTexture, rec, new Vector2(0.5f, 0.5f));
                            recieptImage.GetComponent<Image>().sprite = recieptshot;
                            StartCoroutine(WaitRoutine());
                        }
                        else if (name.Equals("Practice Pinkslip"))
                        {
                            if (pinkShotTexture != null)
                            { pinkShotTexture = null; }

                            canvas.SetActive(false);
                            cameraUI.SetActive(false);
                            WaitBeforeScreenshotRoutine();
                            pinkslip.GetComponent<Text>().color = Color.green;
                            pinkslipBool = true;
                            pinkShotTexture = ScreenCapture.CaptureScreenshotAsTexture();
                            Rect rec = new Rect(0, 0, pinkShotTexture.width, pinkShotTexture.height);
                            Sprite pinkshot = Sprite.Create(pinkShotTexture, rec, new Vector2(0.5f, 0.5f));
                            pinkImage.GetComponent<Image>().sprite = pinkshot;
                            StartCoroutine(WaitRoutine());
                        }
                        else if (name.Equals("Practice Knife"))
                        {
                            if (knifeShotTexture != null)
                            { knifeShotTexture = null; }

                            canvas.SetActive(false);
                            cameraUI.SetActive(false);
                            WaitBeforeScreenshotRoutine();
                            knife.GetComponent<Text>().color = Color.green;
                            knifeBool = true;
                            knifeShotTexture = ScreenCapture.CaptureScreenshotAsTexture();
                            Rect rec = new Rect(0, 0, knifeShotTexture.width, knifeShotTexture.height);
                            Sprite knifeshot = Sprite.Create(knifeShotTexture, rec, new Vector2(0.5f, 0.5f));
                            knifeImage.GetComponent<Image>().sprite = knifeshot;
                            StartCoroutine(WaitRoutine());
                        }
                        else if (name.Equals("Practice Gun"))
                        {
                            if (gunShotTexture != null)
                            { gunShotTexture = null; }

                            canvas.SetActive(false);
                            cameraUI.SetActive(false);
                            WaitBeforeScreenshotRoutine();
                            gun.GetComponent<Text>().color = Color.green;
                            gunBool = true;
                            gunShotTexture = ScreenCapture.CaptureScreenshotAsTexture();
                            Rect rec = new Rect(0, 0, gunShotTexture.width, gunShotTexture.height);
                            Sprite gunshot = Sprite.Create(gunShotTexture, rec, new Vector2(0.5f, 0.5f));
                            gunImage.GetComponent<Image>().sprite = gunshot;
                            StartCoroutine(WaitRoutine());
                        }
                        else if (name.Equals("Practice Bulletholes/Blood"))
                        {
                            if (bloodShotTexture != null)
                            { bloodShotTexture = null; }

                            canvas.SetActive(false);
                            cameraUI.SetActive(false);
                            WaitBeforeScreenshotRoutine();
                            blood.GetComponent<Text>().color = Color.green;
                            bloodBool = true;
                            bloodShotTexture = ScreenCapture.CaptureScreenshotAsTexture();
                            Rect rec = new Rect(0, 0, bloodShotTexture.width, bloodShotTexture.height);
                            Sprite bloodshot = Sprite.Create(bloodShotTexture, rec, new Vector2(0.5f, 0.5f));
                            bloodImage.GetComponent<Image>().sprite = bloodshot;
                            StartCoroutine(WaitRoutine());
                        }
                    }
                }
			}
		}
		

	}

    IEnumerator WaitRoutine()
    {

        yield return new WaitForSeconds(0.1f);

        canvas.SetActive(true);
        cameraUI.SetActive(true);
    }

    IEnumerator WaitBeforeScreenshotRoutine()
    {
        yield return new WaitForSeconds(0.1f);
    }


    IEnumerator nextPicture()
    {
        yield return new WaitForSeconds(0.706f);
        pictureTaken = false;
    }

    void Rain()
	{
		rain.SetActive(false);

	}

}