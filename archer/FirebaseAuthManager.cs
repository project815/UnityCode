using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine.UI;
using TMPro;
//구글게임즈 클라이언트
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.BasicApi.Events;
using System.Threading.Tasks;

/*
파이어베이스 활용한 로그인 정보 출력
출처 : https://www.youtube.com/watch?v=mP6IscbNxOA&list=PLctzObGsrjfwF7kkoraWb235U8Z602gx1&index=4
파이어베이스 공식 문서
출처 : https://firebase.google.com/docs/auth/unity/play-games
파이어베이스 로그인 코드
출처 : https://developer.thebackend.io/unity3d/guide/federation/gpgs/
파이어베이스 발생 오류 예시
출처 : https://firebase.google.com/docs/reference/unity/namespace/firebase/auth
출처2 : https://stackoverflow.com/questions/45587767/how-to-handle-firebase-auth-errors-on-unity
*/
public class FirebaseAuthManager : MonoBehaviour
{
    static FirebaseAuthManager instance = new FirebaseAuthManager();
    public static FirebaseAuthManager Inst => instance;

    //싱글톤으로 구현해보기.
    public static FirebaseApp firebaseApp; //파이어베이스 전체
    public static FirebaseAuth firebaseAuth; //로그인 // 회원가입 등에 사용
    private static FirebaseUser user; //인증이 완료된 유저 정보
    public TMP_Text errorMessage;

    public Image test;

    

    public bool IsFriebaseReady{get; private set;}
    public bool IsSignInOnProgress{get; private set;}

    public TMP_InputField signIn_email;
    public TMP_InputField signIn_passward;


    public TMP_InputField create_email;
    public TMP_InputField create_passward;

    public Button signInButton;

    // Start is called before the first frame update

    /*--------------------------------------
    signInButton은 DependencyStatus.Available의 상태에 따라 활성화또는 비활성화된다.
    firebaseApp은 Firebase에 필요한 모든 시스템이 있는지 비동기식으로 확인한다.
    파이어베이스 전체와 파이어베이스 로그인, 회원가입 정보를 가져온다.
    */
    void Start()
    {
        signInButton.interactable = false;
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {
                var result = task.Result;

                if(result != DependencyStatus.Available) //파이어베이스를 구동할 수 있는 상황이 아니라면
                {
                    Debug.LogError(message: result.ToString());
                    IsFriebaseReady = false;
                }
                else
                {
                    IsFriebaseReady = true;

                    firebaseApp = FirebaseApp.DefaultInstance; // 파이어베이스앱 전체 내용 가져오기
                    firebaseAuth = FirebaseAuth.DefaultInstance; // 파이어베이스 인증 내용 가져오기
                }

                signInButton.interactable = IsFriebaseReady;
            }
        );
        
    }


    void GoogleGamesInit()
    {
        var config = new PlayGamesClientConfiguration.Builder()
        .RequestServerAuthCode(false /* Don't force refresh */)
        .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
    }


/*
오류발생 : 로그인완료에도 불구하고 씬이 로드되지 않음.
해결 : Firebase.Extension 추가
ContinueWithOnMainThread() instead of ContinueWith()
*/
    public void EmailLogin()
    {
        if(!IsFriebaseReady || IsSignInOnProgress || user != null)
        {
            Debug.Log("설마????");
            Debug.Log("IsFriebaseReady : " + IsFriebaseReady);
            Debug.Log("IsSignInOnProgress : " + IsSignInOnProgress);
            Debug.Log("user : " + user);
            return;
        }
        IsSignInOnProgress  = true;
        signInButton.interactable = true;

        // firebaseAuth.SignInWithCredentialAsync() 
        // 구글이나 다른 외부서비스에서 사용할 수 있게 한다.
        // 앱과 해당 서비스를 연결하는 토큰을 가져와서 그것을 끼워줘야지 실행시킬 수 있다.
        firebaseAuth.SignInWithEmailAndPasswordAsync(signIn_email.text, signIn_passward.text).ContinueWithOnMainThread((task) => {
            Debug.Log( message: $"Sign in Status : {task.Status}");
            
            IsSignInOnProgress = false;
            signInButton.interactable = true;

            if(task.IsFaulted)
            {
                //회원가입 실패 이유  >> 이메일이 비정상/ 비밀번호가 너무 간단/ 이미 가입된 이메일 등등.
                Debug.LogError(task.Exception);
                errorMessage.text = "email login fault";


            }
            else if(task.IsCanceled)
            {
                Debug.LogError(message: "Sign-in canceled");
                errorMessage.text = "Sign-in canceled";

            }
            else 
            {
                user = task.Result;
                LoadingSceneController.LoadScene("Demo7");
            }
        });
    }
    //https://firebase.google.com/docs/auth/unity/account-linking
    public void GoogleGameLogin(Action<bool, UnityEngine.SocialPlatforms.ILocalUser> onLoginSuccess = null)
    {
        GoogleGamesInit();

        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptAlways, ( success) => {
            errorMessage.text = "인증들어옴.";
            
            onLoginSuccess?.Invoke(success == SignInStatus.Success, Social.localUser);
            errorMessage.text = "성공?";

            string  authCode = PlayGamesPlatform.Instance.GetServerAuthCode();
            errorMessage.text = authCode;

            firebaseAuth = Firebase.Auth.FirebaseAuth.DefaultInstance;
            Firebase.Auth.Credential credential = Firebase.Auth.PlayGamesAuthProvider.GetCredential(authCode);

            firebaseAuth.SignInWithCredentialAsync(credential).ContinueWithOnMainThread(task => {
            if (task.IsCanceled) {
                Debug.LogError("SignInWithCredentialAsync was canceled.");
                errorMessage.text = "SignInWithCredentialAsync was canceled.";
                return;
            }
            if (task.IsFaulted) {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                errorMessage.text = "SignInWithCredentialAsync encountered an error: " + task.Exception;

                return;
            }
        
            user = task.Result;
            LoadingSceneController.LoadScene("Demo7");
            Debug.LogFormat("User signed in successfully: {0} ({1})",
            errorMessage.text = "User signed in successfully: {0} ({1})",

            user.DisplayName, user.UserId);

            return;
            });
            errorMessage.text = "실패?";

        });
    }

    public void EmailCreate()
    {
        firebaseAuth.CreateUserWithEmailAndPasswordAsync(create_email.text, create_passward.text).ContinueWith(task => {
            
                if(task.IsCanceled)
                {
                    Debug.LogError("회원가입 취소");
                    errorMessage.text = "Signing cancel";

                    return;
                }
                if(task.IsFaulted)
                {
                    //회원가입 실패 이유  >> 이메일이 비정상/ 비밀번호가 너무 간단/ 이미 가입된 이메일 등등.
                    Debug.Log(task.Exception);
                    Debug.Log(task.Exception.InnerExceptions[0].InnerException.Message);
                    errorMessage.text = task.Exception.InnerExceptions[0].InnerException.Message;

                    return;
                }
                
                user = task.Result;
                Debug.Log("회원가입 완료");
            }
        );
    }

    public void LogOut()
    {
        firebaseAuth.SignOut();
        Debug.Log("로그아웃");
    }
}
