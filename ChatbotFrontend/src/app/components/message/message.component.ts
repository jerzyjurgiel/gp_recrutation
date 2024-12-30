import { Component, EventEmitter, Input, Output } from "@angular/core";
import { ChatMessage } from "../../models/message.model";
import { CommonModule } from "@angular/common";
import { ApiService } from "../../services/api.service";
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from "@angular/material/button";


@Component({
    selector:"message",
    standalone: true,
    providers: [ApiService],
    imports: [CommonModule, MatIconModule, MatButtonModule],
    templateUrl: "message.component.html",
    styleUrls: ["./message.component.scss"]
})
export class MessageComponent {
    @Input() messageModel!: ChatMessage;
    @Output() cancelLoading: EventEmitter<void> = new EventEmitter();

    public constructor(private apiService: ApiService){}

    public async setApproval(value: boolean){
        await this.apiService.SetApprovalForMessage(this.messageModel, value);
        this.messageModel.approval = value;
    }
    public  cancelLoad(){
        this.cancelLoading.emit();
        setTimeout(async ()=>{
            await this.apiService.CancelMessage(this.messageModel.message, this.messageModel.id);
            this.messageModel.isLoading = false;
        });
    }
}