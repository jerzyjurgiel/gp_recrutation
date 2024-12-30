import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ChatMessage } from "../models/message.model";
import { lastValueFrom } from "rxjs";

@Injectable()
export class ApiService{
    private baseUrl: string = "https://localhost:7118/api";

    public constructor(private httpClient: HttpClient){}

    public async GetAllMessages(chatId: number | null): Promise<ChatMessage[]>{
        if(chatId == null) return [];
        return await lastValueFrom(this.httpClient.get<ChatMessage[]>(this.baseUrl + "/Message/GetMessages?chatId="+ chatId));
    }

    public async SetApprovalForMessage(msg: ChatMessage, approval: boolean | null): Promise<void>{
        if(!msg.isAI) return;
        await lastValueFrom(this.httpClient.post(this.baseUrl + "/Message/RateMessage", {msgId: msg.id, approval: approval}))
    }

    public async SendMessage(msg: string, chatId: number | null): Promise<ChatMessage>{
        return await lastValueFrom(this.httpClient.post<ChatMessage>(this.baseUrl + "/Message/SendMessage", {message: msg, chatId: chatId}))
    }
    
    public async CancelMessage(msg: string, msgId: number): Promise<ChatMessage>{
        return await lastValueFrom(this.httpClient.post<ChatMessage>(this.baseUrl + "/Message/CancelMessage", {message: msg, messageId: msgId}))
    }
}