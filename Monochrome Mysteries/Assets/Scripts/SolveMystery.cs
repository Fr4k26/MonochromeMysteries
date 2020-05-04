using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SolveMystery : MonoBehaviour
{
    public GameObject confirmMenu;

    public Dropdown firstDrop;
    public Dropdown secondDrop;
    public Dropdown thirdDrop;

    public Text winText;

    public string[] firstSolution = new string[3];
    public string[] secondSolution = new string[3];
    public string[] thirdSolution = new string[3];
    public string[] fourthSolution = new string[3];
    public string[] fifthSolution = new string[1];

    public void CheckOptions()
    {
        if (firstDrop.captionText.text == firstSolution[0] && secondDrop.captionText.text == firstSolution[1] && thirdDrop.captionText.text == firstSolution[2])
        {
            print("Femme Fatale True Ending");
            PlayerPrefs.SetString("endingText", "Your article is printed a day later. \r\n \r\n In it, you lay out the exacts of how the crime happened given the evidence the police so negligently left at the scene. Following public outcry over the way the whole situation was handled, Gina Afluette is caught attempting to flee the country and promptly taken into custody. \r\n \r\n The following proceedings are always at the cusp of mentioning your article, but don’t, the police apparently having retraced your steps. Eventually Gina admits to committing the murder under threat of blackmail and is sentenced to 30 years jail time, which seems like a lucky break to you. \r\n \r\n For the next couple years you keep an especial eye on the Mob and Adam C.Winston, because after all, there’s still work to do.");
            confirmMenu.SetActive(true);
        }
        else if (firstDrop.captionText.text == secondSolution[0] && secondDrop.captionText.text == secondSolution[1] && thirdDrop.captionText.text == secondSolution[2])
        {
            print("Businessman True Ending");
            PlayerPrefs.SetString("endingText", "Your article is printed a day later. \r\n \r\n In it, you offer up certain conjecture about Adam C. Winston, his recent presence in Mob controlled territory, and a dead man who might’ve been a communist. There’s nothing concrete in your article, but the few connections you point to make it seem like there is. \r\n \r\n The man’s stocks plummet once the article picks up traction, and eventually they snag him on an embezzlement case as he tries to bail himself out of debt. As he’s sentenced Gina Afluette silently slips out of the country. \r\n \r\n Without Winston’s stranglehold on the market, plenty of small businesses sprout up, not without a few new newspapers. Within a couple years, you have plenty more competition in your field, but are still the best at what you do.");
            confirmMenu.SetActive(true);
        }
        else if (firstDrop.captionText.text == thirdSolution[0] && secondDrop.captionText.text == thirdSolution[1] && thirdDrop.captionText.text == thirdSolution[2])
        {
            print("Mobster True Ending");
            PlayerPrefs.SetString("endingText", "Your article is printed a day later. \r\n \r\n In it, you connect everything back to the Mob. The murder, the weapons-- likely manufactured by the Mob-- the corruption of local business. It’s all there, even if you have to sacrifice a bit of professional pride to sell it. Your thesis: Fear the Mob. \r\n \r\n The street cred works its wonders, Adam C. Winston backs off and the Mob is able to expand their control, thankfully with very few acts of violence occurring within their territory. \r\n \r\n Your bit of bravado has kept blood off the streets, and power in the hands of the people. While people don’t necessarily understand the lie you printed, it got results, and that’s what matters.  ");
            confirmMenu.SetActive(true);
        }
        else if (firstDrop.captionText.text == fourthSolution[0] && thirdDrop.captionText.text == fourthSolution[2]) //Doesn't matter what gun the Paperboy used
        {
            print("Paperboy True Ending");
            PlayerPrefs.SetString("endingText", "Your article is printed a day later. \r\n \r\n In it, you spin a story of betrayal and corruption within the newspaper industry. A paperboy, denied promotion due to entrenched nepotism and insider trading, sees a chance to move up in the world, and an expensive camera on a Private Investigator’s neck. \r\n \r\n The motive and murder weapon are tentative, at best, but the story is gripping. Following Reggie’s arrest, protests begin, demands to “drain the swamp” of the newspaper industry. The result is a restructuring of journalism as you know it, faster looser, and with more journalists than you can count. \r\n \r\n You struggle to keep up with this world of mistrust and vapid stories, while the Paperboy is sentenced to 20 years, being tried as an adult. ");
            confirmMenu.SetActive(true);
        }
        else if (firstDrop.captionText.text == firstSolution[0])
        {
            print("Femme Fatale Untrue Ending");
            PlayerPrefs.SetString("endingText", "Your article is printed a day later. \r\n \r\n In it, you paint a picture you feel is exact in revealing how the crime occurred under the nose of the police force, using their incompetence to mask your own. Among the subsequent mixture of backlash from the cops and public panic, Gina Afluette makes a quiet escape out of the country. \r\n \r\n Despite developing an obsession over bringing her to justice in some form, you never see or hear of her again, and she completely fades from the city’s memory. Likely changing her name and affiliates, she’s a ghost in the wind. \r\n \r\n Every now and then you wonder if things would’ve turned out different if you pinned the proper evidence on her. Not liking your own answer, you reach for the bottle most days, knowing it will absolve you of all blame. ");
            confirmMenu.SetActive(true);
        }
        else if (firstDrop.captionText.text == secondSolution[0])
        {
            print("Businessman Untrue Ending");
            PlayerPrefs.SetString("endingText", "Your article is printed a day later. \r\n \r\n In it, you offer up certain conjecture about Adam C. Winston, but you’re flailing for connections and it shows. There’s nothing concrete in the article by the time you’re done with it, but you still throw your whole weight behind pinning the murder on Winston, putting your career on the line. \r\n \r\n His stock drops a few points and that’s the end of it. A week later, after your job offers dry up, a shot punctures the window of your office and your skull soon-after. No one traces the hit back to Winston and the whole affair is quickly forgotten. After a few days, his stocks return to normal.");
            confirmMenu.SetActive(true);
        }
        else if (firstDrop.captionText.text == thirdSolution[0])
        {
            print("Mobster Untrue Ending");
            PlayerPrefs.SetString("endingText", "Your article is printed a day later. \r\n \r\n In it, you string together a plot of the Mob executing yet another hit. You hope it’ll inspire fear in those with deep pockets and big mouths. \r\n \r\n The police don’t take too kindly to all the credit you seem to be giving organized crime, and despite the convenient accusation against the Mob, the evidence just doesn’t add up. \r\n \r\n Alienated by both the law and the papers, you find less and less legitimate work, and start hearing more from that nameless woman you met at the crime scene. You find new ways of making money, and the Mob takes good enough care of you, but you never entirely get used to the sudden career change.");
            confirmMenu.SetActive(true);
        }
        else if (firstDrop.captionText.text == fourthSolution[0])
        {
            print("Paperboy Untrue Ending");
            PlayerPrefs.SetString("endingText", "Your article is printed a day later. \r\n \r\n In it, the story of a vile ambition in the newspaper business is told; a paperboy, denied promotion due to entrenched nepotism and insider trading, sees a chance to move up in the world. At the end of the day, it’s just a story, no matter how interesting. It’s dismissed by the police as well as the general public. \r\n \r\n The quality of your work slips a bit with the pressure of putting out the truth and entertainment simultaneously. \r\n \r\n Years later, you find yourself and your now mediocre work replaced by a young man with a drive born of a false accusation in his past—he seems damn familiar… Turns out he’s a much better journalist than you could ever muster.");
            confirmMenu.SetActive(true);
        }
        else if (firstDrop.captionText.text == fifthSolution[0])
        {
            print("Suicide Ending");
            PlayerPrefs.SetString("endingText", "Your article is printed a day later. \r\n \r\n In it, you lay out a rather straightforward explanation of events. The man shot himself on the roof and fell to the street below, post-mortem looting scattering the evidence beyond the crime scene proper. \r\n \r\n Without the police taking much of an interest in a case in Mob territory, and without you supplying a story to press them to action, the whole thing is written of as a suicide. \r\n \r\n If there was a killer, or an opportunity here, they’re gone. Otherwise, things continue the same as ever, with you making small splashes here and there and doing the best work you can.");
            confirmMenu.SetActive(true);
        }
        else
        {
            print("Incomplete Mystery");
        }

    }

    public void SolveM()
    {
            Debug.Log("Solved the Mystery!");
            //winText.text = "You have solved the Mystery!";
            //winText.gameObject.SetActive(true);
            StartCoroutine(winChange());
    }

    IEnumerator winChange()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Victory");
    }
}
