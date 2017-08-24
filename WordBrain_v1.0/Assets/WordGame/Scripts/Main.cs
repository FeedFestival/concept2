using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public bool DebugScript;

    private static Main _main;
    public static Main Instance()
    {
        return _main;
    }

    public User LoggedUser;
    
    void Awake()
    {
        _main = GetComponent<Main>();
    }

    void Init()
    {
        /*
         * ---------------------------------------------------------------------
         * * ---------------------------------------------------------------------
         * * ---------------------------------------------------------------------
         */
         
        CreateSession();
    }

    // callbacks
    public delegate void OnSplashFinish();


    IEnumerator ShowIntro(OnSplashFinish onSplashFinish)
    {
        yield return new WaitForSeconds(2f);

        onSplashFinish();
    }

    public void CreateSession()
    {
        //LoggedUser = DataService.GetUser();
        //if (LoggedUser == null)
        //{
        //    DataService.CreateDB();
        //    var user = new User
        //    {
        //        Id = 1,
        //        Name = "Player 1",
        //        Language = "en_US",
        //        Maps = 0
        //    };
        //    Debug.Log("This is a fresh install. Creating user..." + user);
        //    DataService.CreateUser(user);
        //    //
        //    LoggedUser = DataService.GetUser();
        //}

        //if (LoggedUser.Maps == 0)
        //{
        //    LoggedUser.Maps = 1;
        //}

        //scope["RomaniaMaps"].GetComponent<Text>().text = LoggedUser.Maps.ToString();
        //scope["EnglishMaps"].GetComponent<Text>().text = LoggedUser.Maps.ToString();
        //scope["PMaps"].GetComponent<Text>().text = LoggedUser.Maps.ToString();

        //Debug.Log("Logged in. " + LoggedUser);
    }
}
