import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from "@angular/core";
import { ApiService } from "../../services/api.service";
import { ChatMessage } from "../../models/message.model";
import { CommonModule } from "@angular/common";
import { MessageComponent } from "../message/message.component";
import { FormsModule } from "@angular/forms";
import { interval, Subscriber, Subscription, take } from "rxjs";
import { NgScrollbar, NgScrollbarModule } from 'ngx-scrollbar';
import { MatButtonModule } from "@angular/material/button";
import {MatInputModule} from '@angular/material/input';
import { MatIconModule } from "@angular/material/icon";


@Component({
    selector: "app-chat",
    standalone: true,
    providers: [ApiService],
    imports: [CommonModule, MessageComponent, FormsModule, NgScrollbarModule, MatButtonModule, MatInputModule, MatIconModule],
    templateUrl: "chat.component.html",
    styleUrls: ["./chat.component.scss"]
})
export class ChatComponent implements OnInit{

    public chatMessages: ChatMessage[] = [];
    private chatId: number | null = 1;
    public msg: string  = "";

    private humanSub!: Subscription;

    public constructor(private apiSerivce: ApiService){}


    async ngOnInit(): Promise<void> {
        await this.getMessages();
    }


    public async getMessages(){
        this.chatMessages = await this.apiSerivce.GetAllMessages(this.chatId);
    }

    public async sendMessage(){
        if(this.msg.length > 0){
            this.chatMessages.push({
                id: 0,
                approval: null,
                message: this.msg,
                isAI: false,
                isLoading: false
            });
            let response = await this.apiSerivce.SendMessage(this.msg, this.chatId);
            if(this.chatId == null){
                this.chatId = response.chatId!
            }
            this.simulateHuman(response);
            this.chatMessages.push(response);
            this.msg = "";     
        }
    }

    public CancelLoadingMsg(){
        this.humanSub.unsubscribe();
    }

    private simulateHuman(msg: ChatMessage){
        msg.isLoading = true;
        let fullMessage = msg.message;
        let splitMsg = fullMessage.split(" ");
        msg.message = "";
        const parts = interval(300);
        const obs = parts.pipe(take(splitMsg.length));
        this.humanSub= obs.subscribe({
        next: (index)=>{
            msg.message += splitMsg[index] + " ";
        },
        complete: ()=>{
            msg.isLoading = false;
        }});
    }
}