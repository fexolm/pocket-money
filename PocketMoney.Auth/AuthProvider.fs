namespace PocketMoney.Auth
open PocketMoney.Data
open FSharp.Data
open FSharp.Data.JsonExtensions
open Models
module TestAuthProvider = 
    let internal isNull x =
        match x with 
            | JsonValue.Null -> true
            | _ -> false

    let Register username password = 
        let users = DbContext.Open (fun provider -> provider.Get Tables.Users)

        let a = isNull users
        if (isNull users) || not (users.Properties |> Array.exists (fun (_, v) -> v?Name.AsString() = username)) then 
            DbContext.Open(fun provider -> provider.Push Tables.Users { Name = username ; Password = password})
        else 
            JsonValue.Null

    let Login username password = 
        let users = DbContext.Open (fun provider -> provider.Get Tables.Users)
        let user = users.Properties |> Array.tryFind (fun (k, v) -> v?Name.AsString() = username)
        if user.IsNone then None
        else (fun (k, v) -> (if v?Password.AsString() = password then option.op_Implicit k else None)) (user.Value)