using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UniRx;
using UniRx.Triggers;
using System;
using Photon.Realtime;
using Game.Flow;

namespace Game.UI
{
    /// <summary>
    /// ログインボタン
    /// </summary>
    public class LogInButton : MonoBehaviourPunCallbacks
    {
        /// <summary>
        /// ボタン
        /// </summary>
        private Button MyButton = null;

        /// <summary>
        /// マッチメイクフロー
        /// </summary>
        [SerializeField]
        private MatchMakeFlow MatchFlow = null;

        void Awake()
        {
            MyButton = GetComponent<Button>();
            MyButton.OnClickAsObservable()
                .Subscribe((_) =>
                {
                    MatchFlow.Connect();
                    MyButton.interactable = false;
                })
                .AddTo(gameObject);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            MyButton.interactable = true;
        }
    }
}
