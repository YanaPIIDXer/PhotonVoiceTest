using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UniRx;
using UniRx.Triggers;
using System;

namespace Game.Player
{
    /// <summary>
    /// メッセージ送信
    /// </summary>
    public class MessageSender : MonoBehaviour
    {
        /// <summary>
        /// PhotonView
        /// </summary>
        private PhotonView View = null;

        void Awake()
        {
            View = PhotonView.Get(this);
            this.UpdateAsObservable()
                .Where((_) => View.IsMine && Input.GetKeyDown(KeyCode.Space))
                .Subscribe((_) => View.RPC("Send", RpcTarget.All, "Hello, RPC from" + View.ViewID))
                .AddTo(gameObject);
        }

        /// <summary>
        /// 送信
        /// </summary>
        /// <param name="Message">送信するメッセージ</param>
        [PunRPC]
        private void Send(string Message)
        {
            Debug.Log("RPC Message:" + Message);
        }
    }
}
