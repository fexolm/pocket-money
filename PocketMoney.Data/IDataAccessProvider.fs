namespace PocketMoney.Data
open FSharp.Data

type IDataAccessProvicer =
    abstract member Set : string -> 'a -> JsonValue
    abstract member Push : string -> 'a -> JsonValue
    abstract member Get : string -> JsonValue
    abstract member Update : string -> 'a -> JsonValue
    abstract member Delete : string -> 'a -> JsonValue

