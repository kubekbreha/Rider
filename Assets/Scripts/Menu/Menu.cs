using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Auth;



/*
 * Created by Kubo Brehuv 7.8.2018
 */
public class Menu : MonoBehaviour {

    public Text userText;

    protected FirebaseAuth auth;

	void Start () {
        SetUserNameText();
	}

	void Update () {
		
	}


    public void SetUserNameText(){
        auth = FirebaseAuth.DefaultInstance;
        FirebaseUser user = auth.CurrentUser;
        string userName = user.DisplayName;

        if (userName.Equals(""))
        {
            userName = user.Email;
        }

        if (user != null)
        {
            userText.text = "Welcome " + userName.Substring(0, userName.LastIndexOf('@'));
        }
    }


	public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
