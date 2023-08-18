namespace OSRMEngine.Services

open Newtonsoft.Json
open Newtonsoft.Json.Serialization
open Suave
open Suave.Operators
open Suave.Successful

[<AutoOpen>]
module UserService =
    open Suave.RequestErrors
    open Suave.Filters
    // auxiliary methods
    let getUTF8 (str: byte[]) =
        System.Text.Encoding.UTF8.GetString(str)

    let jsonToObject<'t> json =
        JsonConvert.DeserializeObject(json, typeof<'t>) :?> 't
    // 't -> WebPart
    let JSON v =
        let jsonSerializerSettings = new JsonSerializerSettings()
        jsonSerializerSettings.ContractResolver <- new CamelCasePropertyNamesContractResolver()

        JsonConvert.SerializeObject(v, jsonSerializerSettings) |> OK
        >=> Writers.setMimeType "application/json"
