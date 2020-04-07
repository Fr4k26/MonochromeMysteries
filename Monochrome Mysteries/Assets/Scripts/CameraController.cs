using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float captureDistance = 500;
    public GameObject cameraUI, textUI, rain;

    public Image bodyImage, paperboyImage, recieptImage, pinkImage, knifeImage, gunImage, bloodImage, femmeImage;

    public Text body, paperboy, reciept, pinkslip, knife, gun, blood, femme;
    private bool bodyFound, paperboyFound, recieptFound, pinkslipFound, knifeFound, gunFound, bloodFound, femmeFound = false;
    public AudioSource shutter;
    public AudioClip photo;

    public Dropdown Killerdropdown;
    public Dropdown Weapondropdown;
    public Dropdown Motivedropdown;

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
    private Texture2D femmeShotTexture;

    private bool uiEnable = false;
    public bool cameraLens = false;

    private bool pictureTaken = false;

    public List<string> killerOptions;
    public List<string> weaponOptions;
    public List<string> motiveOptions;

    public Camera camera;

    public GameObject playerObject;
    public PlayerController playerController;

    public GameObject winText;
    public Text evidenceFoundText; //The text that appears when you find a piece of evidence

    void Start()
    {
        playerController = playerObject.GetComponent<PlayerController>();
        killerOptions = new List<string>();
        weaponOptions = new List<string>();
        motiveOptions = new List<string>();

        if (cameraUI != null)
        {
            cameraUI.SetActive(false);
        }
        if (winText != null)
        {
            winText.SetActive(false);
        }
        Invoke("Rain", .1f); // rain method allows rain object to start as raining and going rather than a static image when started without the invoke
        uiEnable = false;
        journalUI.SetActive(false);

    }

    void AddKiller(string item)
    {
        if (!killerOptions.Contains(item))
        {
            killerOptions.Add(item);
            Killerdropdown.ClearOptions();
            Killerdropdown.AddOptions(killerOptions);
        }
    }

    void AddWeapon(string item)
    {
        if (!weaponOptions.Contains(item))
        {
            weaponOptions.Add(item);
            Weapondropdown.ClearOptions();
            Weapondropdown.AddOptions(weaponOptions);
        }
    }

    void AddMotive(string item)
    {
        if (!motiveOptions.Contains(item))
        {
            motiveOptions.Add(item);
            Motivedropdown.ClearOptions();
            Motivedropdown.AddOptions(motiveOptions);
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(1))//If you're pressing down the mouse
        {
            Zoom();//Go into camera mode
        }
        if (Input.GetMouseButtonDown(1))//If you *just* pressed down the mouse
        {
            rain.SetActive(true);
            if (cameraUI != null)//Turn on the camera UI
            {
                cameraUI.SetActive(true);
                cameraLens = true;
            }
            if (textUI != null)
            {
                textUI.SetActive(false);
            }
        }
        if (Input.GetMouseButtonUp(1))//If you let go of the mouse
        {
            rain.SetActive(false);
            if (cameraUI != null)//Reset everything
            {
                cameraUI.SetActive(false);
                cameraLens = false;
                camera.fieldOfView = 60;
            }
            if (cameraUI != null)
            {
                textUI.SetActive(true);
            }
        }
        if (Input.GetMouseButtonDown(2) && cameraLens) //If you scroll while you're in camera mode change the field of view
        {
            camera.fieldOfView -= 25;

            if (camera.fieldOfView < 10)
            {
                camera.fieldOfView = 60;

            }
        }
        //All Objectives True
        /*if (Input.GetKeyDown(KeyCode.F12))
        {
            AddKiller("Paperboy");
            AddKiller("Femme Fatale");
            AddKiller("Corpse");
            recieptBool = true;
            pinkslipBool = true;
            AddWeapon("Box Cutter");
            AddWeapon("Gun");
            bloodBool = true;
        }*/
            ;
        if (Input.GetKeyDown(KeyCode.Tab))//If you hit tab, open the journal
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
        //If you try to take a picture
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Mouse0) && pictureTaken == false)
        {
            //Shutter and Audio
            shutter = GetComponent<AudioSource>();
            shutter.PlayOneShot(photo);
            pictureTaken = true;
            StartCoroutine(nextPicture());//Allow another photo in 1 second

            //If you get a hit
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, captureDistance))
            {
                //Check all objectives
                print(hit.collider.gameObject.name);

                if(hit.collider.gameObject.GetComponent<AddingOptions>() != null)
                {
                    hit.collider.gameObject.GetComponent<AddingOptions>().AddOptionCam();
                }

                GameObject[] objectiveArray = GameObject.FindGameObjectsWithTag("Objective");

                foreach (GameObject obj in objectiveArray)//Check to see which Objective the hit is, before running FoundEvidence
                {
                    if (hit.collider.gameObject == obj)
                    {
                        name = obj.gameObject.name;
                        print("Object with tag: " + name + " has been captured");
                        if (name.Equals("Practice Body"))
                        {
                            FoundEvidence(bodyShotTexture, "Corpse", "Killer", bodyImage, "Corpse of Victim", body, bodyFound);
                            bodyFound = true;
                        }
                        else if (name.Equals("Paperboy"))
                        {
                            FoundEvidence(paperShotTexture, "Paperboy", "Killer", paperboyImage, "Paperboy", paperboy, paperboyFound);
                            paperboyFound = true;
                        }
                        else if (name.Equals("Practice Reciept"))
                        {
                            FoundEvidence(recieptShotTexture, "Reciept", "Motive", recieptImage, "Gun Purchase Reciept for Reggie", reciept, recieptFound);
                            recieptFound = true;
                        }
                        else if (name.Equals("Practice Pinkslip"))
                        {
                            FoundEvidence(pinkShotTexture, "Pinkslip", "Motive", pinkImage, "Pinkslip Firing Reggie", pinkslip, pinkslipFound);
                            pinkslipFound = true;
                        }
                        else if (name.Equals("Practice Knife"))
                        {
                            FoundEvidence(knifeShotTexture, "Box Cutter", "Weapon", knifeImage, "Box Cutter", knife, knifeFound);
                            knifeFound = true;
                        }
                        else if (name.Equals("Practice Gun"))
                        {
                            FoundEvidence(gunShotTexture, "Gun", "Weapon", gunImage, "Period Appropriate Firearm", gun, gunFound);
                            gunFound = true;
                        }
                        else if (name.Equals("Practice Bulletholes/Blood"))
                        {
                            FoundEvidence(bloodShotTexture, "Blood", "N/A", bloodImage, "Victim's Blood", blood, bloodFound);
                            bloodFound = true;
                        }
                        else if (name.Equals("Femme Fatale Character"))
                        {
                            FoundEvidence(femmeShotTexture, "Femme Fatale", "Character", femmeImage, "Woman in Red", femme, femmeFound);
                            femmeFound = true;
                        }
                    }
                }
            }
        }
    }

    //If you have found a valid evidence piece, input the appropriate Texture, Name of the evidence, Type, Image, what text displays on the screen after you photograph it, and the appropriate boolean
    void FoundEvidence(Texture2D evidenceTexture, string evidence, string evidenceType, Image evidenceImage, string evidenceTitle, Text journalEvidenceText, bool alreadyFound)
    {
        StartCoroutine(TakeScreenshot(evidenceTexture, evidenceImage));

        if(alreadyFound == true)//If you already found it
        {
            evidenceFoundText.text = "Already Found: " + evidenceTitle;//Tell the player it's already found
            StartCoroutine(EvidenceTextReset(evidenceTitle));
        }
        else//If they haven't found it before
        {
            if (evidenceType == "Weapon")//Add the evidence piece to the appropriate dropdown
            {
                AddWeapon(evidence);
            }
            else if (evidenceType == "Killer")
            {
                AddKiller(evidence);
            }
            else if (evidenceType == "Motive")
            {
                AddMotive(evidence);
            }
            else
            {
                //Evidence fits into no dropdown
            }

            evidenceFoundText.text = "Found: " + evidenceTitle;//Say that it's been found
            StartCoroutine(EvidenceTextReset(evidenceTitle));
            journalEvidenceText.text = evidenceTitle;
        }
    }

    //Save the picture
    IEnumerator TakeScreenshot(Texture2D evidenceTexture, Image evidenceImage)
    {
        if (evidenceTexture != null)//If the evidence piece already has a texture, get rid of it
        { evidenceTexture = null; }
        canvas.SetActive(false);
        cameraUI.SetActive(false);

        yield return new WaitForEndOfFrame();//Needs to be at the end of the frame or it doesn't remove the camera UI

        evidenceTexture = ScreenCapture.CaptureScreenshotAsTexture(); //Capture the screen as the evidenceTexture
        Rect rec = new Rect(0, 0, evidenceTexture.width, evidenceTexture.height);
        Sprite newShot = Sprite.Create(evidenceTexture, rec, new Vector2(0.5f, 0.5f));
        evidenceImage.GetComponent<Image>().sprite = newShot;

        canvas.SetActive(true);//Reset everything
        cameraUI.SetActive(true);
    }

    //If the title has been on the screen for 2 seconds, turn it off
    IEnumerator EvidenceTextReset(string evidenceTitle)
    {
        yield return new WaitForSeconds(2f);
        if ("Found: " + evidenceTitle == evidenceFoundText.text || "Already Found: " + evidenceTitle == evidenceFoundText.text)
        {
            evidenceFoundText.text = "";
        }
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