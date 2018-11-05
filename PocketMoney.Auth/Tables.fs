namespace PocketMoney.Auth

module Models = 
    type User = 
        { Name :string
          Password : string }

module Tables = 
    let Users = "Users"

