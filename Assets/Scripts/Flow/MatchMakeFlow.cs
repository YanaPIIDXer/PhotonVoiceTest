using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Pun2Task;
using Photon.Voice.PUN;

namespace Game.Flow
{
    /// <summary>
    /// マッチメイクフロー管理クラス
    /// </summary>
    public class MatchMakeFlow : MonoBehaviourPunCallbacks
    {
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// 接続
        /// </summary>
        public async void Connect()
        {
            try
            {
                await Pun2TaskNetwork.ConnectUsingSettingsAsync();
            }
            catch (Pun2TaskNetwork.ConnectionFailedException e)
            {
                Debug.LogError(e.Message);
            }
            Debug.Log("On Connected Server!");

            await Pun2TaskNetwork.JoinLobbyAsync();
            Debug.Log("On Joined Lobby!");

            try
            {
                SceneManager.LoadScene("Game");
                await Pun2TaskNetwork.JoinOrCreateRoomAsync("TestRoom", new RoomOptions(), TypedLobby.Default);
            }
            catch (Pun2TaskNetwork.Pun2TaskException e)
            {
                Debug.LogError(e.Message);
            }
        }
    }
}
