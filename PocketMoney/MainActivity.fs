namespace PocketMoney

open System

open Android.App
open Android.Widget

type Resources = PocketMoney.Resource

[<Activity (Label = "PocketMoney", MainLauncher = true, Icon = "@mipmap/icon")>]
type MainActivity () =
    inherit Activity ()

    let rec factorial x =
        if (x < 1) then 1
        else x * factorial (x - 1)

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)

        // Set our view from the "main" layout resource
        this.SetContentView (Resources.Layout.Main)

        // Get our button from the layout resource, and attach an event to it
        let button = this.FindViewById<Button>(Resources.Id.button)
        let textbox = this.FindViewById<EditText>(Resources.Id.textbox)
        let layout = this.FindViewById<TextView>(Resources.Id.layout)

        button.Click.Add (fun _ -> 
            layout.Text <- sprintf "%d" (factorial (textbox.Text |> int))
        )

