using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using Facebook.Unity;
using UnityEngine.UI;
using UnityEditor;

public class MainMenuControl : MonoBehaviour
{
    public Text textStatus;
    public Image ProfilePic;
    public GameObject fbLogin;
    public GameObject fbLogout;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            FB.ActivateApp();
        }
            
    }
    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
        }
        else
        {
            textStatus.text = "failed to initialize the Facebook SDK";
        }
        if (FB.IsLoggedIn)
        {
            FB.API("/me?fields=name", HttpMethod.GET, DispName);
            FB.API("me/picture?type=square&height=128&width=128", HttpMethod.GET, GetPicture);
            fbLogin.SetActive(false); fbLogout.SetActive(true);
        }
        else
        {
            textStatus.text = "Please Login to continue";
            fbLogin.SetActive(true); fbLogout.SetActive(false);

        }
    }
    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;//pause
        }
        else
        {
            Time.timeScale = 1;//resume
        }
    }
    public void LoginWithFB()
    {
        var perms = new List<string>() { "public_profile" };
        FB.LogInWithReadPermissions( perms,AuthCallback);
    }
    public void LogoutWithFB()
    {
        FB.LogOut(); fbLogin.SetActive(true); fbLogout.SetActive(false);
    }
    private void AuthCallback(ILoginResult result)
    {
        if(result.Error != null)
        {
            textStatus.text = result.Error;
        }
        
    }
    void DispName(IResult result)
    {
        if(result.Error!=null){
            textStatus.text = result.Error;
        }
        else
        {
            textStatus.text = "Hi : " + result.ResultDictionary["name"];
        }
    }
    private void GetPicture(IGraphResult result)
    {
        if (result.Error == null && result.Texture!=null)
        {
            ProfilePic.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2());
        }
    }
    
    public void whichButton(int buttonNumber)
    {
        if (buttonNumber == 0)
        {
            SceneManager.LoadScene(1);
        }
        else if (buttonNumber == 3)
        {
            Application.Quit();
        }
    }
    
}
