
/************************************************************************************************
// File Name:   CameraController.cs
// Authors:     Jamey Colleen (40%), David Suriano (50%), and Jake Hyland (10%)
// Description: Contains a significant number of referenced images, audio, textures, and related
//              variables necessary to allow the player to use the camera and all its features,
//              as well as the journal. Written originally by Jamey, then refactored by David
//              and updated considerably. Audio functionality added by Jake.
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float captureDistance = 500;
    public GameObject cameraUI, textUI, rain;

    public Image bodyImage, paperboyImage, blackmailImage, cardImage, briefcaseImage, tommygunImage, gunImage, bloodImage, femmeImage, mobImage, businessImage, tommygunHolesImage, deadCameraImage;

    public Text body, paperboy, blackmail, card, briefcase, tommygun, gun, blood, femme, mob, business, tommygunHoles, deadCamera;
    private bool bodyFound, paperboyFound, blackmailFound, cardFound, briefcaseFound, tommygunFound, gunFound, bloodFound, femmeFound, mobFound, businessFound, tommygunHolesFound, deadCameraFound = false;
    public AudioSource shutter;
    public AudioClip photo;
    public AudioClip[] journalToggle;

    public Dropdown Killerdropdown;
    public Dropdown Weapondropdown;
    public Dropdown Motivedropdown;

    public GameObject canvas;
    public GameObject journalUI;
    public GameObject optionsUI;

    private Texture2D bodyShotTexture;
    private Texture2D paperShotTexture;
    private Texture2D blackmailShotTexture;
    private Texture2D cardShotTexture;
    private Texture2D briefcaseShotTexture;
    private Texture2D tommyShotTexture;
    private Texture2D gunShotTexture;
    private Texture2D bloodShotTexture;
    private Texture2D femmeShotTexture;
    private Texture2D mobShotTexture;
    private Texture2D businessShotTexture;
    private Texture2D tommyShotHolesTexture;
    private Texture2D deadCameraTexture;

    private bool uiEnable = false;
    private bool optionsEnable = false;
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

    public Material chalkNonEM, blackmailNonEM, cardNonEM, briefcaseNonEM, tommyNonEM, gunNonEM, bloodNonEM, holesNonEM, deadcamNonEM;//Non-emissive version of evidence materials
    public Material chalkEM, blackmailEM, cardEM, briefcaseEM, tommyEM, gunEM, bloodEM, holesEM, deadcamEM;//Emissive version of evidence materials
    public GameObject chalkObj, blackmailObj, cardObj, briefcaseObj, tommyObj, gunObj1, gunObj2, gunObj3, gunObj4, bloodObj, holesObj1, holesObj2, holesObj3, deadcamObj;//Objectives
    public AddingOptions option;

    void Start()
    {
        playerController = playerObject.GetComponent<PlayerController>();
        option = FindObjectOfType<AddingOptions>();
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
        optionsUI.SetActive(false);

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

            if (!briefcaseFound)
                briefcaseObj.GetComponent<Renderer>().material = briefcaseEM;
            if (!bodyFound)
                chalkObj.GetComponent<Renderer>().material = chalkEM;
            if (!tommygunFound)
                tommyObj.GetComponent<Renderer>().material = tommyEM;
            if (!deadCameraFound)
                deadcamObj.GetComponent<Renderer>().material = deadcamEM;
            if (!bloodFound)
                bloodObj.GetComponent<Renderer>().material = bloodEM;
            if (!cardFound)
                cardObj.GetComponent<Renderer>().material = cardEM;
            if (!blackmailFound)
                blackmailObj.GetComponent<Renderer>().material = blackmailEM;
            if (!tommygunHolesFound)
            {
                holesObj1.GetComponent<Renderer>().material = holesEM;
                holesObj2.GetComponent<Renderer>().material = holesEM;
                holesObj3.GetComponent<Renderer>().material = holesEM;
            }
            if (!gunFound)
            {
                gunObj1.GetComponent<Renderer>().material = gunEM;
                gunObj2.GetComponent<Renderer>().material = gunEM;
                gunObj3.GetComponent<Renderer>().material = gunEM;
                gunObj4.GetComponent<Renderer>().material = gunEM;
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

            briefcaseObj.GetComponent<Renderer>().material = briefcaseNonEM;
            chalkObj.GetComponent<Renderer>().material = chalkNonEM;
            tommyObj.GetComponent<Renderer>().material = tommyNonEM;
            deadcamObj.GetComponent<Renderer>().material = deadcamNonEM;
            bloodObj.GetComponent<Renderer>().material = bloodNonEM;
            cardObj.GetComponent<Renderer>().material = cardNonEM;
            blackmailObj.GetComponent<Renderer>().material = blackmailNonEM;

            holesObj1.GetComponent<Renderer>().material = holesNonEM;
            holesObj2.GetComponent<Renderer>().material = holesNonEM;
            holesObj3.GetComponent<Renderer>().material = holesNonEM;
            gunObj1.GetComponent<Renderer>().material = gunNonEM;
            gunObj2.GetComponent<Renderer>().material = gunNonEM;
            gunObj3.GetComponent<Renderer>().material = gunNonEM;
            gunObj4.GetComponent<Renderer>().material = gunNonEM;
        }
        if ((Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.Z)) && cameraLens) //If you press MMB or Z while you're in camera mode change the field of view
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
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.J))//If you hit tab, open the journal
        {
            if (journalUI != null)
            {
                shutter.PlayOneShot(journalToggle[Random.Range(0, journalToggle.Length)], 0.455F);
                //if(optionsEnable)
                //{
                //    playerController.canmove = true;
                //    optionsUI.SetActive(false);
                //    optionsEnable = false;
                //    Cursor.visible = false;
                //    Cursor.lockState = CursorLockMode.Locked;
                //}
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

        if (Input.GetKeyDown(KeyCode.O))
        {
            if (optionsUI != null)
            {
                //if (uiEnable)
                //{
                //    playerController.canmove = true;
                //    journalUI.SetActive(false);
                //    uiEnable = false;
                //    Cursor.visible = false;
                //    Cursor.lockState = CursorLockMode.Locked;
                //}
                if (optionsEnable == false)
                {
                    playerController.canmove = false;
                    optionsUI.SetActive(true);
                    optionsEnable = true;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                if (optionsEnable == true)
                {
                    playerController.canmove = true;
                    optionsUI.SetActive(false);
                    optionsEnable = false;
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

                if(hit.collider.gameObject.GetComponents<AddingOptions>() != null)
                {
                   var Options = hit.collider.gameObject.GetComponents<AddingOptions>();
                    foreach(var op in Options)
                    {
                        op.AddOptionCam();
                    }
                }

                GameObject[] objectiveArray = GameObject.FindGameObjectsWithTag("Objective");

                foreach (GameObject obj in objectiveArray)//Check to see which Objective the hit is, before running FoundEvidence
                {
                    if (hit.collider.gameObject == obj)
                    {
                        name = obj.gameObject.name;
                        print("Object with tag: " + name + " has been captured");
                        if (name.Equals("Chalkstains"))
                        {
                            FoundEvidence(bodyShotTexture, "Victim", "Killer", bodyImage, "Outline of Victim", body, bodyFound);
                            
                            bodyFound = true;
 
                           
                            chalkObj.GetComponent<Renderer>().material = chalkNonEM;
                            chalkObj.GetComponent<AudioSource>().volume = 0f;
                        }
                        else if (name.Equals("Paperboy"))
                        {
                            FoundEvidence(paperShotTexture, "Paperboy", "Killer", paperboyImage, "Paperboy", paperboy, paperboyFound);
                            
                            paperboyFound = true;
                            
                            
                        }
                        else if (name.Equals("Blackmail Note"))
                        {
                            FoundEvidence(blackmailShotTexture, "Blackmail Note", "Motive", blackmailImage, "Soaked Blackmail Note", blackmail, blackmailFound);
                            
                            blackmailFound = true;
                            blackmailObj.GetComponent<Renderer>().material = blackmailNonEM;
                            blackmailObj.GetComponent<AudioSource>().volume = 0f;
                        }
                        else if (name.Equals("Membership Card"))
                        {
                            FoundEvidence(cardShotTexture, "Communist Membership Card", "Motive", cardImage, "Communist Party Membership Card", card, cardFound);
                           
                            cardFound = true;
                            
                           
                            cardObj.GetComponent<Renderer>().material = cardNonEM;
                            cardObj.GetComponent<AudioSource>().volume = 0f;
                        }
                        else if (name.Equals("Briefcase"))
                        {
                            FoundEvidence(briefcaseShotTexture, "Briefcase", "Motive", briefcaseImage, "Large Briefcase", briefcase, briefcaseFound);
                           
                            briefcaseFound = true;
                            briefcaseObj.GetComponent<Renderer>().material = briefcaseNonEM;
                            briefcaseObj.GetComponent<AudioSource>().volume = 0f;
                        }
                        else if (name.Equals("Tommygun"))
                        {
                            FoundEvidence(tommyShotTexture, "Tommygun", "Weapon", tommygunImage, "Freshly Fired Tommygun", tommygun, tommygunFound);
                           
                            tommygunFound = true;
                            tommyObj.GetComponent<Renderer>().material = tommyNonEM;
                            tommyObj.GetComponent<AudioSource>().volume = 0f;
                        }
                        else if (name.Equals("Tommygun Bulletholes"))
                        {
                            FoundEvidence(tommyShotHolesTexture, "Tommygun Bulletholes", "N/A", tommygunHolesImage, "Bloodless Bulletholes", tommygunHoles, tommygunHolesFound);
                          
                            tommygunHolesFound = true;
                            holesObj1.GetComponent<AudioSource>().volume = 0f;
                            holesObj1.GetComponent<Renderer>().material = holesNonEM;
                            holesObj2.GetComponent<Renderer>().material = holesNonEM;
                            holesObj3.GetComponent<Renderer>().material = holesNonEM;
                        }
                        else if (name.Equals("Revolver"))
                        {
                            FoundEvidence(gunShotTexture, "Revolver", "Weapon", gunImage, "Discarded Revolver", gun, gunFound);
                           
                            gunFound = true;
                            gunObj1.GetComponent<AudioSource>().volume = 0f;
                            gunObj1.GetComponent<Renderer>().material = gunNonEM;
                            gunObj2.GetComponent<Renderer>().material = gunNonEM;
                            gunObj3.GetComponent<Renderer>().material = gunNonEM;
                            gunObj4.GetComponent<Renderer>().material = gunNonEM;
                        }
                        else if (name.Equals("Blood Spatter"))
                        {
                            FoundEvidence(bloodShotTexture, "Blood", "N/A", bloodImage, "Victim's Blood", blood, bloodFound);
                        
                            bloodFound = true;
                            bloodObj.GetComponent<Renderer>().material = bloodNonEM;
                        }
                        else if (name.Equals("Bloody Camera"))
                        {
                            FoundEvidence(deadCameraTexture, "Bloody Camera", "Motive", deadCameraImage, "Bloody Camera", deadCamera, deadCameraFound);
                         
                            deadCameraFound = true;
                            deadcamObj.GetComponent<Renderer>().material = deadcamNonEM;
                            deadcamObj.GetComponent<AudioSource>().volume = 0f;
                        }
                        else if (name.Equals("Femme Fatale Character"))
                        {
                            FoundEvidence(femmeShotTexture, "Woman in Red", "Killer", femmeImage, "Woman in Red", femme, femmeFound);
                         
                            femmeFound = true;
                        }
                        else if (name.Equals("MobBoss"))
                        {
                            FoundEvidence(mobShotTexture, "Mobster", "Killer", mobImage, "Suspicious Woman", mob, mobFound);
                        
                            mobFound = true;
                        }
                        else if (name.Equals("BusinessMan"))
                        {
                            FoundEvidence(businessShotTexture, "Businessman", "Killer", businessImage, "Local Businessman", business, businessFound);
                      
                            businessFound = true;
                        }
                    }
                }
            }
        }
    }

    //If you have found a valid evidence piece, input the appropriate Texture, Name of the evidence, Type, Image, what text displays on the screen after you photograph it, text, and the appropriate boolean
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