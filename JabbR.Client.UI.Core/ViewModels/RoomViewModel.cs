﻿using JabbR.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabbR.Client.UI.Core.ViewModels
{
    public class RoomViewModel 
        : BaseViewModel
    {
        readonly IJabbRClient _client;
        public RoomViewModel(IJabbRClient client)
        {
            _client = client;
        }

        private Room _room;
        public Room Room
        {
            get { return _room; }
            set
            {
                _room = value;
                RaisePropertyChanged(() => Room);
            }
        }

        private ObservableCollection<Message> _messages;
        public ObservableCollection<Message> Messages 
        {
            get { return _messages; }
            set
            {
                _messages = value;
                RaisePropertyChanged(() => Messages);
            }
        }

        //private ObservableCollection<User> _owners;
        //public ObservableCollection<User> Owners 
        //{
        //    get { return _owners; }
        //    set
        //    {
        //        _owners = value;
        //        RaisePropertyChanged(() => Owners);
        //    }
        //}

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                RaisePropertyChanged(() => Users);
            }
        }

        public async void Init(string roomName)
        {
            var room = await _client.GetRoomInfo(roomName);
            Room = room;
            Messages = new ObservableCollection<Message>(Room.RecentMessages);
            Users = new ObservableCollection<User>(Room.Users);
        }
    }
}