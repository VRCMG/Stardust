using ExitGames.Client.Photon;
using Photon.Realtime;
using Stardust.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace Stardust.API
{
    public class DustClient : LoadBalancingClient, IConnectionCallbacks, ILobbyCallbacks, IInRoomCallbacks, IMatchmakingCallbacks
    {
        public static string AuthCookie { get; set; }

        public void OnConnected()
        {
            
        }

        public void OnConnectedToMaster()
        {
            this.SetCustomProperties(AuthCookie, "", "");
            ConsoleUtils.Write("Connected to master yay!!");
        }

        public void OnCreatedRoom()
        {
            
        }

        public void OnCreateRoomFailed(short returnCode, string message)
        {
            
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
            
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
            
        }

        public void OnDisconnected(DisconnectCause cause)
        {
            
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {
            
        }

        public void OnJoinedLobby()
        {
            
        }

        public void OnJoinedRoom()
        {
            
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
            
        }

        public void OnJoinRoomFailed(short returnCode, string message)
        {
            
        }

        public void OnLeftLobby()
        {
            
        }

        public void OnLeftRoom()
        {
            
        }

        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
        {
            
        }

        public void OnMasterClientSwitched(Player newMasterClient)
        {
            
        }

        public void OnPlayerEnteredRoom(Player newPlayer)
        {
            
        }

        public void OnPlayerLeftRoom(Player otherPlayer)
        {
            
        }

        public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            
        }


        public void OnRegionListReceived(RegionHandler regionHandler)
        {
            
        }

        public void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            
        }

        public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
            
        }

        public DustClient(string authtoken) : base(ConnectionProtocol.Udp)
        {
            AppId = "cfc7e5e0-caa8-478a-89a3-ccb5e1374ed1";
            NameServerHost = "ns.exitgames.com";
            AppVersion = "0.249_2.18.1";
            new Thread(() =>
            {
                this.UpdateCallbacks();
            })
            { IsBackground = true }.Start();
            this.RegisterTypes();
            this.SetAuthentication(authtoken, "");
        }

        private void UpdateCallbacks()
        {
            while (true)
            {
                this.Service();
                Thread.Sleep(25);
            }
        }
    }
}
