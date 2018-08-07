using UnityEngine.UI;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour {
    
    public InputField email;
    public InputField password;

    protected FirebaseAuth auth;


   	void Start () {
        //initialize Firebase SDK
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
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

        auth = FirebaseAuth.DefaultInstance;
	}
	
	void Update () {
		
	}


    public void CreateAccount()
    {
        string emailInput = email.text;
        string passwordInput = password.text;


        auth.CreateUserWithEmailAndPasswordAsync(emailInput, passwordInput).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }


    public void LoginUser()
    {
        string emailInput = email.text;
        string passwordInput = password.text;

        Credential credential =
                    EmailAuthProvider.GetCredential(emailInput, passwordInput);
        
        auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithCredentialAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });

    }



    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
