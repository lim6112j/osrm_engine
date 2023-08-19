namespace OSRMEngine

#nowarn "20"

open System
open System.Collections.Generic
open System.IO
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.HttpsPolicy
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging


module Program =
    let exitCode = 0

    open Suave.Web

    open OSRMEngine.Services
    open OSRMEngine.Repository


    [<EntryPoint>]
    let main args =

        // let builder = WebApplication.CreateBuilder(args)
        //
        // builder.Services.AddControllers()
        //
        // let app = builder.Build()
        //
        // app.UseHttpsRedirection()
        //
        // app.UseAuthorization()
        // app.MapControllers()
        //
        // app.Run()
        //
        let userActions =
            handle
                "users"
                { ListUsers = UserRepository.getUsers
                  GetUser = UserRepository.getUser
                  AddUser = UserRepository.createUser
                  UpdateUser = UserRepository.updateUser
                  UpdateUserById = UserRepository.updateUserById
                  DeleteUser = UserRepository.deleteUser }

        startWebServer defaultConfig userActions

        exitCode
