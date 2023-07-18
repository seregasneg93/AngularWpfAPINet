import { CleintSignalR } from './../Model/ModelClientSignalR/clientSignalR';
import { Observable, of, Subject } from 'rxjs';
import { Injectable } from "@angular/core";
import * as signalR from "@aspnet/signalr";


@Injectable({providedIn: 'root'})

export class SignalRservice{

  public messageReceive$ = new Subject<string>();
  public messageTerminal$ = new Subject<string>();

  public messageReceiveAll$ = new Subject<string>();
  constructor()
  {

  }

  hubConnection:signalR.HubConnection;

  startConnection = (client:CleintSignalR) =>{

    this.hubConnection = new signalR.HubConnectionBuilder()
        .withUrl('https://localhost:7267/toastr',{
          skipNegotiation : true,
          transport: signalR.HttpTransportType.WebSockets
        })
        .build();

    this.hubConnection
        .start()
        .then(()=>
        {
          console.log('hub connection started!')
          this.askServer(client)
        })
        .catch(err => console.log('error connection: ' + err));
  }

  askServer(client:CleintSignalR){
    this.hubConnection.invoke("askServer",client)
        .catch(err=>console.log("Error method askServer:" + err));
  }

  askServerListener(){
     this.hubConnection.on("askServerResponce",(message) =>{
        //console.log(message)
        this.testRX(message);
    });
  };

  askServerRefreshTerminalsResponce(){
    this.hubConnection.on("RefreshTerminalsResponce",(message)=>{
      console.log(message);
    })
  }

  askRefreshWanTermianlResponce(){
    this.hubConnection.on("RefreshWanResponce",(id)=>{
      console.log(id);
      //this.receiveTerminal(id);
    });
  }

  askServerResponceAll(){
    this.hubConnection.on("aspResponceAll",(someText)=>{
      console.log("Ответ сервера");
      console.log(someText);
    });
  }

  askRefreshWanTerminalSignalR(parametrTerminal:string){
    this.hubConnection.invoke("RefreshWanTerminal",parametrTerminal)
                        .catch(err=>console.log(err));
  }

  testRX(messageRec:string)
  {
    this.messageReceive$.next(messageRec);
  }

  receiveTerminal(id:string){
    this.messageTerminal$.next(id);
  }

  textRxResponceAll(messageAll:string)
  {
    this.messageReceiveAll$.next(messageAll);
  }
}

