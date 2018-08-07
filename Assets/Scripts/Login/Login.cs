using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;

public class Login : MonoBehaviour {

    protected FirebaseAuth auth;

   	void Start () {
        //initialize Firebase SDK
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                Debug.Log("Firebase SDK Initialized.");
            }
            else
            {
                Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });
	}
	
	void Update () {
		
	}


    //private void AuthenticateWithFirebase(){
    //    Credential credential =
    //       GoogleAuthProvider.GetCredential(googleIdToken, googleAccessToken);
    //    auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
    //        if (task.IsCanceled)
    //        {
    //            Debug.LogError("SignInWithCredentialAsync was canceled.");
    //            return;
    //        }
    //        if (task.IsFaulted)
    //        {
    //            Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
    //            return;
    //        }

    //        Firebase.Auth.FirebaseUser newUser = task.Result;
    //        Debug.LogFormat("User signed in successfully: {0} ({1})",
    //            newUser.DisplayName, newUser.UserId);
    //    });
    //}
}
