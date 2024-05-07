using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using UnityEngine.UI;
using  TMPro;
using JetBrains.Annotations;
using UnityEngine.Networking;


public class authManager : MonoBehaviour
{


    public TextMeshProUGUI logTxt;

     async void Start() {
        await UnityServices.InitializeAsync();
     }

     public async void SignIn(){
        await SignInAnonymous();

     }

     async Task SignInAnonymous(){
        try{
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            print("Sign In successful!");
            print("Player id " +  AuthenticationService.Instance.PlayerId);
            logTxt.text = "Player id " +  AuthenticationService.Instance.PlayerId;
        }
        catch(AuthenticationException ex){
            print("Signin Failed!!");
            Debug.LogError(ex);
     }
}

}


