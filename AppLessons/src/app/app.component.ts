import { CleintSignalR } from './Model/ModelClientSignalR/clientSignalR';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription, timer } from 'rxjs';
import { SignalRservice } from './Services/app.servces';
import { emplyeeServices } from './Services/testEmplyee.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit,OnDestroy {

  public message: string = 'Undefined';
  public messageServer: string = 'Обновление котла';

  messageReceive:string[] = [];
  public client: CleintSignalR = {Login: 'Angular user'}

  constructor(public signalRService: SignalRservice,private employeeService: emplyeeServices)
  {

  }
   ngOnInit()
  {
    this.signalRService.startConnection(this.client);
    this.signalRService.askServerListener();

    this.signalRService.messageReceive$.subscribe(
      {
        next:(rec)=>
        {
          console.log("Где?");
          this.messageReceive.push(rec);
        }
      }
    );

    this.signalRService.messageReceiveAll$.subscribe(
      {
        next:(rec)=>{
          this.messageReceive.push(rec);
        }
      }
    )

    this.signalRService.askServerRefreshTerminalsResponce();

    this.signalRService.askRefreshWanTermianlResponce();
   // this.signalRService.askServer(this.client);
  }

  ngOnDestroy(): void {
    this.signalRService.hubConnection.off("askServerResponce");
  }

  ClickBut()
  {
    console.log('нажал');

   // this.signalRService.askServer(this.client);

    this.employeeService.getAllTest()
              .subscribe({
                next: (str) =>{
                  //this.message = str;
                  //this.messageReceive = str;
                }
              });
  }

  RefreshWanTerminal(){
    this.signalRService.askRefreshWanTerminalSignalR(this.messageServer);
  }

  title = 'AppLessons';

  OnDestroy(){
    this.signalRService.messageReceive$.unsubscribe();
    this.signalRService.messageReceiveAll$.unsubscribe();
  }
}

