using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Game.Flow
{
    /// <summary>
    /// ゲームプレイフロー
    /// </summary>
    public class GameplayFlow : MonoBehaviourPunCallbacks
    {
        // ↓元々はMatchMakeFlowのOnJoinedRoom()のタイミングでシーン切り替え→コイツが呼ばれるという流れだったが、
        //  このタイミングで生成しようとすると死ぬ（他人のルームに入った側が、ルーム作成側を認識できない？）らしい
        /*
        void Awake()
        {
            PhotonNetwork.Instantiate("Prefabs/Player", new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
        }
        */

        public override void OnJoinedRoom()
        {
            // ↓OnJoinedRoom()の中が正しいタイミング
            PhotonNetwork.Instantiate("Prefabs/Player", new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
        }
    }
}
