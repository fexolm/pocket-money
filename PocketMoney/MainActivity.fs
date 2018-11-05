namespace PocketMoney

open System
open Android.App
open Android.Widget
open Android.Text.Method
open PocketMoney.Auth
type Resources = PocketMoney.Resource

type FactorialCache =
    { Value: int }

[<Activity (Label = "PocketMoney", MainLauncher = true, Icon = "@mipmap/icon")>]
type MainActivity () =
    inherit Activity ()

    override this.OnCreate (bundle) =
        base.OnCreate (bundle)

        // Set our view from the "main" layout resource
        this.SetContentView (Resources.Layout.Main)
        // Get our button from the layout resource, and attach an event to it
        let loginBtn = this.FindViewById<Button>(Resources.Id.loginBtn)
        let registerBtn = this.FindViewById<Button>(Resources.Id.registerBtn)
        let loginEdit = this.FindViewById<EditText>(Resources.Id.loginEdit)
        let passwdEdit = this.FindViewById<EditText>(Resources.Id.passwdEdit)
        let responceView = this.FindViewById<TextView>(Resources.Id.responceView)

        responceView.MovementMethod <- new ScrollingMovementMethod();

        loginBtn.Click.Add (fun _ -> 
            let result = TestAuthProvider.Login loginEdit.Text passwdEdit.Text
            if not result.IsNone then responceView.Text <- sprintf "%s" (result.Value)
            else responceView.Text <- "Failed"
        )

        registerBtn.Click.Add (fun _ -> 
            let result = TestAuthProvider.Register loginEdit.Text passwdEdit.Text
            responceView.Text <- sprintf "%s" (result.ToString())
        )


