namespace PocketMoney.Data

open FireSharp
open FireSharp.Config

module internal Firebase = 
    open FSharp.Data

    let Connect () =  
        let config = new FirebaseConfig()
        config.AuthSecret <- "i0zvGLpPFhJpY0o5tlKP969ZjO4kZHEsXSpvXx1t"
        config.BasePath <- "https://pocketmoney-a5b5d.firebaseio.com/"
        new FirebaseClient(config)

    type DataAccessProvider() =
        let client = Connect()

        let parse x = 
            if x = null || x = "null" then JsonValue.Null
            else JsonValue.Parse(x)

        interface IDataAccessProvicer with
            member this.Push name data =
                let response = client.PushAsync(name, data)
                parse(response.Result.Body)
                

            member this.Set name data =
                let response = client.SetAsync(name, data)
                parse(response.Result.Body)

            member this.Get name =
                let response = client.GetAsync(name)
                parse(response.Result.Body)

            member this.Update name data = 
                let response = client.UpdateAsync(name, data)
                parse(response.Result.Body)

            member this.Delete name data = 
                let response = client.DeleteAsync(name)
                parse(response.Result.Body)
                

