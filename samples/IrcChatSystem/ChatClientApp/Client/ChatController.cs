using System;
using Hik.Communication.Mbt.Communication;
using Hik.Communication.Mbt.Communication.EndPoints.Tcp;
using Hik.Communication.MbtServices.Client;
using Hik.Communication.MbtServices.Communication.Messages;
using Hik.Samples.Mbt.IrcChat.Arguments;
using Hik.Samples.Mbt.IrcChat.Contracts;

namespace Hik.Samples.Mbt.IrcChat.Client
{
    /// <summary>
    /// This class is a mediator with view and MBT system.
    /// </summary>
    internal class ChatController : IChatController
    {
        #region Private fields

        /// <summary>
        /// Reference to login form.
        /// </summary>
        public ILoginFormView LoginForm { get; set; }

        /// <summary>
        /// Reference to chat room window.
        /// </summary>
        public IChatRoomView ChatRoom { get; set; }

        /// <summary>
        /// The object which handles remote method calls from server.
        /// It implements IChatClient contract.
        /// </summary>
        private ChatClient _chatClient;

        /// <summary>
        /// This object is used to connect to MBT Chat Service as a client. 
        /// </summary>
        private IMbtServiceClient<IChatService> _mbtClient;

        #endregion

        #region IChatController implementation

        /// <summary>
        /// Connects to the server.
        /// It automatically Logins to server if connection success.
        /// </summary>
        public void Connect()
        {
            //Disconnect if currently connected
            Disconnect();

            //Create a ChatClient to handle remote method invocations by server
            _chatClient = new ChatClient(ChatRoom);

            //Create a MBT client to connect to MBT server
            _mbtClient = MbtServiceClientBuilder.CreateClient<IChatService>(new MbtTcpEndPoint(LoginForm.ServerIpAddress, LoginForm.ServerTcpPort), _chatClient);

            //Register events of MBT client
            _mbtClient.Connected += MbtClient_Connected;
            _mbtClient.Disconnected += MbtClient_Disconnected;

            //Connect to the server
            _mbtClient.Connect();
        }

        /// <summary>
        /// Disconnects from server if it is connected.
        /// </summary>
        public void Disconnect()
        {
            if (_mbtClient != null && _mbtClient.CommunicationState == CommunicationStates.Connected)
            {
                try
                {
                    _mbtClient.Disconnect();
                }
                catch
                {

                }

                _mbtClient = null;
            }
        }

        /// <summary>
        /// Sends a public message to room.
        /// It will be seen by all users in room.
        /// </summary>
        /// <param name="message">Message to be sent</param>
        public void SendMessageToRoom(ChatMessage message)
        {
            _mbtClient.ServiceProxy.SendMessageToRoom(message);
        }

        /// <summary>
        /// Change status of user.
        /// </summary>
        /// <param name="newStatus">New status</param>
        public void ChangeStatus(UserStatus newStatus)
        {
            _mbtClient.ServiceProxy.ChangeStatus(newStatus);
        }

        /// <summary>
        /// Sends a private message to a user.
        /// </summary>
        /// <param name="nick">Destination nick</param>
        /// <param name="message">Message</param>
        public void SendPrivateMessage(string nick, ChatMessage message)
        {
            _mbtClient.ServiceProxy.SendPrivateMessage(nick, message);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// This method handles Connected event of _mbtClient.
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void MbtClient_Connected(object sender, EventArgs e)
        {
            try
            {
                _mbtClient.ServiceProxy.Login(LoginForm.CurrentUserInfo);
                ChatRoom.OnLoggedIn();
            }
            catch (MbtRemoteException ex)
            {
                Disconnect();
                ChatRoom.OnLoginError(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
            catch
            {
                Disconnect();
                ChatRoom.OnLoginError("Can not login to server. Please try again later.");
            }
        }

        /// <summary>
        /// This method handles Disconnected event of _mbtClient.
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void MbtClient_Disconnected(object sender, EventArgs e)
        {
            ChatRoom.OnLoggedOut();
        }

        #endregion
    }
}
