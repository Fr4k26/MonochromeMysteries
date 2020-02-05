using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
	public float captureDistance = 500;
	public GameObject cameraUI, textUI, rain;
    public Text victim, weapon, dumpster, crates, notepad;
    public AudioSource shutter;

	private Flash flash;

    private bool corpseBool = false;
    private bool cratesBool = false;
    private bool batBool = false;
    private bool dumpsterBool = false;
    private bool notepadBool = false;

    public GameObject winText;

    void Start()
    {
        cameraUI.SetActive(false);
        winText.SetActive(false);
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
			cameraUI.SetActive(true);
            textUI.SetActive(false);
		}
		if (Input.GetMouseButtonUp(1))
        {
			rain.SetActive(false);
			cameraUI.SetActive(false);
            textUI.SetActive(true);
        }
        if (batBool && cratesBool && corpseBool && dumpsterBool && notepadBool)
        {
            winText.SetActive(true);
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
                        if (name.Equals("Corpse"))
                        {
                            victim.GetComponent<Text>().color = Color.green;
                            corpseBool = true;
}
                        else if (name.Equals("Bat"))
                        {
                            weapon.GetComponent<Text>().color = Color.green;
                            batBool = true;
                        }
                        else if (name.Equals("Dumpster"))
                        {
                            dumpster.GetComponent<Text>().color = Color.green;
                            dumpsterBool = true;
                        }
                        else if (name.Equals("Crates"))
                        {
                            crates.GetComponent<Text>().color = Color.green;
                            cratesBool = true;
                        }
                        else if (name.Equals("Notepad"))
                        {
                            notepad.GetComponent<Text>().color = Color.green;
                            notepadBool = true;
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