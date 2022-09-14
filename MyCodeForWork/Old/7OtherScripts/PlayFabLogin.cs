using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabLogin : MonoBehaviour
{
    [SerializeField] public Text textPlayFab;

    [SerializeField] public Text _createErrorLable;
    [SerializeField] public Text _signinErrorLable;
    [SerializeField] public Text _userInfo;

    [SerializeField] public Toggle isHaveAccountToogle;

    [SerializeField] public GameObject loginPanel;
    [SerializeField] public GameObject userEmailInputText;
    [SerializeField] public GameObject userLoginButton;
    [SerializeField] public GameObject userSignInButton;

    [SerializeField] public GameObject userInfoText;
    [SerializeField] public GameObject createErrorText;
    [SerializeField] public GameObject loginErrorText;

    private string _username;
    private string _password;
    private string _email;

    private bool isConnected = false;

    void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            PlayFabSettings.staticSettings.TitleId = " A99CF";
        }

        isHaveAccountToogle.isOn = false;
        userEmailInputText.SetActive(false);
        userSignInButton.SetActive(false);
        userInfoText.SetActive(false);
        createErrorText.SetActive(false);
        loginErrorText.SetActive(false);

        //var request = new LoginWithCustomIDRequest { CustomId = "GeekBrainsLesson", CreateAccount = true };
        //PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    private void Update()
    {
        //IsConectedToPlayfab();
        if (isConnected == true)
        {
            PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), OnGetAccountSucces, OnFailure);
        }

        if (isHaveAccountToogle.isOn == false)
        {
            userSignInButton.SetActive(true);
            userLoginButton.SetActive(false);
            userEmailInputText.SetActive(true);
        }
        else
        {
            userSignInButton.SetActive(false);
            userLoginButton.SetActive(true);
            userEmailInputText.SetActive(false);
        }
    }

    public void UpdateUsername(string username)
    {
        _username = username;
    }

    public void UpdatePassword(string password)
    {
        _password = password;
    }

    public void UpdateEmail(string email)
    {
        _email = email;
    }

    public void CreateAccountPlayFab()
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
        {
            Username = _username,
            Password = _password,
            Email = _email,
            RequireBothUsernameAndEmail = true
        }, result =>
        {
            Debug.Log($"Sucsess entering: {_username}");
            createErrorText.SetActive(false);
            userInfoText.SetActive(true);
        }, error =>
        {
            Debug.LogError($"Fail entering: {error.ErrorMessage}");
            createErrorText.SetActive(true);
            userInfoText.SetActive(false);
        });
    }

    public void SignInPlayFab()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = _username,
            Password = _password,
        }, result =>
        {
            Debug.Log($"Sucsess entering: {_username}");
            loginErrorText.SetActive(false);
            userInfoText.SetActive(true);
        }, error =>
        {
            Debug.LogError($"Fail entering: {error.ErrorMessage}");
            loginErrorText.SetActive(true);
            userInfoText.SetActive(false);
        });
    }

    //public void DeleteAccountPlayFab()
    //{
    //    PlayFabClientAPI.(new RegisterPlayFabUserRequest
    //    {
    //        Username = _username,
    //        Password = _password,
    //        Email = _email,
    //        RequireBothUsernameAndEmail = true
    //    }, result =>
    //    {
    //        Debug.Log($"Sucsess entering: {_username}");
    //        createErrorText.SetActive(false);
    //        userInfoText.SetActive(true);
    //    }, error =>
    //    {
    //        Debug.LogError($"Fail entering: {error.ErrorMessage}");
    //        createErrorText.SetActive(true);
    //        userInfoText.SetActive(false);
    //    });
    //}

    public void GoBack()
    {
        _createErrorLable.text = "";
        _signinErrorLable.text = "";
    }

    private void OnCreationSucsess(RegisterPlayFabUserResult result)
    {
        Debug.Log($"Creation success: {_username}");

        createErrorText.SetActive(false);
        userInfoText.SetActive(true);
    }

    private void OnSignInSuccess(LoginResult result)
    {
        Debug.Log($"Sign in success: {_username}");

        loginErrorText.SetActive(false);
        userInfoText.SetActive(true);

        isConnected = true;
    }

    private void OnFailure(PlayFabError error)
    {
        var errorMessage = error.GenerateErrorReport();
        Debug.LogError($"Error! try again: {errorMessage}");

        createErrorText.SetActive(true);
        loginErrorText.SetActive(true);

        isConnected = false;

        _createErrorLable.text = errorMessage;
        _signinErrorLable.text = errorMessage;
    }

    private void OnGetAccountSucces(GetAccountInfoResult result)
    {
        _userInfo.text = $"Welcome, {_username}, your ID - {result.AccountInfo.PlayFabId}";

        userInfoText.SetActive(true);
    }

    #region old work
    //private void OnLoginSuccess(LoginResult result)
    //{
    //    Debug.Log("Congratulations, you made successful API call!");

    //    isConnected = true;
    //}

    //private void OnLoginFailure(PlayFabError error)
    //{
    //    var errorMessage = error.GenerateErrorReport();
    //    Debug.LogError($"Something went wrong: {errorMessage}");

    //    isConnected = false;
    //}

    //public void IsConectedToPlayfab()
    //{
    //    if (isConnected = true)
    //    {
    //        textPlayFab.text = $"PlayFab\nON";
    //    }

    //    else if (isConnected = false)
    //    {
    //        textPlayFab.text = $"PlayFab\nOFF, error";
    //    }
    //}

    //public void OnButtonPlayFabClick()
    //{
    //    if (isConnected = false)
    //    {
    //        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
    //        {
    //            PlayFabSettings.staticSettings.TitleId = " A99CF";
    //        }

    //        var request = new LoginWithCustomIDRequest { CustomId = "GeekBrainsLesson", CreateAccount = true };
    //        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    //    }

    //    else if (isConnected = true)
    //    {
    //        //PlayFabClientAPI.UnlinkCustomID();

    //        isConnected = false;
    //    }
    //}
    #endregion
}
